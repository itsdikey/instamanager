using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaManager.Containers.FollowList;
using SQLite;

namespace InstaManager.InstaManagers
{
    public class InstaBackUpManager
    {
        #region Singleton

        private static InstaBackUpManager _instance;

        public static InstaBackUpManager Instance => _instance ?? (_instance = new InstaBackUpManager());

        #endregion


        private readonly string DB_PATH;

        private const string DB_NAME = "backup.db";

        private SQLiteAsyncConnection _connection;

        private bool _isFirstBatch;

        public InstaBackUpManager()
        {
            DB_PATH = Path.Combine(Directory.GetCurrentDirectory(), DB_NAME);
            
        }

        public async Task InitConnection()
        {
            _connection = new SQLiteAsyncConnection(DB_PATH);

            if (!await TableExists<FollowerTable>(_connection))
            {
                await _connection.CreateTableAsync<FollowerTable>();
                _isFirstBatch = true;
            }
               

        }

        public async Task SetData(FollowListUI followers)
        {
            if (_isFirstBatch)
            {
                foreach (var follower in followers.Where(x=>x.Follows))
                {
                    var follow = new FollowerTable
                    {
                        FirstBatch = true,
                        InstaUserId = follower.OtherUser.Pk,
                        IsFollowingMe = true,
                        StartedToFollow = DateTime.Now,
                        StartedToUnfollow = null
                    };
                    await _connection.InsertAsync(follow);
                }
                return;
            }

            var currentDBList = await _connection.Table<FollowerTable>().ToListAsync();

            var newFollowers = followers.Where(x =>
            {
                var firstOrDefaultWithId = currentDBList.FirstOrDefault(o => o.InstaUserId == x.OtherUser.Pk);
                return x.Follows &&
                      (firstOrDefaultWithId == null || firstOrDefaultWithId.IsFollowingMe==false);
            });
            NewFollowers = newFollowers.Count();
            NewFollowersListUI = new FollowListUI(){ListType = FollowListUI.FollowListTypes.Additional };
            foreach (var newFollower in newFollowers)
            {
                var followerFromDB = currentDBList.FirstOrDefault(x => x.InstaUserId == newFollower.OtherUser.Pk);
                var follow = new FollowerTable
                {
                    Id = followerFromDB?.Id,
                    FirstBatch = false,
                    InstaUserId = newFollower.OtherUser.Pk,
                    IsFollowingMe = true,
                    StartedToFollow = DateTime.Now,
                    StartedToUnfollow = null
                };
                await _connection.InsertOrReplaceAsync(follow);
                NewFollowersListUI.Add(newFollower);

            }

            var newUnFollowers = currentDBList.Where(x =>
                x.IsFollowingMe && followers.FirstOrDefault(o => o.OtherUser.Pk == x.InstaUserId) == null);
            NewUnfollowers = newUnFollowers.Count();
            NewUnFollowersListUI = new FollowListUI(){ ListType = FollowListUI.FollowListTypes.Additional };
            foreach (var newUnFollower in newUnFollowers)
            {
                newUnFollower.FirstBatch = false;
                newUnFollower.IsFollowingMe = false;
                newUnFollower.StartedToUnfollow = DateTime.Now;
                await _connection.UpdateAsync(newUnFollower);
                var user = await InstaManager.Instance.GetUserByUserID(newUnFollower.InstaUserId);
                NewUnFollowersListUI.Add(user, 
                    followers.HasUserWithUserName(user.UserName)?FollowListUI.FollowListMode.IFollow
                                                                 :FollowListUI.FollowListMode.None);
            }
        

        }

        public int NewUnfollowers { get; set; }

        public int NewFollowers { get; set; }

      

        public FollowListUI NewUnFollowersListUI { get; private set; }

        public FollowListUI NewFollowersListUI { get; private set; }

        private static async Task<bool> TableExists<T>(SQLiteAsyncConnection connection)
        {
            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
            var cmd = await connection.ExecuteScalarAsync<string>(cmdText, typeof(T).Name);
            return cmd != null;
        }
    }

    #region Tables

    public class FollowerTable
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        public long InstaUserId { get; set; }

        public bool IsFollowingMe { get; set; }

        public DateTime StartedToFollow { get; set; }

        public DateTime? StartedToUnfollow { get; set; }

        public bool FirstBatch { get; set; }
    }
    #endregion
}

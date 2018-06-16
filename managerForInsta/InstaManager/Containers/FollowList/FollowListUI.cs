using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using InstaManager.Controls;
using InstaSharper.Classes.Models;

namespace InstaManager.Containers.FollowList
{
    public class FollowListUI : IEnumerable<FollowerUI>, INotifyCollectionChanged
    {
        private readonly Dictionary<string, FollowerUI>
            _otherUsers;


        public FollowListTypes ListType { get; set; }

        public FollowListUI(InstaSharper.Classes.Models.InstaUserShortList followers, InstaSharper.Classes.Models.InstaUserShortList following) : this()
        {
            InitData(followers, following);
        }

        public FollowListUI()
        {
            _otherUsers = new Dictionary<string, FollowerUI>();
            ListType = FollowListTypes.Default;
        }

        public bool HasUserWithUserName(string username)
        {
            return _otherUsers.ContainsKey(username);
        }


        public FollowerUI GetUserWithUserName(string username)
        {
            return _otherUsers.ContainsKey(username) ? _otherUsers[username] : null;
        }

        

        private void InitData(InstaUserShortList followers, InstaUserShortList following)
        {
            foreach (var follower in followers)
            {
                AddData(follower, FollowListMode.FollowMe);
            }

            foreach (var followed in following)
            {
                AddData(followed, FollowListMode.IFollow);
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void AddData(InstaUserShort user, FollowListMode follower)
        {
            FollowerUI current;
            if (!_otherUsers.ContainsKey(user.UserName))
            {
                current = new FollowerUI() { OtherUser = user };
                _otherUsers.Add(user.UserName, current);
            }
            else
            {
                current = _otherUsers[user.UserName];
            }
            if (follower == FollowListMode.FollowMe)
                current.Follows = true;
            if (follower == FollowListMode.IFollow)
            {
                current.IsFollowed = true;
            }

        }

        public void Add(InstaUserShort user, FollowListMode follower)
        {
            AddData(user,follower);
        }

        public void Add(FollowerUI follower)
        {
            _otherUsers.Add(follower.OtherUser.UserName,follower);
        }

        public bool RemoveFromMyFollower(InstaUserShort user)
        {
            var followerUI = _otherUsers[user.UserName];
            if (followerUI.Follows)
                return false;
            _otherUsers.Remove(user.UserName);
            return true;
        }


        public IEnumerator<FollowerUI> GetEnumerator()
        {
            return _otherUsers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public enum FollowListMode
        {
            None,
            FollowMe,
            IFollow,
            Mutual
        }

        public enum FollowListTypes
        {
            Default,
            Additional
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
    }

    public class FollowerUI
    {
        public InstaUserShort OtherUser { get; set; }

        public bool Follows { get; set; }

        public bool IsFollowed { get; set; }

        public FollowButtonState AssociatedButtonState { get; set; } = FollowButtonState.NotSelected;
    }
}

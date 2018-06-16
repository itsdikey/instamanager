using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaManager.Containers;
using InstaManager.Containers.FollowList;
using InstaManager.MessengerModels;
using InstaManager.Sources.Credentials;
using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Classes.Models;
using InstaSharper.Classes.ResponseWrappers;
using InstaSharper.Logger;

namespace InstaManager.InstaManagers
{
    public  class InstaManager
    {
        #region Singleton Pattern
        private static InstaManager _instance;

        public static InstaManager Instance => _instance ?? (_instance = new InstaManager());

        #endregion
        public InstaManager()
        {

        }

        private static IInstaApi _instaApi;

        public async Task<MainLoginModel> StartLoginAsync(Credential credential)
        {

            var userSession = new UserSessionData
            {
                UserName = credential.UserName,
                Password = credential.Password
            };

            var delay = RequestDelay.FromSeconds(1, 2);

            _instaApi = InstaApiBuilder.CreateBuilder().SetUser(userSession).UseLogger(new DebugLogger(LogLevel.Exceptions))
                .SetRequestDelay(delay).Build();

            if (_instaApi.IsUserAuthenticated) return null;
            // login
            Debug.WriteLine($"Logging in as {userSession.UserName}");
            delay.Disable();
            var logInResult = await _instaApi.LoginAsync();
            delay.Enable();
            if (!logInResult.Succeeded)
            {
                Debug.WriteLine($"Unable to login: {logInResult.Info.Message}");
                return null;
            }
            else
            {
                //  await UserProfile.InitData(_instaApi);
                MainLoginModel model = await UpdateLoginModel();

                return model;
            }


        }

        public async Task<MainLoginModel> UpdateLoginModel()
        {
            var info = await _instaApi.GetCurrentUserAsync();
            var model = new MainLoginModel {CurrentUser = info.Value};

            var followers =
                await _instaApi.GetUserFollowersAsync(info.Value.UserName, PaginationParameters.MaxPagesToLoad(15));
            model.Followers = followers.Value;
            var following = await _instaApi.GetUserFollowingAsync(info.Value.UserName, PaginationParameters.MaxPagesToLoad(15));
            model.Following = following.Value;
            return model;
        }

        public async Task<InstaUserShort> GetUserByUserName(string username)
        {
            var user = (await _instaApi.GetUserAsync(username)).Value;
            return new InstaUserShort()
            {
                FullName = user.FullName,
                UserName = user.UserName,
                IsPrivate = false,
                IsVerified = false,
                Pk = user.Pk,
                ProfilePicture = user.ProfilePicture,
                ProfilePictureId = user.ProfilePictureId
            };
        }

        public async Task<InstaUserShort> GetUserByUserID(long id)
        {
            var user = (await _instaApi.GetUserInfoByIdAsync(id)).Value;
            return new InstaUserShort()
            {
                FullName = user.FullName,
                UserName = user.Username,
                IsPrivate = false,
                IsVerified = false,
                Pk = user.Pk,
                ProfilePicture = user.ProfilePicUrl,
                ProfilePictureId = null
            };
        }

        public void StartFollowActions(ObservableHashSet<FollowerUI> toFollow,
            ObservableHashSet<FollowerUI> unFollow, Action<ActionPerformArgument> callback)
        {
            
            var args = new ActionPerformArgument
            {
                Total = toFollow.Count + unFollow.Count,
                Performed = 0
            };
            foreach (var l in toFollow)
            {
                var task = _instaApi.FollowUserAsync(l.OtherUser.Pk);
                task.GetAwaiter().OnCompleted(
                    () =>
                    {
                        
                        args.Performed++;
                        if (!task.Result.Value.Following)
                            toFollow.Remove(l);
                        callback(args);
                      
                    });
             
            }

            foreach (var l in unFollow)
            {
                var task =  _instaApi.UnFollowUserAsync(l.OtherUser.Pk);
                task.GetAwaiter().OnCompleted(
                    () => {
                        args.Performed++;
                        if (task.Result.Value.Following)
                            unFollow.Remove(l);
                        callback(args);
                      
                    });
            }
        }
    }
}

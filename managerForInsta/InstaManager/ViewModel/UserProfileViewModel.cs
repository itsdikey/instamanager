using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using InstaManager.Containers.FollowList;
using InstaManager.Extensions;
using InstaManager.InstaManagers;
using InstaManager.MessengerModels;
using InstaManager.Model;
using InstaManager.Sources.Credentials;

namespace InstaManager.ViewModel
{
    public class UserProfileViewModel : ViewModelBase
    {
        private ICommand _refreshButtonClicked;
        public UserProfileModel UserProfileModel { get; set; }

        public ICommand RefreshButtonClicked
        {
            get => _refreshButtonClicked;
            set
            {
                _refreshButtonClicked = value;
                OnPropertyChanged();
            }
        }


        public UserProfileViewModel()
        {
            UserProfileModel = new UserProfileModel();
            Messenger.Default.Register <GenericMessage<MainLoginModel>> (this, LoggedIn);
            Messenger.Default.Register<GenericMessage<ActionFinishedArgument>>(this,"FinishedActions",FinishedActions);
            RefreshButtonClicked = new RelayCommand(OnRefreshButtonClick);
        }

        private void OnRefreshButtonClick()
        {
            var loginModel = InstaManagers.InstaManager.Instance.UpdateLoginModel();
            loginModel.GetAwaiter().OnCompleted(
                () =>
                {
                    var result = loginModel.Result;

                    Messenger.Default.Send(new GenericMessage<MainLoginModel>(this, result));

                });
        }

        private void FinishedActions(GenericMessage<ActionFinishedArgument> obj)
        {
            UserProfileModel.FollowingCount += obj.Content.Followed.Count;
            UserProfileModel.FollowingCount -= obj.Content.UnFollowed.Count;
        }

        private void LoggedIn(GenericMessage<MainLoginModel> obj)
        {
            UserProfileModel.LoginModel = obj.Content;
            UserProfileModel.FollowerCount = obj.Content.Followers.Count;
            UserProfileModel.FollowingCount = obj.Content.Following.Count;
            Messenger.Default.Send(new GenericMessage<ListContainer>(
                new ListContainer {List = new FollowListUI(obj.Content.Followers, obj.Content.Following)}));
        }
    }
}

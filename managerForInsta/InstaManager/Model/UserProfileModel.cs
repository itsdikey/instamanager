using InstaManager.MessengerModels;

namespace InstaManager.Model
{
    public class UserProfileModel : ModelBase
    {
        private MainLoginModel _loginModel;
        private int _followerCount;
        private int _followingCount;

        public MainLoginModel LoginModel
        {
            get => _loginModel;
            set
            {
                _loginModel = value; 
                OnPropertyChanged(nameof(LoginModel));
            }
        }

        public int FollowerCount
        {
            get => _followerCount;
            set
            {
                _followerCount = value; 
                OnPropertyChanged();
            }
        }

        public int FollowingCount
        {
            get => _followingCount;
            set
            {
                _followingCount = value;
                OnPropertyChanged();
            }
        }
    }
}

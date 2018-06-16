namespace InstaManager.Model
{
    public class LoginModel : ModelBase
    {
        private string _userName;

        private string _password;
        

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value; 
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

      
    }
}

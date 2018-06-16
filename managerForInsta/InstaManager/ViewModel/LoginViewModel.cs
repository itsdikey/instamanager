using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using InstaManager.Containers;
using InstaManager.Extensions;
using InstaManager.MessengerModels;
using InstaManager.Model;
using InstaManager.Sources.Credentials;

namespace InstaManager.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private bool _loggingIn;
        public LoginModel LoginModel { get; set; }

        public ICommand ClickedLoginCommand { get; set; }

        public bool LoggingIn
        {
            get => _loggingIn;
            set
            {
                _loggingIn = value; 
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            LoginModel = new LoginModel();
            var creds = CredentialManager.GetCredentials();
            LoginModel.UserName = creds.UserName;
            LoginModel.Password = creds.Password;
            ClickedLoginCommand = new RelayCommand(() =>
            {
                var credenetials = new Credential()
                {
                    UserName = LoginModel.UserName, 
                    Password = LoginModel.Password
                };
                LoggingIn = true;
                var loginTask = InstaManagers.InstaManager.Instance.StartLoginAsync(credenetials);
                    loginTask.GetAwaiter().OnCompleted(
                    () =>
                    {
                        var result = loginTask.Result;
                        if (result == null)
                        {
                            LoggingIn = false;
                            return;
                        }

                        CredentialManager.SaveCredentials(credenetials);
                  
                        Messenger.Default.Send(new GenericMessage<MainLoginModel>(this, result));
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(this, MessagingConstants.CLOSE_WINDOWS));

                    });
            }, true);

        }
        
    }
}

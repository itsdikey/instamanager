using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using InstaManager.Containers;
using InstaManager.DesignHelpers;
using InstaManager.Windows;

namespace InstaManager.View
{
    /// <summary>
    /// Interaction logic for UserProfileView.xaml
    /// </summary>
    public partial class UserProfileView : UserControl
    {
        public UserProfileView()
        {
            InitializeComponent();
            Loaded += UserProfileView_Loaded;
        }


        private static Login _loginWindow;

        private void UserProfileView_Loaded(object sender, RoutedEventArgs e)
        {
            
            _loginWindow = new Login();
            _loginWindow.ShowDialog();
            var textButtonDecorator = new TextButtonDecorator(RefreshButton, new SolidColorBrush(Colors.White));
        }
    }
}

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using InstaManager.DesignHelpers;

namespace InstaManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var decor = new MoreButtonDecorator(MoreButton, new SolidColorBrush(Colors.White));
            var textButtonDecorator = new TextButtonDecorator(CloseButton, new SolidColorBrush(Colors.White));
        }

        private void TopRectangle_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

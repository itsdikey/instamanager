using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InstaManager.Containers;
using InstaManager.Containers.FollowList;

namespace InstaManager.Controls
{
    /// <summary>
    /// Interaction logic for Toolbar.xaml
    /// </summary>
    public partial class Toolbar : UserControl
    {
        public Toolbar()
        {
            InitializeComponent();
            Loaded += Toolbar_Loaded;
        }

        private void Toolbar_Loaded(object sender, RoutedEventArgs e)
        {
            SidebarShowButton.Click += SidebarShowButton_Click;
            SideBar.Visibility = Visibility.Collapsed;
        }

        private void SidebarShowButton_Click(object sender, RoutedEventArgs e)
        {
            if (SideBar.Visibility == Visibility.Collapsed)
            {
                SideBar.Visibility = Visibility.Visible;
                (Resources["ButtonClickedToShow"] as Storyboard).Begin();
            }
            else
            {
                SideBar.Visibility = Visibility.Collapsed;
                (Resources["ButtonClickedToHide"] as Storyboard).Begin();
            }
          
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ArrowOne.Fill = new SolidColorBrush(Colors.White);
            ArrowSecond.Fill = new SolidColorBrush(Colors.White);
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ArrowOne.Fill = new SolidColorBrush(Color.FromRgb(116,116,116));
            ArrowSecond.Fill = new SolidColorBrush(Color.FromRgb(116, 116, 116));
        }

        public void InitList(FollowList followList)
        {
            _list = followList;
        }

        public void InitList(ICollectionView collectionView)
        {
            _collectionView = collectionView;
        }

        private ICollectionView _collectionView;
        private FollowList _list;


        private void FilterButton_OnClick(object sender, RoutedEventArgs e)
        {
            var mode =  (FollowList.FollowListMode)Enum.Parse(typeof(FollowList.FollowListMode), 
                                                                    (sender as Button).Tag.ToString());
           // _list.Mode = mode;

           
        }
    }
}

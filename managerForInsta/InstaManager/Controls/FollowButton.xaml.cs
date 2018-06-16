using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using InstaManager.Containers.FollowList;

namespace InstaManager.Controls
{
    /// <summary>
    /// Interaction logic for FollowButton.xaml
    /// </summary>
    public partial class FollowButton : UserControl, ICommandSource
    {
        public FollowButton()
        {
            InitializeComponent();
            MainButton.Click += MainButton_Click;
            Loaded += FollowButton_Loaded;
        }

     

        public static readonly DependencyProperty IsFollowedProperty = 
            DependencyProperty.Register("IsFollowed",typeof(Boolean),typeof(FollowButton));
        public static readonly DependencyProperty FollowingProperty =
            DependencyProperty.Register("Following", typeof(Boolean), typeof(FollowButton));
        public static readonly DependencyProperty UserIdProperty =
            DependencyProperty.Register("UserId", typeof(Int64), typeof(FollowButton));
        public static readonly DependencyProperty AssociatedFollowerProperty = 
            DependencyProperty.Register("AssociatedFollower", typeof(FollowerUI),typeof(FollowButton));


        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(FollowButton), new PropertyMetadata((ICommand)null,new PropertyChangedCallback(CommandChanged)));

      

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(FollowButton));

        public bool IsFollowed
        {
            get => (bool) GetValue(IsFollowedProperty);
            set => SetValue(IsFollowedProperty,value);
        }

        public bool Following
        {
            get => (bool)GetValue(FollowingProperty);
            set => SetValue(FollowingProperty, value);
        }

        public long UserId
        {
            get => (long)GetValue(UserIdProperty);
            set => SetValue(UserIdProperty, value);
        }

        public FollowerUI AssociatedFollower
        {
            get => (FollowerUI)GetValue(AssociatedFollowerProperty);
            set => SetValue(AssociatedFollowerProperty, value);
        }


        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentState == FollowButtonState.Selected)
            {
                CurrentState = FollowButtonState.NotSelected;
                (Resources["UnSelected"] as Storyboard)?.Begin();
            }
            else if (CurrentState == FollowButtonState.NotSelected)
            {
                CurrentState = FollowButtonState.Selected;
                (Resources["Selected"] as Storyboard)?.Begin();
            }
            AssociatedFollower.AssociatedButtonState = CurrentState;
            OnStateChanged(CurrentState);
        }

        public event Action<object, FollowButtonState> StateChanged;

        public FollowButtonState CurrentState { get; private set; } = FollowButtonState.NotSelected;

        private void FollowButton_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateState();
        }

        private void UpdateState()
        {
            textBlock.Text = IsFollowed ? "unfollow" : "follow";


            if (CurrentState == AssociatedFollower.AssociatedButtonState)
                return;
            CurrentState = AssociatedFollower.AssociatedButtonState;
            if (AssociatedFollower.AssociatedButtonState == FollowButtonState.Selected)
            {
                (Resources["Selected"] as Storyboard)?.Begin();
                (Resources["Selected"] as Storyboard)?.Seek(new TimeSpan(0), TimeSeekOrigin.Duration);
            }
            else if (AssociatedFollower.AssociatedButtonState == FollowButtonState.NotSelected)
            {
                (Resources["UnSelected"] as Storyboard)?.Begin();
                (Resources["UnSelected"] as Storyboard)?.Seek(new TimeSpan(0), TimeSeekOrigin.Duration);
            }
        }

        protected virtual void OnStateChanged(FollowButtonState newState)
        {
            StateChanged?.Invoke(this, newState);
            if (Command != null)
            {
                if(Command.CanExecute(CommandParameter))
                    Command.Execute(CommandParameter);
            }
        }

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty,value);
        }

        private static void CommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (FollowButton)d;
        }


        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
        public IInputElement CommandTarget { get; }
    }

    public enum FollowButtonState
    {
        Selected, NotSelected
    }
}

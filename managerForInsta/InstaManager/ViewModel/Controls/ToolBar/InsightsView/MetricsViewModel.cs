using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using InstaManager.Containers.FollowList;
using InstaManager.InstaManagers;
using InstaManager.MessengerModels;
using InstaManager.Model;

namespace InstaManager.ViewModel.Controls.ToolBar.InsightsView
{
    public class MetricsViewModel : ViewModelBase
    {
        private MetricsModel _metricsModel;
        private ICommand _buttonClicked;

        public MetricsModel MetricsModel
        {
            get => _metricsModel;
            set
            {
                _metricsModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ButtonClicked
        {
            get => _buttonClicked;
            set
            {
                _buttonClicked = value;
                OnPropertyChanged();
            }
        }

        public MetricsViewModel()
        {
            _metricsModel = new MetricsModel();
            Messenger.Default.Register<GenericMessage<ListContainer>>(this,ListReceived);
            ButtonClicked = new RelayCommand<Button>(FilterButtonClick);
        }

        private void FilterButtonClick(Button button)
        {
            FollowListUI list;

            list = button.Tag.ToString()=="unfollowers"?InstaBackUpManager.Instance.NewUnFollowersListUI:InstaBackUpManager.Instance.NewFollowersListUI;
            var container = new ListContainer();
            container.List = list;
            Messenger.Default.Send(new GenericMessage<ListContainer>(container),"MetricsList");
        }

        private async void ListReceived(GenericMessage<ListContainer> obj)
        {
            _metricsModel.TheyDontFollowBack = obj.Content.List.Count(x => x.IsFollowed && !x.Follows);
            _metricsModel.IDontFollowBack = obj.Content.List.Count(x => !x.IsFollowed && x.Follows);

            await InstaBackUpManager.Instance.InitConnection();
            await InstaBackUpManager.Instance.SetData(obj.Content.List);
            _metricsModel.FollowMe = InstaBackUpManager.Instance.NewFollowers;

            _metricsModel.UnFollowedMe = InstaBackUpManager.Instance.NewUnfollowers;
        }

    
    }
}

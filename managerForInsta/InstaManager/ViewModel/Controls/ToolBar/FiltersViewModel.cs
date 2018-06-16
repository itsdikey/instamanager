using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using InstaManager.Containers;
using InstaManager.Containers.FollowList;

namespace InstaManager.ViewModel.Controls.ToolBar
{
    public class FiltersViewModel : ViewModelBase
    {
        private ICommand _filterChangedCommand;

        public ICommand FilterChangedCommand
        {
            get => _filterChangedCommand;
            set
            {
                _filterChangedCommand = value; 
                OnPropertyChanged();
            }
        }

        public FiltersViewModel()
        {
            FilterChangedCommand = new RelayCommand<object>(
                (o) =>
                {
                    var mode = (FollowList.FollowListMode)Enum.Parse(typeof(FollowList.FollowListMode),
                        o.ToString());

                    Messenger.Default.Send(new GenericMessage<FollowList.FollowListMode>(mode));
                });
        }
    }
}

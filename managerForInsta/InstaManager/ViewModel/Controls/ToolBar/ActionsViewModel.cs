using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using InstaManager.Containers;
using InstaManager.Containers.FollowList;
using InstaManager.InstaManagers;
using InstaManager.MessengerModels;
using InstaManager.Model;

namespace InstaManager.ViewModel.Controls.ToolBar
{
    public class ActionsViewModel : ViewModelBase
    {
        public ObservableHashSet<FollowerUI> ToFollows
        {
            get => _toFollow;
            set
            {
                _toFollow = value;
                OnPropertyChanged();
            }
        }
        private ObservableHashSet<FollowerUI> _toFollow;
        private ObservableHashSet<FollowerUI> _toUnFollow;
        private ICommand _performActionsCommand;
        private bool _isPerformingActions;
        private int _actionsAlreadyPerformed;
        private int _totalActionToPerform;

        public int ActionsAlreadyPerformed
        {
            get => _actionsAlreadyPerformed;
            set
            {
                _actionsAlreadyPerformed = value; 
                OnPropertyChanged();
            }
        }

        public int TotalActionToPerform
        {
            get => _totalActionToPerform;
            set
            {
                _totalActionToPerform = value;
                OnPropertyChanged();
            }
        }


        public ObservableHashSet<FollowerUI> ToUnFollow
        {
            get => _toUnFollow;
            set
            {
                _toUnFollow = value; 
                OnPropertyChanged();
            }
        }

        public ICommand PerformActionsCommand
        {
            get => _performActionsCommand;
            set
            {
                _performActionsCommand = value;
                OnPropertyChanged();
            }
        }

        public bool IsPerformingActions
        {
            get => _isPerformingActions;
            set
            {
                _isPerformingActions = value; 
                OnPropertyChanged();
            }
        }


        public ActionsViewModel()
        {
            ToFollows = new ObservableHashSet<FollowerUI>();
            ToUnFollow = new ObservableHashSet<FollowerUI>();
            PerformActionsCommand = new RelayCommand(() =>
            {
                TotalActionToPerform = _toFollow.Count + _toUnFollow.Count;
                if(TotalActionToPerform<=0)
                    return;
                InstaManagers.InstaManager.Instance.StartFollowActions(_toFollow, _toUnFollow,
                    ActionPerformedCallback);
                IsPerformingActions = true;
             
            });

            Messenger.Default.Register<GenericMessage<ActionPerformRequestModel>>(this,ActionPerformRequest);

        }

        private void ActionPerformedCallback(ActionPerformArgument obj)
        {
            ActionsAlreadyPerformed = obj.Performed;
            if (obj.Performed == obj.Total)
                FinishedPerformingActions();

        }

        private void FinishedPerformingActions()
        {
            IsPerformingActions = false;
            var actionFinishedArgument = new ActionFinishedArgument(_toFollow,_toUnFollow);
            _toUnFollow.Reset();
            _toFollow.Reset();
            Messenger.Default.Send(new GenericMessage<ActionFinishedArgument>(actionFinishedArgument),"FinishedActions");
        }

        private void ActionPerformRequest(GenericMessage<ActionPerformRequestModel> obj)
        {
            var performRequest = obj.Content;
            var collection = 
                performRequest.ActionToPerform == ActionOfFollowing.Follow ? _toFollow : _toUnFollow;

            switch (performRequest.Behaviour)
            {
                case AddOrRemove.Add:
                    collection.Add(performRequest.UserUI);
                    break;
                case AddOrRemove.Remove:
                    collection.Remove(performRequest.UserUI);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

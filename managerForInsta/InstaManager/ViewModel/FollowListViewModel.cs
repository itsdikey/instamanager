using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using InstaManager.Containers;
using InstaManager.Containers.FollowList;
using InstaManager.Controls;
using InstaManager.InstaManagers;
using InstaManager.MessengerModels;
using InstaManager.Model;

namespace InstaManager.ViewModel
{
    public class FollowListViewModel : ViewModelBase
    {
        private ICollectionView _followers;

        private FollowListUI _currentFollowList;
        public FollowListModel FollowListModel { get; set; }

        public ICommand FollowButtonClicked { get; set; }

        public ICollectionView Followers
        {
            get => _followers;
            set
            {
                _followers = value; 
                OnPropertyChanged();
            }
        }

        public FollowListViewModel()
        {
            FollowButtonClicked = new RelayCommand<FollowButton>((followButton) =>
            {
                var performActionRequest = new ActionPerformRequestModel();
                performActionRequest.UserUI = followButton.AssociatedFollower;
                if (followButton.IsFollowed)
                    performActionRequest.ActionToPerform = ActionOfFollowing.UnFollow;
                else if (followButton.Following)
                    performActionRequest.ActionToPerform = ActionOfFollowing.Follow;
                performActionRequest.Behaviour = followButton.CurrentState == FollowButtonState.Selected ? AddOrRemove.Add : AddOrRemove.Remove;

                Messenger.Default.Send(new GenericMessage<ActionPerformRequestModel>(performActionRequest));
            });
            Messenger.Default.Register<GenericMessage<ListContainer>>(this, ListReceived);

            Messenger.Default.Register<GenericMessage<ListContainer>>(this, "MetricsList", ListReceived);

            Messenger.Default.Register<GenericMessage<FollowList.FollowListMode>>(this,FilterModeChanged);

            Messenger.Default.Register<GenericMessage<ActionFinishedArgument>>(this, "FinishedActions", ActionPerformFinished);

          
        }

        private void ListReceived(GenericMessage<ListContainer> obj)
        {
            var list = obj.Content.List;

            if (FollowListModel == null)
            {
                FollowListModel =
                    new FollowListModel();

            }

            if (list.ListType== FollowListUI.FollowListTypes.Additional)
            {
                Followers = new CollectionView(obj.Content.List);
                return;
            }

     
            _currentFollowList = obj.Content.List;
            Followers = new CollectionView(_currentFollowList);


        }

        private void ActionPerformFinished(GenericMessage<ActionFinishedArgument> obj)
        {
            var content = obj.Content;
            
            foreach (var newFollow in content.Followed)
            {
                _currentFollowList.Add(newFollow.OtherUser,FollowListUI.FollowListMode.IFollow);
                newFollow.IsFollowed = true;
                newFollow.AssociatedButtonState = FollowButtonState.NotSelected;
            }

            foreach (var unFollow in content.UnFollowed)
            {
                if (_currentFollowList.RemoveFromMyFollower(unFollow.OtherUser)) continue;
                unFollow.IsFollowed = false;
                unFollow.AssociatedButtonState = FollowButtonState.NotSelected;

            }

            Followers.Refresh();
        }

        private void FilterModeChanged(GenericMessage<FollowList.FollowListMode> obj)
        {
            Followers = new CollectionView(_currentFollowList);
            var mode = obj.Content;
            _followers.Filter = (o) =>
            {
                var x = o as FollowerUI;
                switch (mode)
                {
                    case FollowList.FollowListMode.FollowMe:
                        return x.Follows && !x.IsFollowed;
                    case FollowList.FollowListMode.IFollow:
                        return !x.Follows && x.IsFollowed;
                    case FollowList.FollowListMode.Mutual:
                        return x.Follows && x.IsFollowed;
                }

                return true;

            };
        }
    }
}
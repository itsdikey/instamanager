using System.ComponentModel;

namespace InstaManager.Model
{
    public class FollowListModel : ModelBase
    {
        private ICollectionView _followers;
        public ICollectionView Followers
        {
            get => _followers;
            set
            {
                _followers = value; 
                OnPropertyChanged(nameof(Followers));
            }
        }
    }
}

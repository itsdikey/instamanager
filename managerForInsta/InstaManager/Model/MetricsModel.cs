using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaManager.Model
{
    public class MetricsModel : ModelBase
    {
        private int _followDontFollowBack;
        private int _dontFollowBack;
        private int _unFollowedMe;
        private int _followMe;

        public int TheyDontFollowBack
        {
            get => _followDontFollowBack;
            set
            {
                _followDontFollowBack = value; 
                OnPropertyChanged();
            }
        }

        public int IDontFollowBack
        {
            get => _dontFollowBack;
            set
            {
                _dontFollowBack = value; 
                OnPropertyChanged();
            }
        }

        public int UnFollowedMe
        {
            get => _unFollowedMe;
            set
            {
                _unFollowedMe = value; 
                OnPropertyChanged();
            }
        }

        public int FollowMe
        {
            get => _followMe;
            set
            {
                _followMe = value; 
                OnPropertyChanged();
            }
        }
    }
}

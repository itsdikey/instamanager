using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaManager.Containers;
using InstaManager.Containers.FollowList;

namespace InstaManager.InstaManagers
{
    public class ActionPerformArgument : EventArgs
    {
        public int Performed { get; set; }
        public int Total { get; set; }
    }

    public class ActionFinishedArgument : EventArgs
    {
        public ObservableHashSet<FollowerUI> Followed { get; private set; }

        public ObservableHashSet<FollowerUI> UnFollowed { get; private set; }

        public ActionFinishedArgument(ObservableHashSet<FollowerUI> followed, ObservableHashSet<FollowerUI> unFollowed)
        {
            Followed = new ObservableHashSet<FollowerUI>(followed);
            UnFollowed = new ObservableHashSet<FollowerUI>(unFollowed);
        }
    }
}

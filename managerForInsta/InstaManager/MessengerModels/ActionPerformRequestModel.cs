using InstaManager.Containers.FollowList;

namespace InstaManager.MessengerModels
{
    public class ActionPerformRequestModel 
    {
        public ActionOfFollowing ActionToPerform;

        public AddOrRemove Behaviour;

        public FollowerUI UserUI;
    }

    public enum ActionOfFollowing
    {
        Follow,
        UnFollow
    }

    public enum AddOrRemove
    {
        Add,
        Remove
    }
}

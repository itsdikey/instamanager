using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using InstaSharper.Classes.Models;

namespace InstaManager.Containers.FollowList
{

    public class FollowList : IEnumerable<Follower>, INotifyCollectionChanged
    {
        private readonly Dictionary<string,Follower>
            _otherUsers;
        

        public FollowList(InstaSharper.Classes.Models.InstaUserShortList followers, InstaSharper.Classes.Models.InstaUserShortList following)
        {
            _otherUsers = new Dictionary<string, Follower>();

            InitData(followers, following);

        }

        private void InitData(InstaUserShortList followers, InstaUserShortList following)
        {
            foreach (var follower in followers)
            {
                AddData(follower,true);
            }

            foreach (var followed in following)
            {
                AddData(followed, false);
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void AddData(InstaUserShort user, bool follower)
        {
            Follower current;
            if (!_otherUsers.ContainsKey(user.UserName))
            {
                current = new Follower() {OtherUser = user};
                _otherUsers.Add(user.UserName,current);
            }
            else
            {
                current = _otherUsers[user.UserName];
            }
            if(follower)
            current.Follows = true;
            if (!follower)
            {
                current.IsFollowed = true;
            }
          
        }


        public IEnumerator<Follower> GetEnumerator()
        {
            return _otherUsers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public enum FollowListMode
        {
            None,
            FollowMe,
            IFollow,
            Mutual
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        //public int IndexOf(Follower item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(int index, Follower item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveAt(int index)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(Follower item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Clear()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Contains(Follower item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CopyTo(Follower[] array, int arrayIndex)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Remove(Follower item)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class Follower
    {
        public InstaUserShort OtherUser { get; set; }

        public bool Follows { get; set; }

        public bool IsFollowed { get; set; }
    }
}

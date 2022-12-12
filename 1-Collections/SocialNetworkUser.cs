using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly IDictionary<string, ISet<TUser>> _followed = new Dictionary<string, ISet<TUser>>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {}

        public bool AddFollowedUser(string group, TUser user)
        {
            ISet<TUser> usr;
            if(_followed.ContainsKey(group))
            {
                usr = _followed[group];
                return usr.Add(user);
            }
            else
            {
                usr = new HashSet<TUser>();
                usr.Add(user);
                _followed.Add(group, usr);
                return true;
            }
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                IList<TUser> followedUsers = new List<TUser>();
                foreach (var group in _followed.Keys)
                {
                    foreach (var user in _followed[group])
                    {
                        followedUsers.Add(user);
                    }
                }
                return followedUsers;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if(_followed.ContainsKey(group))
                return new HashSet<TUser>(_followed[group]);
            else
                return new HashSet<TUser>();
        }
    }
}

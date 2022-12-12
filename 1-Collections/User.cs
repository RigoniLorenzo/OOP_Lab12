using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            this.FullName=fullName;
            this.Age = age;
            this.Username = username ?? throw new ArgumentNullException("The username can't be null!");
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => this.Age != null;
        
    }
}

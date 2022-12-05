using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.Models
{
    public enum UserRole
    {
        Admin,
        Trainer,
        Client
    }

    public class UserData :IEquatable<UserData>
    {

        public string Id { get; }
        public string Email { get;  }
        public string AvatarUrl { get; }
        public string Phone { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
        public UserRole Role { get; }
        public string Birthday { get; }
        public string LastVisit { get; }
        public UserData(string id,
                        string email,
                        string avatarUrl,
                        string phone,
                        string firstName,
                        string lastName,
                        string middleName,
                        UserRole role,
                        string birthday,
                        string lastVisit)
        {
            Id = id;
            Email = email;
            AvatarUrl = avatarUrl;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Role = role;
            Birthday = birthday;
            LastVisit = lastVisit;
        }

        public bool Equals(UserData other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

using EDriveRent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private readonly List<IUser> _users = new List<IUser>();

        public void AddModel(IUser user)
        {
            _users.Add(user);
        }

        public bool RemoveById(string identifier)
        {
            var userToRemove = _users.FirstOrDefault(user => user.DrivingLicenseNumber == identifier);

            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
                return true;
            }

            return false;
        }

        public IUser FindById(string identifier)
        {
            return _users.FirstOrDefault(user => user.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return _users.AsReadOnly();
        }
    }
}

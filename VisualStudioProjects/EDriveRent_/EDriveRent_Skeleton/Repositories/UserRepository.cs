public class UserRepository : IRepository<IUser>
{
    private readonly List<IUser> _users = new List<IUser>();

    public void AddModel(IUser user)
    {
        _users.Add(user);
    }

    public bool RemoveById(string identifier)
    {
        var user = _users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
        if (user != null)
        {
            _users.Remove(user);
            return true;
        }
        return false;
    }

    public IUser FindById(string identifier)
    {
        return _users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
    }

    public IReadOnlyCollection<IUser> GetAll()
    {
        return _users.AsReadOnly();
    }
}
public class User : IUser
{
    public User(string firstName, string lastName, string drivingLicenseNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("FirstName cannot be null or whitespace!");
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("LastName cannot be null or whitespace!");
        if (string.IsNullOrWhiteSpace(drivingLicenseNumber)) throw new ArgumentException("Driving license number is required!");

        FirstName = firstName;
        LastName = lastName;
        DrivingLicenseNumber = drivingLicenseNumber;
        Rating = 0;
        IsBlocked = false;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string DrivingLicenseNumber { get; }
    public double Rating { get; private set; }
    public bool IsBlocked { get; private set; }

    public void IncreaseRating()
    {
        Rating += 0.5;
        if (Rating > 10.0) Rating = 10.0;
    }

    public void DecreaseRating()
    {
        Rating -= 2.0;
        if (Rating < 0.0)
        {
            Rating = 0.0;
            IsBlocked = true;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
    }
}

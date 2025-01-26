namespace EDriveRent.Interfaces
{
    public interface IRoute
    {
        public string StartPoint { get; }

        public string EndPoint { get; }

        public double Length { get; }

        public int Id { get; }

        public bool IsLocked { get; }

        public void LockRoute();
    }
}
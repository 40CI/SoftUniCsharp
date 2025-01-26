public class VehicleRepository : IRepository<IVehicle>
{
    private readonly List<IVehicle> _vehicles = new List<IVehicle>();

    public void AddModel(IVehicle vehicle)
    {
        _vehicles.Add(vehicle);
    }

    public bool RemoveById(string identifier)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);
        if (vehicle != null)
        {
            _vehicles.Remove(vehicle);
            return true;
        }
        return false;
    }

    public IVehicle FindById(string identifier)
    {
        return _vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);
    }

    public IReadOnlyCollection<IVehicle> GetAll()
    {
        return _vehicles.AsReadOnly();
    }
}
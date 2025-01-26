public class Controller : IController
{
    private UserRepository _users;
    private VehicleRepository _vehicles;
    private RouteRepository _routes;

    public Controller()
    {
        _users = new UserRepository();
        _vehicles = new VehicleRepository();
        _routes = new RouteRepository();
    }

    // Implement the required methods from the IController interface here.
	public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
{
    if (_users.FindByDrivingLicenseNumber(drivingLicenseNumber) != null)
    {
        return $"{drivingLicenseNumber} is already registered in our platform.";
    }
    _users.AddModel(new User(firstName, lastName, drivingLicenseNumber));
    return $"{firstName} {lastName} is registered successfully with DLN-{drivingLicenseNumber}";
}


public string UploadVehicle(string vehicleTypeName, string brand, int model, string licensePlateNumber)
{
    if (_vehicles.FindByLicensePlateNumber(licensePlateNumber) != null)
    {
        return $"{licensePlateNumber} belongs to another vehicle.";
    }
    IVehicle vehicle;
    if (vehicleTypeName == "PassengerCar")
    {
        vehicle = new PassengerCar(brand, model, licensePlateNumber);
    }
    else if (vehicleTypeName == "CargoVan")
    {
        vehicle = new CargoVan(brand, model, licensePlateNumber);
    }
    else
    {
        return $"{vehicleTypeName} is not accessible in our platform.";
    }
    _vehicles.AddModel(vehicle);
    return $"{brand} {model} is uploaded successfully with LPN-{licensePlateNumber}";
}

public string AllowRoute(string startPoint, string endPoint, double length)
{
    var existingRoute = _routes.FindByStartAndEndPoints(startPoint, endPoint);
    if (existingRoute != null)
    {
        if (existingRoute.Length == length)
        {
            return $"{startPoint}/{endPoint} - {length} km is already added in our platform.";
        }
        if (existingRoute.Length < length)
        {
            return $"{startPoint}/{endPoint} shorter route is already added in our platform.";
        }
    }

    int routeId = _routes.GetAll().Count + 1;
    IRoute route = new Route(startPoint, endPoint, length, routeId);
    _routes.AddModel(route);

    if (existingRoute != null)
    {
        existingRoute.Lock();
    }

    return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
}
public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
{
    var user = _users.FindByDrivingLicenseNumber(drivingLicenseNumber);
    var vehicle = _vehicles.FindByLicensePlateNumber(licensePlateNumber);
    var route = _routes.FindByRouteId(routeId);

    if (user.IsBlocked)
    {
        return $"User {drivingLicenseNumber} is blocked in the platform! Trip is not allowed.";
    }
    if (vehicle.IsDamaged)
    {
        return $"Vehicle {licensePlateNumber} is damaged! Trip is not allowed.";
    }
    if (route.IsLocked)
    {
        return $"Route {routeId} is locked! Trip is not allowed.";
    }

    vehicle.Drive(route.Length);

    if (isAccidentHappened)
    {
        vehicle.IsDamaged = true;
        user.DecreaseRating();
    }
    else
    {
        user.IncreaseRating();
    }

    string status = vehicle.IsDamaged ? "damaged" : "OK";
    return $"{vehicle.Brand} {vehicle.Model} License plate: {vehicle.LicensePlateNumber} Battery: {vehicle.BatteryLevel}% Status: {status}";
}
public string RepairVehicles(int count)
{
    var damagedVehicles = _vehicles.GetAll().Where(v => v.IsDamaged).OrderBy(v => v.Brand).ThenBy(v => v.Model).Take(count).ToList();
    foreach (var vehicle in damagedVehicles)
    {
        vehicle.IsDamaged = false;
        vehicle.RechargeBattery();
    }
    return $"{damagedVehicles.Count} vehicles are successfully repaired!";
}

public string UsersReport()
{
    var users = _users.GetAll().OrderByDescending(u => u.Rating).ThenBy(u => u.LastName).ThenBy(u => u.FirstName).ToList();
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("*** E-Drive-Rent ***");
    foreach (var user in users)
    {
        sb.AppendLine(user.ToString());
    }
    return sb.ToString();
}

}

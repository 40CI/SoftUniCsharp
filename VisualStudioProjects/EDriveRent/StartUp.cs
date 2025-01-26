using EDriveRent.EDriveRent;
using EDriveRent.Repositories;
using global::EDriveRent.Core;
using global::EDriveRent.Core.Contracts;

namespace EDriveRent
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        
            // Test your classes here
            UserRepository userRepository = new UserRepository();
        VehicleRepository vehicleRepository = new VehicleRepository();
        RouteRepository routeRepository = new RouteRepository();

        RentController rentController = new RentController(userRepository, vehicleRepository, routeRepository);

        // Add and manage instances of User, Vehicle, Route, and their respective repositories
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Interfaces;
using EDriveRent.Models;
using EDriveRent.Repositories;

namespace EDriveRent
{

    namespace EDriveRent
    {
        public class RentController
        {
            private UserRepository _userRepo;
            private VehicleRepository _vehicleRepo;
            private RouteRepository _routeRepo;
            private UserRepository userRepository;
            private VehicleRepository vehicleRepository;
            private RouteRepository routeRepository;

            public RentController()
            {
                _userRepo = new UserRepository();
                _vehicleRepo = new VehicleRepository();
                _routeRepo = new RouteRepository();
            }

            public RentController(UserRepository userRepository, VehicleRepository vehicleRepository, RouteRepository routeRepository)
            {
                this.userRepository = userRepository;
                this.vehicleRepository = vehicleRepository;
                this.routeRepository = routeRepository;
            }

            // Add any additional methods needed to manage interactions between users, vehicles, and routes
        }
    }

}

using EDriveRent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models;

namespace EDriveRent.Repositories
{
        public class VehicleRepository : IRepository<IVehicle>
        {
            private readonly List<IVehicle> _vehicles;

            public VehicleRepository()
            {
                _vehicles = new List<IVehicle>();
            }

            public void Add(IVehicle vehicle)
            {
                _vehicles.Add(vehicle);
            }

            public void Remove(IVehicle vehicle)
            {
                _vehicles.Remove(vehicle);
            }

            public IVehicle Find(string licensePlateNumber)
            {
                return _vehicles.FirstOrDefault(v => v.LicensePlateNumber == licensePlateNumber);
            }

            public IEnumerable<IVehicle> GetAll()
            {
                return _vehicles;
            }

        public void AddModel(IVehicle model)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string identifier)
        {
            throw new NotImplementedException();
        }

        public IVehicle FindById(string identifier)
        {
            throw new NotImplementedException();
        }

        IReadOnlyCollection<IVehicle> IRepository<IVehicle>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
    }



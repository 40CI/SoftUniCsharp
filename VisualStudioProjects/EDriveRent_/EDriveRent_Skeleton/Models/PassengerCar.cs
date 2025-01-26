using EDriveRent.Models.Contracts;

namespace EDriveRent.Models.Vehicles
{
    public class PassengerCar : Vehicle, IDrivable
    {
        public PassengerCar(string brand, string model, int batteryCapacity, string licensePlateNumber)
            : base(brand, model, batteryCapacity, licensePlateNumber)
        {
        }

        public override void ChangeStatus()
        {
            throw new System.NotImplementedException();
        }

        public override void Recharge()
        {
            throw new System.NotImplementedException();
        }

        public override double MaxMileage => throw new System.NotImplementedException();

        int IDrivable.MaxSpeed => throw new System.NotImplementedException();

        int IDrivable.MaxPassengers => throw new System.NotImplementedException();

        int IDrivable.MaxCargoCapacity => throw new System.NotImplementedException();

        public override string ToString()
        {
            return base.ToString();
        }

        void IDrivable.Accelerate()
        {
            throw new System.NotImplementedException();
        }

        void IDrivable.Brake()
        {
            throw new System.NotImplementedException();
        }
    }
}


        public interface IDrivable
        {
            // Properties
            int MaxSpeed { get; }
            int MaxPassengers { get; }
            int MaxCargoCapacity { get; }

            // Methods
            void Accelerate();
            void Brake();
        }
    



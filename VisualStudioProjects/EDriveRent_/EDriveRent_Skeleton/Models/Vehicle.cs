using EDriveRent.Utilities;

namespace EDriveRent.Models.Vehicles
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Utilities.Messages;
    using EDriveRent.Utilities.Validators;
    using System.Configuration;

    public abstract class Vehicle : IVehicle
    {
        private string _brand;
        private string _model;

        protected Vehicle(string brand, string model, int batteryCapacity, string licensePlateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.BatteryCapacity = batteryCapacity;
            this.BatteryLevel = batteryCapacity;
            this.LicensePlateNumber = licensePlateNumber;
        }

        public int BatteryCapacity { get; private set; }

        public int BatteryLevel { get; set; }

        public bool IsDamaged { get; set; }

        public string LicensePlateNumber { get; private set; }

        public string Brand
        {
            get
            {
                return this._brand;
            }

            private set
            {
                this._brand = StringValidator.ThrowIfStringLengthIsOutOfRange(value, Constants.MinVehicleBrandLength, Constants.MaxVehicleBrandLength, string.Format(ExceptionMessages.InvalidBrandLength, Constants.MinVehicleBrandLength, Constants.MaxVehicleBrandLength));
            }
        }

        public string Model
        {
            get
            {
                return this._model;
            }

            private set
            {
                this._model = StringValidator.ThrowIfStringLengthIsOutOfRange(value, Constants.MinVehicleModelLength, Constants.MaxVehicleModelLength, string.Format(ExceptionMessages.InvalidModelLength, Constants.MinVehicleModelLength, Constants.MaxVehicleModelLength));
            }
        }

        public virtual double MaxMileage
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public abstract void ChangeStatus();

        public void Drive(double kilometers)
        {
            double batteryPercentageToUse = kilometers / Constants.BatteryDrainageCoefficient;
            if (batteryPercentageToUse <= this.BatteryLevel)
            {
                this.BatteryLevel -= (int)batteryPercentageToUse;
            }
            else
            {
                this.BatteryLevel = 0;
            }
        }

        public abstract void Recharge();

        public void RechargeBattery()
        {
            this.BatteryLevel = this.BatteryCapacity;
        }
    }
}

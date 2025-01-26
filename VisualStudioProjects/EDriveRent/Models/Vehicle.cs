using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Interfaces;

namespace EDriveRent.Models
{

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException("Brand cannot be null or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Model cannot be null or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(licensePlateNumber))
            {
                throw new ArgumentException("License plate number is required!");
            }

            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand { get; }

        public string Model { get; }

        public double MaxMileage { get; }

        public string LicensePlateNumber { get; }

        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; private set; }

        public virtual void Drive(double mileage)
        {
            int percentage = (int)Math.Round((mileage / MaxMileage) * 100);
            BatteryLevel -= percentage;

            if (BatteryLevel < 0)
            {
                BatteryLevel = 0;
            }
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public void ChangeStatus()
        {
            IsDamaged = !IsDamaged;
        }

        public override string ToString()
        {
            string status = IsDamaged ? "damaged" : "OK";
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {status}";
        }
    }

}

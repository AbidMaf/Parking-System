
using System;

namespace ParkingSystem
{
    class Vehicle
    {
        public string registrationNumber { get; set; }
        public string color;
        public VehicleType type;
        private DateTime entryTime = DateTime.Now;

        public Vehicle(string registrationNumber, string color, VehicleType type)
        {
            this.registrationNumber = registrationNumber;
            this.color = color;
            this.type = type;
        }

        public DateTime EntryTime
        {
            get { return entryTime; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class ParkingLot
    {
        private int totalLots;
        private Dictionary<int, Vehicle> vehicles = new Dictionary<int, Vehicle>();

        public void createParkingLot(int n)
        {
            totalLots = n;
            Console.WriteLine("Created a parking lot with " + n + " slots");
        }

        public void parkVehicle(Vehicle vehicle)
        {
            if (vehicles.Count == totalLots)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }
            for (int i = 1; i <= vehicles.Count + 2; i++)
            {
                if (!vehicles.ContainsKey(i))
                {
                    vehicles[i] = vehicle;
                    Console.WriteLine("Allocated slot number: " + i);
                    return;
                }
            }
        }

        public void leave(int slot)
        {
            if (slot < 1 || slot > totalLots)
            {
                Console.WriteLine("Invalid slot number");
                return;
            }
            vehicles.Remove(slot);
            Console.WriteLine("Slot number " + slot + " is free");
        }

        public void status()
        {
            Console.WriteLine("Slot\t No.\t\t Registration No\t\t Colour");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Key + "\t" + vehicle.Value.registrationNumber + "\t" + vehicle.Value.color);
            }
        }

        public void countVehicleType(VehicleType type)
        {
            int count = vehicles.Count(v => v.Value.type == type);
            Console.WriteLine(count);
        }

        public void getOddRegistrationNumber()
        {
            List<string> regNumbers = new List<string>();
            foreach (var item in vehicles)
            {
                String[] splittedRegNum = item.Value.registrationNumber.Split('-');
                if (int.Parse(splittedRegNum[1]) % 2 != 0)
                {
                    regNumbers.Add(item.Value.registrationNumber);
                }
            }

            if (regNumbers.Count == 0)
            {
                Console.WriteLine("Not found");
                return;
            }

            Console.WriteLine(string.Join(", ", regNumbers));
        }

        public void getEvenRegistrationNumber()
        {
            List<string> regNumbers = new List<string>();
            foreach (var item in vehicles)
            {
                String[] splittedRegNum = item.Value.registrationNumber.Split('-');
                if (int.Parse(splittedRegNum[1]) % 2 == 0)
                {
                    regNumbers.Add(item.Value.registrationNumber);
                }
            }
            if (regNumbers.Count == 0)
            {
                Console.WriteLine("Not found");
                return;
            }
            Console.WriteLine(string.Join(", ", regNumbers));
        }

        public void getPlatesByColor(String color)
        {
            List<string> plates = new List<string>();
            foreach (var item in vehicles)
            {
                if (item.Value.color == color)
                {
                    plates.Add(item.Value.registrationNumber);
                }
            }
            if (plates.Count == 0)
            {
                Console.WriteLine("Not found");
                return;
            }

            Console.WriteLine(string.Join(", ", plates));
        }

        public void getFilledSlotByColor(String color)
        {
            List<int> parkingSlots = new List<int>();
            foreach (var item in vehicles)
            {
                if (item.Value.color == color)
                {
                    parkingSlots.Add(item.Key);
                }
            }

            if (parkingSlots.Count == 0)
            {
                Console.WriteLine("Not found");
                return;
            }

            Console.WriteLine(string.Join(", ", parkingSlots));
        }

        public void getSlotByRegNumber(String regNumber)
        {
            foreach (var item in vehicles)
            {
                if (item.Value.registrationNumber == regNumber)
                {
                    Console.WriteLine(item.Key);
                    return;
                }
            }

            Console.WriteLine("Not found");
        }
    }
}

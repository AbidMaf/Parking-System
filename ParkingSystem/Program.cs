using System;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot();

            while (true)
            {
                Console.WriteLine("");
                Console.Write("$ ");
                var input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                var consoleInput = input.Split(' ');
                switch (consoleInput[0])
                {
                    case "create_parking_lot":
                        parkingLot.createParkingLot(int.Parse(consoleInput[1]));
                        break;
                    case "park":
                        if (Enum.TryParse<VehicleType>(consoleInput[3], true, out VehicleType vehicleType)) {
                            parkingLot.parkVehicle(new Vehicle(consoleInput[1], consoleInput[2], vehicleType));
                        }
                        else {
                            Console.WriteLine("Invalid Vehicle Type");
                        }
                        break;
                    case "leave":
                        parkingLot.leave(int.Parse(consoleInput[1]));
                        break;
                    case "status":
                        parkingLot.status();
                        break;
                    case "type_of_vehicles":
                        if (Enum.TryParse<VehicleType>(consoleInput[1], true, out VehicleType vehicleType1)) {
                            parkingLot.countVehicleType(vehicleType1);
                        }
                        else if (Enum.TryParse<VehicleType>(consoleInput[1], true, out VehicleType vehicleType2)) {
                            parkingLot.countVehicleType(vehicleType2);
                        }
                        else {
                            Console.WriteLine("Invalid Vehicle Type");
                        }
                        break;
                    case "registration_numbers_for_vehicles_with_ood_plate":
                        parkingLot.getOddRegistrationNumber();
                        break;
                    case "registration_numbers_for_vehicles_with_event_plate":
                        parkingLot.getEvenRegistrationNumber();
                        break;
                    case "registration_numbers_for_vehicles_with_colour":
                        parkingLot.getPlatesByColor(consoleInput[1]);
                        break;
                    case "slot_numbers_for_vehicles_with_colour":
                        parkingLot.getFilledSlotByColor(consoleInput[1]);
                        break;
                    case "slot_number_for_registration_number":
                        parkingLot.getSlotByRegNumber(consoleInput[1]);
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }
        }
    }
}

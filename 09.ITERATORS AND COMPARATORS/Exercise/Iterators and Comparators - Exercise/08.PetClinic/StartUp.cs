namespace _08.PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            List<Clinic> clinics = new List<Clinic>();
            List<Pet> pets = new List<Pet>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] commandData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];

                switch (command)
                {
                    case "Create":

                        if (commandData[1] == "Pet")
                        {
                            string name = commandData[2];
                            int age = int.Parse(commandData[3]);
                            string kind = commandData[4];
                            Pet pet = new Pet(name, age, kind);
                            pets.Add(pet);
                        }
                        else
                        {
                            string name = commandData[2];
                            int roomsCount = int.Parse(commandData[3]);
                            Clinic clinic = new Clinic();

                            try
                            {
                                clinic.CreateClinic(name, roomsCount);
                                clinics.Add(clinic);
                            }
                            catch (InvalidOperationException)
                            {
                                Console.WriteLine("Invalid Operation!");
                            }
                        }

                        break;

                    case "Add":
                        string petName = commandData[1];
                        string clinicName = commandData[2];

                        if (pets.Any(p => p.Name == petName) && clinics.Any(c => c.Name == clinicName))
                        {
                            var currentPet = pets.Find(p => p.Name == petName);
                            var currentClinic = clinics.Find(c => c.Name == clinicName);
                            Console.WriteLine(currentClinic.Add(currentPet));

                        }
                        else if (!pets.Any(p => p.Name == petName) || !clinics.Any(c => c.Name == clinicName))
                        {
                            Console.WriteLine("Invalid Operation!");
                        }

                        break;

                    case "Release":

                        string nameOfCurrentClinic = commandData[1];

                        if (clinics.Any(c => c.Name == nameOfCurrentClinic))
                        {
                            var currentClinic = clinics.Find(c => c.Name == nameOfCurrentClinic);
                            Console.WriteLine(currentClinic.Release());
                        }
                        else
                        {
                            Console.WriteLine("Invalid Operation!");
                        }

                        break;

                    case "HasEmptyRooms":
                        string clinicNameCurrent = commandData[1];

                        if (clinics.Any(c => c.Name == clinicNameCurrent))
                        {
                            var clinic = clinics.Find(c => c.Name == clinicNameCurrent);
                            Console.WriteLine(clinic.HasEmptyRooms());
                        }

                        break;

                    case "Print":
                        if (commandData.Length == 2)
                        {
                            string currentClinicName = commandData[1];

                            if (clinics.Any(c => c.Name == currentClinicName))
                            {
                                var clinic = clinics.Find(c => c.Name == currentClinicName);

                                foreach (var room in clinic)
                                {
                                    if (room == null)
                                    {
                                        Console.WriteLine("Room empty");
                                    }
                                    else
                                    {
                                        Console.WriteLine(room.PetInTheRoom);
                                    }
                                }
                            }
                        }
                        else
                        {
                            string currentClinicName = commandData[1];
                            int roomIndex = int.Parse(commandData[2]) - 1;

                            if (clinics.Any(c => c.Name == currentClinicName))
                            {
                                var clinic = clinics.Find(c => c.Name == currentClinicName);
                                var room = clinic.Rooms[roomIndex];

                                if (room == null)
                                {
                                    Console.WriteLine("Room empty");
                                }
                                else
                                {
                                    Console.WriteLine(room.PetInTheRoom);
                                }

                            }

                        }

                        break;
                }
            }
        }
    }
}

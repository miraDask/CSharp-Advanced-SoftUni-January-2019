namespace _01.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Room
    {
        private int capacity;

        public Room()
        {
            this.Beds = new List<string>();
            this.capacity = 3;
        }

        public List<string> Beds { get; set; } // holds patient name

        public bool AddPatient(string name)
        {
            if (this.Beds.Count < this.capacity)
            {
                this.Beds.Add(name);
                return true;
            }

            return false;
        }
    }

    public class Department
    {
        private int roomCapacity;

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
            this.roomCapacity = 20;
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public bool AddRoom(Room room)
        {
            if (this.Rooms.Count < this.roomCapacity)
            {
                this.Rooms.Add(room);
                return true;
            }

            return false;
        }
    }

    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Patients { get; set; }
    }

    public class Program
    {
        public static void Main()
        {

            var doctors = new List<Doctor>();

            var hospital = new List<Department>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Output")
                {
                    break;
                }

                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string departmentName = inputArgs[0];
                string doctorName = inputArgs[1] + " " + inputArgs[2];
                string patientName = inputArgs[3];

                if (!hospital.Any(x => x.Name == departmentName))
                {
                    hospital.Add(new Department(departmentName));
                }

                var department = hospital.Find(x => x.Name == departmentName);

                if (!department.Rooms.Any(x => x.Beds.Contains(patientName)))
                {

                    if (department.Rooms.Count == 0)
                    {
                        department.AddRoom(new Room());
                    }

                    int currentRoomIndex = department.Rooms.Count - 1;
                    Room currentRoom = department.Rooms[currentRoomIndex];
                    bool patientIsAdded = currentRoom.AddPatient(patientName);

                    if (!patientIsAdded)
                    {
                        bool newRoomIsAdded = department.AddRoom(new Room());

                        if (newRoomIsAdded)
                        {
                            department.Rooms[currentRoomIndex + 1].AddPatient(patientName);
                        }
                    }
                }

                if (!doctors.Any(d => d.Name == doctorName))
                {
                    doctors.Add(new Doctor(doctorName));
                }

                var doctor = doctors.Find(d => d.Name == doctorName);

                if (!doctor.Patients.Any(p => p == patientName))
                {
                    doctor.Patients.Add(patientName);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] outputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (outputArgs.Length == 1)
                {
                    string departmentName = outputArgs[0];

                    if (hospital.Any(d => d.Name == departmentName))
                    {
                        var department = hospital.Find(d => d.Name == departmentName);

                        foreach (var room in department.Rooms)
                        {
                            foreach (var patient in room.Beds)
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
                else 
                {
                    try
                    {
                        int roomNumber = int.Parse(outputArgs[1]);
                        string departmentName = outputArgs[0];

                        if (hospital.Any(d => d.Name == departmentName))
                        {
                            var department = hospital.Find(d => d.Name == departmentName);
                            int roomIndex = roomNumber - 1;

                            if (roomIndex >= 0 && roomIndex < department.Rooms.Count)
                            {
                                var room = department.Rooms[roomNumber - 1];

                                foreach (var patient in room.Beds.OrderBy(p => p))
                                {
                                    Console.WriteLine(patient);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        string doctorName = outputArgs[0] + " " + outputArgs[1];

                        if (doctors.Any(d => d.Name == doctorName))
                        {
                            var doctor = doctors.Find(d => d.Name == doctorName);

                            foreach (var patient in doctor.Patients.OrderBy(p => p))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
            }
        }
    }
}

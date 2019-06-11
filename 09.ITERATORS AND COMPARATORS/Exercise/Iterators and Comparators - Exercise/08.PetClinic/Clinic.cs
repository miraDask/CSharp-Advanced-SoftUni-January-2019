namespace _08.PetClinic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Clinic : IEnumerable<Room>
    {
        private int addCount;
        private int index;

        public string Name { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();

        public void CreateClinic(string name, int roomsCount)
        {
            if (roomsCount % 2 == 0)
            {
                throw new InvalidOperationException();
            }

            this.Name = name;
            this.Rooms = new List<Room>(new Room[roomsCount]);
        }

        public IEnumerator<Room> GetEnumerator()
        {
            for (int i = 0; i < this.Rooms.Count; i++)
            {
                yield return this.Rooms[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Add(Pet pet)
        {
            
            bool result = false;

            if (this.addCount == 0)
            {
                this.index = this.Rooms.Count / 2;
            }
            
            Room currentRoom = null;

            for (int i = 0; i < this.Rooms.Count; i++)
            {
                if (this.addCount % 2 == 0)
                {
                    this.index += this.addCount;

                    if (this.index > this.Rooms.Count - 1)
                    {
                        break;
                    }

                    currentRoom = this.Rooms[this.index];

                    if (currentRoom == null)
                    {
                        this.Rooms[this.index] = new Room();
                        this.Rooms[this.index].Fill(pet);
                        addCount++;
                        result = true;
                        break;
                    }
                    else
                    {
                        addCount++;
                        continue;
                    }
                }
                else
                {
                    this.index -= this.addCount;

                    if (this.index < 0)
                    {
                        break;
                    }

                    currentRoom = this.Rooms[this.index];

                    if (currentRoom == null)
                    {
                        this.Rooms[this.index] = new Room();
                        this.Rooms[this.index].Fill(pet);
                        addCount++;
                        result = true;
                        break;
                    }
                    else
                    {
                        addCount++;
                        continue;
                    }
                }
            }
            return result;
        }

        public bool Release()
        {
            int startIndex = this.Rooms.Count / 2;
            
            for (int i = startIndex; i < this.Rooms.Count; i++)
            {

                if (this.Rooms[i] != null)
                {
                    this.Rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < startIndex; i++)
            {

                if (this.Rooms[i] != null)
                {
                    this.Rooms[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.Rooms.Any(r => r == null);
        }
    }
}

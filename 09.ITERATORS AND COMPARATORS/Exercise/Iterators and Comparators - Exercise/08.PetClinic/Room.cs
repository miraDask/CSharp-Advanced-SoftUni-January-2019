namespace _08.PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Room
    {

        public Pet PetInTheRoom { get; set; } = new Pet();

        public void Fill(Pet pet)
        {
            this.PetInTheRoom.Name = pet.Name;
            this.PetInTheRoom.Age = pet.Age;
            this.PetInTheRoom.Kind = pet.Kind;
        }

    }
}

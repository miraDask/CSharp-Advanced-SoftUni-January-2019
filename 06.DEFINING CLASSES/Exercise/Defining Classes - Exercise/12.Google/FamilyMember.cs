using System.Collections.Generic;

namespace _12.Google
{
    public class FamilyMember
    {
        public FamilyMember(string name, string birthDay) 
        {
            Name = name;
            BirthDay = birthDay;
        }

        public string Name { get; set; } 

        public string BirthDay { get; set; } 
    }
}

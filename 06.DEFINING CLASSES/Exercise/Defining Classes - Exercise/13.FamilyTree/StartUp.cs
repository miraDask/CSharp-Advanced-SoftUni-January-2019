namespace _13.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> familyTree = new List<Person>();

            string firstLine = Console.ReadLine();

            Person personOfInterrest = new Person();

            if (char.IsDigit(firstLine[0]))
            {
                personOfInterrest.Birthday = firstLine;
            }
            else
            {
                personOfInterrest.Name = firstLine;
            }

            familyTree.Add(personOfInterrest);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (!input.Contains('-'))
                {
                    string[] personData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = personData[0] + " " + personData[1];
                    string birthday = personData[2];
                    Person familyMember;

                    if (familyTree.Any(x => x.Name == name))
                    {
                        familyMember = familyTree.Find(x => x.Name == name);
                        familyMember.Birthday = birthday;
                    }
                    else if (familyTree.Any(x => x.Birthday == birthday))
                    {
                        familyMember = familyTree.Find(x => x.Birthday == birthday);
                        familyMember.Name = name;
                    }
                    else
                    {
                        familyMember = new Person(name, birthday);
                        familyTree.Add(familyMember);
                    }
                }
                else
                {
                    string[] personData = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string firstArg = personData[0];
                    string secondArg = personData[1];
                    Person parent = new Person();
                    Person child = new Person();

                    // parent birthday -> child birthday or child name
                    if (char.IsDigit(firstArg[0]))
                    {
                        string parentBirthDate = firstArg;

                        if (!familyTree.Any(x => x.Birthday == parentBirthDate))
                        {
                            parent.Birthday = parentBirthDate;
                            familyTree.Add(parent);
                        }

                        parent = familyTree.Find(x => x.Birthday == parentBirthDate);
                    }
                    // parent birthday -> child birthday or child name
                    else if (!char.IsDigit(firstArg[0]))
                    {
                        string parentName = firstArg;

                        if (!familyTree.Any(x => x.Name == parentName))
                        {
                            parent.Name = parentName;
                            familyTree.Add(parent);
                        }

                        parent = familyTree.Find(x => x.Name == parentName);
                    }

                    if (char.IsDigit(secondArg[0])) //secondArg == child birthday
                    {
                        string childBirthDate = secondArg;

                        if (!familyTree.Any(x => x.Birthday == childBirthDate))
                        {
                            child.Birthday = childBirthDate;
                            familyTree.Add(child);
                        }

                        child = familyTree.Find(x => x.Birthday == childBirthDate);
                    }
                    else //secondArg == child name
                    {
                        string childName = secondArg;

                        if (!familyTree.Any(x => x.Name == childName))
                        {
                            child.Name = childName;
                            familyTree.Add(child);
                        }

                        child = familyTree.Find(x => x.Name == childName);
                    }

                    child.Parents.Add(parent);
                    parent.Children.Add(child);
                }
            }

            for (int i = 0; i < familyTree.Count; i++)
            {
                var person = familyTree[i];

                if (person.Name == null)
                {
                    var dublicatePerson = familyTree.Find(x => x.Birthday == person.Birthday && x != person);
                    int indexOfDublicate = familyTree.IndexOf(dublicatePerson);

                    if (indexOfDublicate < i)
                    {
                        dublicatePerson.Birthday = person.Birthday;
                        if (!dublicatePerson.Children.Any())
                        {
                            dublicatePerson.Children = person.Children;
                        }

                        if (!dublicatePerson.Parents.Any())
                        {
                            dublicatePerson.Parents = person.Parents;
                        }

                        familyTree.Remove(person);
                        i--;
                    }
                    else if (indexOfDublicate > i)
                    {
                        person.Name = dublicatePerson.Name;
                        if (!person.Children.Any())
                        {
                            person.Children = dublicatePerson.Children;
                        }

                        if (!person.Parents.Any())
                        {
                            person.Parents = dublicatePerson.Parents;
                        }

                        familyTree.Remove(dublicatePerson);
                    }
                }
            }

            Console.WriteLine(string.Join("", personOfInterrest));
        }
    }
}

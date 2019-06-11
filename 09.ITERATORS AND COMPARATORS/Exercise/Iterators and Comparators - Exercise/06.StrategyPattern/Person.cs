﻿namespace _06.StrategyPattern
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}

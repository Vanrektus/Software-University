﻿using System;

namespace PersonsInfo
{
    public class Person
    {
        //---------------------------Fields---------------------------
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        //---------------------------Properties---------------------------
        public string FirstName
        {
            get { return firstName; }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }

            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                salary = value;
            }
        }

        //---------------------------Constructors---------------------------
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Person(string firstName, string lastName, int age, decimal salary)
            : this(firstName, lastName, age)
        {
            this.Salary = salary;
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                percentage /= 2;
            }

            Salary += Salary * percentage / 100;
        }
    }
}

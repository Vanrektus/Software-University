using Newtonsoft.Json;
using System;

namespace JsonDemo
{
    public class Person
    {
        public Name Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public int Age { get; set; }
    }
}

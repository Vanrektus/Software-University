using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Name = new Name()
                {
                    FirstName = "Петър",
                    LastName = "Петров",
                },
                DateOfBirth = new DateTime(1998, 11, 11),
                Age = 23
            };

            var serializer = new XmlSerializer(typeof(Person));

            // Serialize
            using (var stream = new StreamWriter("person.xml"))
            {
                serializer.Serialize(stream, person);
            }

            // Deserialize

            string xml = File.ReadAllText("person.xml");
            Person newPerson = (Person)serializer.Deserialize(new StringReader(xml));
        }
    }
}

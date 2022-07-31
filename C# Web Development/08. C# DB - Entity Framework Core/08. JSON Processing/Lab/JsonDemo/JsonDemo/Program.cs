using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Threading.Tasks;

namespace JsonDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
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

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyy-MM-dd"
            };

            // System.Text.Json
            // string serializedPerson = JsonSerializer.Serialize(person);
            // Newtonsoft
            string serializedPerson = JsonConvert.SerializeObject(person, settings);

            await File.WriteAllTextAsync("person.json", serializedPerson);

            Person deserializedPerson = JsonConvert.DeserializeObject<Person>(serializedPerson, settings);

            Console.WriteLine(serializedPerson);
        }
    }
}

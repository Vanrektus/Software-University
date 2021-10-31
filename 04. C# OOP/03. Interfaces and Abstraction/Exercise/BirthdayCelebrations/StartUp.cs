using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //
            // 04. Border Control
            //
            //List<IIdentifiable> detainedIDs = new List<IIdentifiable>();

            //while (true)
            //{
            //    string[] inputInfo = Console.ReadLine()
            //        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //    if (inputInfo[0] == "End")
            //    {
            //        break;
            //    }

            //    if (inputInfo.Length == 3)
            //    {
            //        string citizenName = inputInfo[0];
            //        int age = int.Parse(inputInfo[1]);
            //        string citizenID = inputInfo[2];

            //        Citizen citizen = new Citizen(citizenName, age, citizenID);

            //        detainedIDs.Add(citizen);
            //    }
            //    else if (inputInfo.Length == 2)
            //    {
            //        string model = inputInfo[0];
            //        string robotID = inputInfo[1];

            //        Robot robot = new Robot(model, robotID);

            //        detainedIDs.Add(robot);
            //    }
            //}

            //string fakeID = Console.ReadLine();

            //detainedIDs = detainedIDs.Where(x => x.Id.EndsWith(fakeID)).ToList();

            //Console.WriteLine(string.Join(Environment.NewLine, detainedIDs.Select(x => x.Id)));



            //
            // 05. Birthday Celebrations
            //
            List<IBirthable> detainedTypes = new List<IBirthable>();

            while (true)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputInfo[0] == "End")
                {
                    break;
                }

                switch (inputInfo[0])
                {
                    case "Citizen":
                        string personName = inputInfo[1];
                        int age = int.Parse(inputInfo[2]);
                        string id = inputInfo[3];
                        string personBirthdate = inputInfo[4];

                        Citizen citizen = new Citizen(personName, age, id, personBirthdate);

                        detainedTypes.Add(citizen);
                        break;

                    case "Pet":
                        string petName = inputInfo[1];
                        string petBirthdate = inputInfo[2];

                        Pet pet = new Pet(petName, petBirthdate);

                        detainedTypes.Add(pet);
                        break;
                }
            }

            string year = Console.ReadLine();

            foreach (var item in detainedTypes)
            {
                if (item.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}

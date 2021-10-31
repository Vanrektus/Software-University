using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> detainedIDs = new List<IIdentifiable>();

            while (true)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputInfo[0] == "End")
                {
                    break;
                }

                if (inputInfo.Length == 3)
                {
                    string citizenName = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string citizenID = inputInfo[2];

                    Citizen citizen = new Citizen(citizenName, age, citizenID);

                    detainedIDs.Add(citizen);
                }
                else if (inputInfo.Length == 2)
                {
                    string model = inputInfo[0];
                    string robotID = inputInfo[1];

                    Robot robot = new Robot(model, robotID);

                    detainedIDs.Add(robot);
                }
            }

            string fakeID = Console.ReadLine();

            detainedIDs = detainedIDs.Where(x => x.Id.EndsWith(fakeID)).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, detainedIDs.Select(x => x.Id)));
        }
    }
}

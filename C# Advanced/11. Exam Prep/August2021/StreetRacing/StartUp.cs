using System;

namespace StreetRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize Race
            Race race = new Race("RockPort Race", "Sprint", 1, 4, 150);

            //Initialize Car
            Car car = new Car("BMW", "320ci", "NFS2005", 150, 1450);

            //Print car
            Console.WriteLine(car);
            //Make: BMW
            //Model: 320ci
            //License Plate: NFS2005
            //Horse Power: 150
            //Weight: 1450

            //Add car
            race.Add(car);

            //Remove car
            Console.WriteLine(race.Remove("NFS2005")); // True

            Car carOne = new Car("BMW", "320cd", "NFS2007", 150, 1350);
            Car carTwo = new Car("Audi", "A3", "NFS2004", 131, 1300);
            Car carThree = new Car("Audi", "S3", "NFS2004", 147, 1450);

            //Add cars
            race.Add(carOne);
            race.Add(carTwo);
            race.Add(carThree);

            //Find participant
            Console.WriteLine(race.FindParticipant("NFS2007")); // True
            race.FindParticipant("NFS2009"); // False

            //GetMostPowerfulCar
            Console.WriteLine(race.GetMostPowerfulCar());
            //Make: BMW
            //Model: 320cd
            //License Plate: NFS2007
            //Horse Power: 150
            //Weight: 1350

            Console.WriteLine(race.Count); // 3

            //Print Race report
            race.Report();
            //Race: RockPort Race - Type: Sprint (Laps: 1)
            //Make: BMW
            //Model: 320cd
            //License Plate: NFS2007
            //Horse Power: 150
            //Weight: 1350
            //Make: Audi
            //Model: A3
            //License Plate: NFS2004
            //Horse Power: 131
            //Weight: 1300
        }
    }
}

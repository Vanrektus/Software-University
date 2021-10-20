﻿using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box;

            try
            {
                box = new Box(length, width, height);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            Console.WriteLine($"Surface Area - {box.SurfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea:f2}");
            Console.WriteLine($"Volume - {box.Volume:f2}");
        }
    }
}

using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            //string stolenInfoResult = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            string analyzedInfoResult = spy.AnalyzeAccessModifiers("Hacker");

            //Console.WriteLine(stolenInfoResult);
            Console.WriteLine(analyzedInfoResult);
        }
    }
}

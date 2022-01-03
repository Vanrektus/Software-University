using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string stolenInfoResult = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(stolenInfoResult);

            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine();

            string analyzedInfoResult = spy.AnalyzeAccessModifiers("Hacker");
            Console.WriteLine(analyzedInfoResult);

            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine();

            string revealedInfoResult = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(revealedInfoResult);

            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine();

            string collectedInfoResult = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(collectedInfoResult);
        }
    }
}

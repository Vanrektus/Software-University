using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        //---------------------------Constructors---------------------------
        public Smartphone()
        {

        }

        //---------------------------Methods---------------------------
        public string Call(string number)
        {
            if (number.Any(x => !char.IsDigit(x)) || (number.Length != 10 && number.Length != 7))
            {
                return "Invalid number!";
            }

            if (number.Length == 10)
            {
                return $"Calling... {number}";
            }
            else
            {
                return $"Dialing... {number}";
            }
        }

        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }
    }
}

using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        //---------------------------Constructors---------------------------
        public StationaryPhone()
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
    }
}

using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        //---------------------------Constructors---------------------------
        public Dog(string name, string favouriteFood)
            : base(name, favouriteFood)
        {

        }

        //---------------------------Methods---------------------------
        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine("DJAAF");

            return sb.ToString().TrimEnd();
        }
    }
}

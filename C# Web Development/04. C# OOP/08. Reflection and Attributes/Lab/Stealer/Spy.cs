using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        //---------------------------Methods---------------------------
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            foreach (FieldInfo currentField in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{currentField.Name} = {currentField.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        //---------------------------Methods---------------------------
        //public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        //{
        //    Type classType = Type.GetType(classToInvestigate);
        //    FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        //    StringBuilder sb = new StringBuilder();

        //    Object classInstance = Activator.CreateInstance(classType, new object[] { });

        //    sb.AppendLine($"Class under investigation: {classToInvestigate}");

        //    foreach (FieldInfo currentField in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
        //    {
        //        sb.AppendLine($"{currentField.Name} = {currentField.GetValue(classInstance)}");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public string AnalyzeAccessModifiers(string classToInvestigate)
        //{
        //    Type classType = Type.GetType("Stealer." + classToInvestigate);

        //    FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        //    MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
        //    MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        //    StringBuilder sb = new StringBuilder();

        //    foreach (FieldInfo currentField in classFields)
        //    {
        //        sb.AppendLine($"{currentField.Name} must be private!");
        //    }

        //    foreach (MethodInfo currentMethod in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        //    {
        //        sb.AppendLine($"{currentMethod.Name} have to be public!");
        //    }

        //    foreach (MethodInfo currentMethod in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        //    {
        //        sb.AppendLine($"{currentMethod.Name} have to be private!");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        public string RevealPrivateMethods(string classToInvestigate)
        {
            Type classType = Type.GetType(classToInvestigate);

            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {classToInvestigate}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo currentMethod in classMethods)
            {
                sb.AppendLine(currentMethod.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}

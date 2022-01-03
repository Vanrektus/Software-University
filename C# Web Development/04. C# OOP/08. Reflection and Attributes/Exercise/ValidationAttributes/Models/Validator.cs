using System.Reflection;
using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        //---------------------------Methods---------------------------
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo currentProperty in properties)
            {
                object[] attributes = currentProperty
                    .GetCustomAttributes(false);

                foreach (MyValidationAttribute currentAttribute in attributes)
                {
                    bool isValid = currentAttribute.IsValid(currentProperty.GetValue(obj));

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            // ANOTHER WAY
            //foreach (PropertyInfo currentProperty in properties)
            //{
            //    MyValidationAttribute currentAttribute = (MyValidationAttribute)currentProperty
            //        .GetCustomAttribute(typeof(MyValidationAttribute), false);

            //    bool isValid = currentAttribute.IsValid(currentProperty.GetValue(obj));

            //    if (!isValid)
            //    {
            //        return false;
            //    }
            //}

            return true;
        }
    }
}

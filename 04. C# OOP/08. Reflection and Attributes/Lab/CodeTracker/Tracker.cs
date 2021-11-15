using System;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        //---------------------------Methods---------------------------
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (MethodInfo currentMethod in methods)
            {
                object[] attributes = currentMethod.GetCustomAttributes(false);

                foreach (object currentAttribute in attributes)
                {
                    AuthorAttribute author = currentAttribute as AuthorAttribute;

                    if (author != null)
                    {
                        Console.WriteLine($"{currentMethod.Name} is written by {author.Name}");
                    }
                }
            }

            //foreach (MethodInfo currentMethod in methods)
            //{
            //    if (currentMethod.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
            //    {
            //        object[] attributes = currentMethod.GetCustomAttributes(false);

            //        foreach (AuthorAttribute currentAttribute in attributes)
            //        {
            //            Console.WriteLine($"{currentMethod.Name} is written by {currentAttribute.Name}");
            //        }
            //    }
            //}
        }
    }
}

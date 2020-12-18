using System;
using System.Linq;
using System.Reflection;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;

            try
            {
                Assembly asm = Assembly.LoadFrom(assemblyName);
                var types = new DynamicList<Type>();
                foreach (Type type in asm.GetTypes().Where(typeVal => Attribute.IsDefined(typeVal, typeof(ExportClass)) && typeVal.IsPublic && typeVal.IsClass))
                {
                    types.Add(type);
                }
                foreach (Type type in types)
                {
                    Console.WriteLine(type.FullName);
                }
                
            }
            catch (Exception e) {
                Console.WriteLine("Exception");
            }
        }
    }
}

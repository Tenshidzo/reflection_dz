using System.Reflection;

namespace reflection_dz
{
    class MyClass
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public string Concatenate(string a, string b)
        {
            return a + b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 1
            //Assembly assembly = typeof(string).Assembly;
            //Type[] exceptionTypes = assembly.GetTypes()
            //                                 .Where(t => t.IsSubclassOf(typeof(Exception)))
            //                                 .ToArray();

            //foreach (Type exceptionType in exceptionTypes)
            //{
            //    Console.WriteLine(exceptionType.FullName);
            //}

            //task 2
            //Type stringType = typeof(string);
            //Console.WriteLine("Методы:");
            //foreach (MethodInfo method in stringType.GetMethods())
            //{
            //    Console.WriteLine(method.Name);
            //}

            //Console.WriteLine("\nПоля:");
            //foreach (FieldInfo field in stringType.GetFields())
            //{
            //    Console.WriteLine(field.Name);
            //}

            //Console.WriteLine("\nСвойства:");
            //foreach (PropertyInfo property in stringType.GetProperties())
            //{
            //    Console.WriteLine(property.Name);
            //}

            //Console.WriteLine("\nИнтерфейсы:");
            //foreach (Type interfaceType in stringType.GetInterfaces())
            //{
            //    Console.WriteLine(interfaceType.FullName);
            //}

            //task 3
            Type myClassType = typeof(MyClass);
            MethodInfo[] methods = myClassType.GetMethods();
            Console.WriteLine("Список методов:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.Write("Введите имя метода для выполнения: ");
            string methodName = Console.ReadLine();
            MethodInfo selectedMethod = methods.FirstOrDefault(m => m.Name == methodName);
            if (selectedMethod != null)
            {
                ParameterInfo[] parameters = selectedMethod.GetParameters();
                object[] arguments = new object[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"Введите значение параметра {parameters[i].Name}: ");
                    string value = Console.ReadLine();
                    arguments[i] = Convert.ChangeType(value, parameters[i].ParameterType);
                }

                MyClass instance = new MyClass();
                object result = selectedMethod.Invoke(instance, arguments);

                Console.WriteLine($"Результат выполнения метода: {result}");
            }
            else
            {
                Console.WriteLine("Метод не найден.");
            }
        }
    }
}

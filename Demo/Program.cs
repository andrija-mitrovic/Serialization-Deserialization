using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee()
            {
                Id = 1,
                FirstName = "Mark",
                LastName = "Twain",
                Gender = "Male",
                PhoneNumber = "+358597545",
                Email = "marktwain",
                City = "New York",
                Country = "USA"
            };

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\Projects\ConsoleApp\Example.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, employee);
            stream.Close();

            stream = new FileStream(@"D:\Projects\ConsoleApp\Example.txt", FileMode.Open, FileAccess.Read);
            Employee employeeNew = (Employee)formatter.Deserialize(stream);

            Console.WriteLine(employeeNew.Id);
            Console.WriteLine(employeeNew.FirstName);
            Console.WriteLine(employeeNew.LastName);
            Console.WriteLine(employeeNew.Gender);
            Console.WriteLine(employeeNew.PhoneNumber);
            Console.WriteLine(employeeNew.Email);
            Console.WriteLine(employeeNew.City);
            Console.WriteLine(employeeNew.Country);
            Console.ReadLine();
        }
    }
}

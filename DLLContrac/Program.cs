using DLLContrac.Entities;
using DLLContrac.Entities.Enums;
using System;
using System.Globalization;

namespace DLLContrac {
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter department's name: ");
            string department = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            string level = Console.ReadLine();
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine());


            Department dep = new Department();
            dep.Name = department;

            Worker worker = new Worker(name, Enum.Parse<WorkerLevel>(level), baseSalary, dep);

            Console.WriteLine();
            Console.Write("How many contracts to this worker? ");
            int nContracts = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nContracts; i++) {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Value Per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration(hours): ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine();

                HourContract contract = new HourContract(data, valuePerHour, duration);
                worker.AddContract(contract);
            }
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string dataContract = Console.ReadLine();
            int month = int.Parse(dataContract.Substring(0, 2));
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            int year = int.Parse(dataContract.Substring(3));
            double valorFinal = worker.Income(year, month);
            Console.WriteLine($"Income for {dataContract}: R${valorFinal.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}

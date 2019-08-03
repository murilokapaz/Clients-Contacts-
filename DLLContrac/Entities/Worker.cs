using System;
using System.Collections.Generic;
using DLLContrac.Entities.Enums;

namespace DLLContrac.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> HourContracts { get; set; } = new List<HourContract>() { };


        public Worker(){}

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }


        public void AddContract(HourContract contract)
        {
            HourContracts.Add(contract);
        } 
        public void RemoveContract(HourContract contract)
        {
            HourContracts.Remove(contract);
        }
        public double Income(int year, int month)
        {
            double TotalSalary = BaseSalary;
            foreach(HourContract c in HourContracts)
            {
                if (c.Date.Month == month && c.Date.Year == year) TotalSalary += c.TotalValue();
            }
            return TotalSalary;
        }
    }
}

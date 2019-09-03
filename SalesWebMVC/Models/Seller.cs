using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirtDate { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }
        public Seller(int id, string name, string email, double baseSalary, DateTime birtDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirtDate = birtDate;
            Department = department;
        }

        public void AddSales(SalesRecord sales)
        {
            Sales.Add(sales);
        }
        public void RemoveSales(SalesRecord sales)
        {
            Sales.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            double r = Sales.Where(sales => sales.Date >= initial &&
              sales.Date <= final).Sum(sales => sales.Amount);
            return r;

        }


    }
}

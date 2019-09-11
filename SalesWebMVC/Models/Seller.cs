using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        //[Required(ErrorMessage = "Please enter seller name.")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        //[Required(ErrorMessage = "Please enter seller e-mail.")]
        public string Email { get; set; }

        [Display(Name = "Base Salary")]
        //[Required(ErrorMessage = "Please enter seller Base Salary.")]
        public double BaseSalary { get; set; }

        [Display(Name = "Birthday")]
        public DateTime BirtDate { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
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

        public Seller(string name, string email, double baseSalary, DateTime birtDate, Department department)
        {
            
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

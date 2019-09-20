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
        [Required(ErrorMessage = "{0} required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} Deve ser maior que {1}")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} required.")]
        [EmailAddress(ErrorMessage = "Enter a valid e-mail.")]
        public string Email { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} required.")]
        [Range(100.00, 5000.00, ErrorMessage = "{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
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

using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.sellers.ToList();
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.sellers.Include(obj => obj.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.sellers.Find(id);
            _context.sellers.Remove(obj);
            _context.SaveChanges();
        }


    }
}

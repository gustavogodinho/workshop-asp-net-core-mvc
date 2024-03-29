﻿using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _context;

        public SalesRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            // Para Agrupar usar Igrouping<>

            var result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }


            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }

        public List<NoSales> SellersNoSales()
        {

            //List<NoSales> noSales = new List<NoSales>();
            ////var query = from sl in _context.Sellers
            ////            join dp in _context.Department on sl.DepartmentId equals dp.Id
            ////            select new { sl.Name };

            //noSales = from s in _context.Sellers
            //          join v in _context.SalesRecords on s.Id equals v.Seller.Id into leftSales
            //          from v2 in leftSales.DefaultIfEmpty()
            //          where v2.Id == null
            //          join d in _context.Department on s.DepartmentId equals d.Id
            //          select new { NameSeller = s.Name, s.Email, d.Name };


            return _context.Query<NoSales>(
                $@"select   s.Name as NameSeller,
                            s.Email,
                         d.Name
                 from sellers s 
                  left join salesRecords sr
                    on s.Id = sr.SellerId
                  inner join Department d
                    on s.DepartmentId = d.Id
                  and sr.Id is null"
                ).ToList();
               

            //return noSales;
        }

      

    }
}

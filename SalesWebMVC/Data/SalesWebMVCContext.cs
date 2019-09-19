using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace SalesWebMVC.Models
{
    public class SalesWebMVCContext : DbContext
    {
        private IDbConnection Conexao { get; set; }

        public SalesWebMVCContext(DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }

        public IEnumerable<TEntity> Query<TEntity>(string query)
        {
            if (Conexao == null)
                Conexao = new SqlConnection(Database.GetDbConnection().ConnectionString);

            if (Conexao.State != ConnectionState.Open)
                Conexao.Open();

            return Conexao.Query<TEntity>($"{query}", commandType: CommandType.Text, commandTimeout: int.MaxValue);
        }


    }
}

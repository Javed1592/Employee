using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Employee.Context
{
    public class EMPContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = tcp:ctlserver.database.windows.net, 1433; Initial Catalog = db_test; Persist Security Info = False; User ID = shaik1592; Password =Sh@ik123; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
    }
}
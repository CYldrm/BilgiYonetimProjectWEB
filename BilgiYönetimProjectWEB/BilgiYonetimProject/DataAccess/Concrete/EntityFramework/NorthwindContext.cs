using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Db tabloları ile classları bağlamak
    public class NorthwindContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
                                          Database=BilgiYonetim;Trusted_Connection=true;Max Pool Size=200;");
        }
        
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionGroup> QuestionGroup { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Dealer> Dealer { get; set; }         // Dealer tablosu
        public DbSet<DealerPoint> DealerPoint { get; set; } // DealerPoint tablosu
        public DbSet<Visitor> Visitor { get; set; }       // Visitor tablosu
        public DbSet<Admin> Admin { get; set; }           // Admin tablosu
        public DbSet<CarModel> CarModel { get; set; }
    }
}

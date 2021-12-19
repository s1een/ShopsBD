using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopsDB
{
    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>()
                .Property(e => e.Street_name)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Building_number)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Cellphone_number_1)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Cellphone_number_2)
                .IsUnicode(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}

namespace ExamenApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Examen : DbContext
    {
        public Examen()
            : base("name=Examen_db")
        {
        }

        public virtual DbSet<area> area { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<area>()
                .Property(e => e.nom_area)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .HasMany(e => e.empleado)
                .WithRequired(e => e.area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<empleado>()
                .Property(e => e.nom_empleado)
                .IsUnicode(false);
        }
    }
}

namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ThiASPDbContext : DbContext
    {
        public ThiASPDbContext()
            : base("name=ThiASPDbContext")
        {
        }

        public virtual DbSet<tblCat> tblCats { get; set; }
        public virtual DbSet<tblPro> tblProes { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCat>()
                .HasMany(e => e.tblProes)
                .WithOptional(e => e.tblCat)
                .WillCascadeOnDelete();

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Username)
                .IsUnicode(false);
        }
    }
}

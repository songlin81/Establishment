using System.Data.Entity;

namespace EntityWork
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<ModelFilterVariant> ModelFilterVariants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                .Property(e => e.ModelId)
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.ProductClassID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.ProductTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<ModelFilterVariant>()
                .Property(e => e.MarketId)
                .IsUnicode(false);

            modelBuilder.Entity<ModelFilterVariant>()
                .Property(e => e.ModelId)
                .IsUnicode(false);

            modelBuilder.Entity<ModelFilterVariant>()
                .Property(e => e.VariantId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ModelFilterVariant>()
                .Property(e => e.ProductClassID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ModelFilterVariant>()
                .Property(e => e.FamilyId)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

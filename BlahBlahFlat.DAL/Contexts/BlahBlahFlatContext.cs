using BlahBlahFlat.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BlahBlahFlat.DAL.Contexts
{
    /// <summary>
    /// Represents context for working with the BlahBlahFlat database.
    /// </summary>
    public sealed class BlahBlahFlatContext : DbContext
    {
        #region Entities

        /// <inheritdoc />
        public DbSet<Placement> Placements { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Used for ef bulk.
        /// </summary>
        public BlahBlahFlatContext(DbContextOptions options) : base(options)
        {

        }

        public BlahBlahFlatContext()
        {
        }
        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion

    }
}

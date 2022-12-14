using BlahBlahFlat.Domain.Enum;
using BlahBlahFlat.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace BlahBlahFlat.Domain.Entities.Concrete
{
    public class Placement : IBaseEntity<int>
    {
        /// <inheritdoc />
        public int Id { get; set; }

        /// <summary>
        /// Placement type
        /// </summary>
        public PlacementType Type { get; set; }

        /// <summary>
        /// Description of flat
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Host contacts
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// Longitude of placement
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Latitude of placement
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// String address of placement
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Period
        /// </summary>
        public PlacementPeriod Period { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
    }
}
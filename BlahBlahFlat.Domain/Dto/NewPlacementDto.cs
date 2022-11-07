using BlahBlahFlat.Domain.Enum;

namespace BlahBlahFlat.Domain.Dto
{
    /// <summary>
    /// DTO of Flat entity 
    /// </summary>
    public class NewPlacementDto
    {
        /// <summary>
        /// Placement type
        /// </summary>
        public PlacementType Type { get; set; }

        /// <summary>
        /// Decription of flat
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Host contacts
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// Coordinates of placement
        /// </summary>
        public decimal Coordinates { get; set; }

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
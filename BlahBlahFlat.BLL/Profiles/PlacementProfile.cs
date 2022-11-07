using AutoMapper;
using BlahBlahFlat.Domain.Dto;
using BlahBlahFlat.Domain.Entities.Concrete;

namespace BlahBlahFlat.BLL.Profiles
{
    /// <summary>
    /// Profile for flat entity mappings.
    /// </summary>
    public class PlacementProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the FlatsProfile class.
        /// </summary>
        public PlacementProfile()
        {
            CreateMap<Placement, PlacementDto>()
                .ReverseMap();
            CreateMap<Placement, NewPlacementDto>()
                .ReverseMap();
            CreateMap<PlacementDto, NewPlacementDto>()
                .ReverseMap();
        }
    }
}

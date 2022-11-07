using BlahBlahFlat.Domain.Dto;
using BlahBlahFlat.Domain.Enum;

namespace BlahBlahFlat.BLL.Services
{
    /// <summary>
    /// Service for CRUD procedures with flats entities.
    /// </summary>
    public interface IPlacementService
    {
        /// <summary>
        /// Get Placement by id request.
        /// </summary>
        /// <param name="id">Flat Id.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="PlacementDto"/></returns>
        Task<PlacementDto> GetPlacement(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Get Placements request.
        /// </summary>
        /// <param name="city">City.</param>
        /// <param name="period">Period.</param>
        /// <param name="minPrice">Min price.</param>
        /// <param name="maxPrice">Max price.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="PlacementDto"/></returns>
        Task<IEnumerable<PlacementDto>> GetPlacements(string city, PlacementPeriod? period, decimal? minPrice, decimal? maxPrice, CancellationToken cancellationToken);

        /// <summary>
        /// Add new placement request.
        /// </summary>
        /// <param name="placement"><see cref="NewPlacementDto"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="PlacementDto"/></returns>
        Task<PlacementDto> AddPlacement(NewPlacementDto placement, CancellationToken cancellationToken);

        /// <summary>
        /// Update placement request.
        /// </summary>
        /// <param name="placement"><see cref="PlacementDto"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="PlacementDto"/></returns>
        Task<PlacementDto> UpdatePlacement(PlacementDto placement, CancellationToken cancellationToken);

        /// <summary>
        /// Delete placement request.
        /// </summary>
        /// <param name="id">Placement id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="PlacementDto"/></returns>
        Task DeletePlacement(int id, CancellationToken cancellationToken);
    }
}
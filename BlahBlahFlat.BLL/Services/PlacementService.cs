using AutoMapper;
using BlahBlahFlat.DAL.Contexts;
using BlahBlahFlat.Domain.Dto;
using BlahBlahFlat.Domain.Entities.Concrete;
using BlahBlahFlat.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace BlahBlahFlat.BLL.Services
{
    /// <inheritdoc />
    public class PlacementService : IPlacementService
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly BlahBlahFlatContext _dbContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the FlatService class.
        /// </summary>
        /// <param name="dbContext"><see cref="BlahBlahFlatContext"/></param>
        /// <param name="mapper"><see cref="IMapper"/></param>
        public PlacementService(IMapper mapper, BlahBlahFlatContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<PlacementDto> GetPlacement(int id, CancellationToken cancellationToken)
        {
            var placement = await _dbContext.Placements.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            var model = _mapper.Map<PlacementDto>(placement);

            return model;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<PlacementDto>> GetPlacements(string? city, PlacementPeriod? period, decimal? minPrice, decimal? maxPrice, CancellationToken cancellationToken)
        {
            var query = _dbContext.Placements.AsNoTracking();

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(x => x.City.Equals(city));
            }

            if (period.HasValue)
            {
                query = query.Where(x => x.Period == period);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(x => x.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= maxPrice);
            }

            var flats = await query.ToArrayAsync(cancellationToken);

            var model = _mapper.Map<IEnumerable<PlacementDto>>(flats);

            return model;
        }

        /// <inheritdoc />
        public async Task<PlacementDto> AddPlacement(NewPlacementDto placement, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Placement>(placement);

            await _dbContext.Placements.AddAsync(model, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var newPlacement = _mapper.Map<PlacementDto>(placement);
            newPlacement.Id = model.Id;

            return newPlacement;
        }

        /// <inheritdoc />
        public async Task<PlacementDto> UpdatePlacement(int id, NewPlacementDto placement, CancellationToken cancellationToken)
        {
            var model = await _dbContext.Placements.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            _mapper.Map(placement, model);

            _dbContext.Placements.Update(model);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<PlacementDto>(placement);

            return result;
        }

        /// <inheritdoc />
        public async Task DeletePlacement(int id, CancellationToken cancellationToken)
        {
            var model = await _dbContext.Placements.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (model != null)
            {
                _dbContext.Placements.Remove(model);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        #endregion
    }
}

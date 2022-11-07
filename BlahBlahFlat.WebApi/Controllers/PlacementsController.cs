using BlahBlahFlat.BLL.Services;
using BlahBlahFlat.Domain.Dto;
using BlahBlahFlat.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace BlahBlahFlat.WebApi.Controllers;

[Route("api/placements")]
[ApiController]
public class PlacementsController : ControllerBase
{
    readonly IPlacementService _placementService;

    public PlacementsController(IPlacementService placementService)
    {
        _placementService = placementService;
    }

    #region CRUD

    /// <summary>
    /// Get placement by id.
    /// </summary>
    /// <example>GET: api/placement/1</example>
    /// <param name="id">Placement Id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Flat.</returns>
    /// <response code="200">OK: placement.</response>
    /// <response code="404">Not found: If placement is missing.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(PlacementDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(Application.Json)]
    public async Task<IActionResult> GetPlacementAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _placementService.GetPlacement(id, cancellationToken);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get placements 
    /// </summary>
    /// <example>GET: api/placements</example>
    /// <param name="city">City.</param>
    /// <param name="period">Period.</param>
    /// <param name="minPrice">Min price.</param>
    /// <param name="maxPrice">Max price.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Placement.</returns>
    /// <response code="200">OK: Placements.</response>
    [HttpGet("")]
    [ProducesResponseType(typeof(PlacementDto), StatusCodes.Status200OK)]
    [Produces(Application.Json)]
    public async Task<IActionResult> GetPlacementsAsync([FromQuery] PlacementPeriod? period, [FromQuery] string? city, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, CancellationToken cancellationToken)
    {
        var result = await _placementService.GetPlacements(city, period, minPrice, maxPrice, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Add Placements 
    /// </summary>
    /// <example>POST: api/placements</example>
    /// <param name="placement"><see cref="NewPlacementDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Placement.</returns>
    /// <response code="200">OK: Placement.</response>
    [HttpPost("")]
    [ProducesResponseType(typeof(PlacementDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(Application.Json)]
    public async Task<IActionResult> AddPlacementAsync([FromBody] NewPlacementDto placement, CancellationToken cancellationToken)
    {
        var result = await _placementService.AddPlacement(placement, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Update placement
    /// </summary>
    /// <example>GET: api/placements</example>
    /// <param name="placement"><see cref="PlacementDto"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Placement.</returns>
    /// <response code="200">OK: Placement.</response>
    /// <response code="404">Not found: If placement is missing.</response>
    [HttpPut("")]
    [ProducesResponseType(typeof(PlacementDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(Application.Json)]
    public async Task<IActionResult> UpdatePlacementsAsync([FromBody] PlacementDto placement, CancellationToken cancellationToken)
    {
        var result = await _placementService.UpdatePlacement(placement, cancellationToken);

        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    #endregion
}
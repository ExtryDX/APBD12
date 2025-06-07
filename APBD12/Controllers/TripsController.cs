using APBD12.DTOs;
using APBD12.Models;
using APBD12.Services;
// using APBD12.DAL;
using Microsoft.AspNetCore.Mvc;

namespace APBD12.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    ITripsService _tripsService;
    
    public TripsController(ITripsService tripsService)
    {
        _tripsService = tripsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTripsPage([FromQuery]int pageNumber, CancellationToken cancellationToken)
    {
        var tripPages = await _tripsService.GetTripsPageOrderByTripFromDescAsync(pageNumber, cancellationToken);
        return Ok(tripPages);
    }
    
}
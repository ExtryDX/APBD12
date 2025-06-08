using APBD12.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD12.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientsService _clientsService;

    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }
    
    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClientByIdIfExists(int idClient, CancellationToken cancellationToken)
    {
        var client = await _clientsService.GetClientById(idClient, cancellationToken);
        if (client != null)
        {
            var clientHasAnyTrip = await _clientsService.AnyTripByClientIdAsync(idClient, cancellationToken);
            if (clientHasAnyTrip)
            {
                return BadRequest("Client has a trip, cannot delete it.");
            }

            return NotFound("Client deleted");

        }
        return NotFound();
    }
    
}
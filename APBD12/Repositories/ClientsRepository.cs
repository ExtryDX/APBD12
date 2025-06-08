using APBD12.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APBD12.Repositories;

public class ClientsRepository : IClientsRepository
{
    private readonly TripsDbContext _context;

    public ClientsRepository(TripsDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> AnyTripByClientIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.ClientTrips.AnyAsync(ct => ct.IdClient == id, cancellationToken);
    }

    public async Task<Client?> GetClientByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Clients.FirstOrDefaultAsync(ct => ct.IdClient == id, cancellationToken);
    }
    
    public async Task DeleteClientAsync(Client client, CancellationToken cancellationToken)
    {
        var deletedClient = _context.Clients.Remove(client);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
using APBD12.Models;

namespace APBD12.Services;

public interface IClientsService
{
    Task DeleteClientById(Client client, CancellationToken cancellationToken);
    Task<Client?> GetClientById(int idClient, CancellationToken cancellationToken);
    Task<bool> AnyTripByClientIdAsync(int clientId, CancellationToken cancellationToken);
}
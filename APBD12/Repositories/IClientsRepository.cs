using APBD12.Models;

namespace APBD12.Repositories;

public interface IClientsRepository
{
    Task<bool> AnyTripByClientIdAsync(int id, CancellationToken cancellationToken);
    Task DeleteClientAsync(Client client, CancellationToken cancellationToken);

    Task<Client?> GetClientByIdAsync(int id, CancellationToken cancellationToken);
}
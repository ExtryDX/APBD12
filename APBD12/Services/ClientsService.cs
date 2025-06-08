using APBD12.Models;
using APBD12.Repositories;

namespace APBD12.Services;

public class ClientsService : IClientsService
{
    private readonly IClientsRepository _clientsRepository;

    public ClientsService(IClientsRepository clientsRepository)
    {
        _clientsRepository = clientsRepository;
    }

    public async Task DeleteClientById(Client client, CancellationToken cancellationToken)
    {
        await _clientsRepository.DeleteClientAsync(client, cancellationToken);
    }

    public async Task<Client?> GetClientById(int idClient, CancellationToken cancellationToken)
    {
        return await _clientsRepository.GetClientByIdAsync(idClient, cancellationToken);
    }

    public async Task<bool> AnyTripByClientIdAsync(int clientId, CancellationToken cancellationToken)
    {
        return await _clientsRepository.AnyTripByClientIdAsync(clientId, cancellationToken);
    }
    
    
}
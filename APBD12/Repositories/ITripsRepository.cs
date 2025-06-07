using APBD12.DTOs;
using APBD12.Models;

namespace APBD12.Repositories;

public interface ITripsRepository
{
    Task<List<Trip>> GetTripsPageOrderByTripFromDescAsync(int pageNumber, CancellationToken cancellationToke);
    Task<int> GetTripsCount();
}
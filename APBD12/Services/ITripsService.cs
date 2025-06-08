using APBD12.DTOs;

namespace APBD12.Services;

public interface ITripsService
{
    Task<TripPage> GetTripsPageOrderByTripFromDescAsync(int pageNumber, CancellationToken cancellationToke);
    
}
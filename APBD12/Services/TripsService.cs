using APBD12.DTOs;
using APBD12.Repositories;

namespace APBD12.Services;


public class TripsService : ITripsService
{
    private readonly ITripsRepository _tripsRepository;
    private const int PAGE_ENTRIES = 10;

    public TripsService(ITripsRepository tripsRepository)
    {
        _tripsRepository = tripsRepository;
    }
    
    public async Task<TripPage> GetTripsPageOrderByTripFromDescAsync(int pageNumber, CancellationToken cancellationToke) {
        
        var trips = await _tripsRepository.GetTripsPageOrderByTripFromDescAsync(pageNumber, cancellationToke);
        var tripsCount = await _tripsRepository.GetTripsCount();
        var numberOfPages = (int)Math.Ceiling((double)trips.Count / PAGE_ENTRIES);
        
        var tripsPage = trips.Select(t => new TripDTO
        {
            Name = t.Name,
            Description = t.Description,
            DateFrom = t.DateFrom,
            DateTo = t.DateTo,
            MaxPeople = t.MaxPeople,
            Countries = t.IdCountries.Select(c => new CountryDTO
            {
                Name = c.Name
            }).ToList(),
            Clients = t.ClientTrips.Select(ct => new ClientDTO
            {
                FirstName = ct.IdClientNavigation.FirstName,
                LastName = ct.IdClientNavigation.LastName,
            }).ToList()
        }).ToList();

        return new TripPage
        {
            pageNum = pageNumber,
            pageSize = PAGE_ENTRIES,
            allPages = numberOfPages,
            trips = tripsPage
        };

    }
}
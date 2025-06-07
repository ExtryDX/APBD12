using APBD12.DTOs;
using APBD12.Models;
using APBD12.Services;
using Microsoft.EntityFrameworkCore;

namespace APBD12.Repositories;

public class TripsRepository : ITripsRepository
{
    private readonly TripsDbContext _context;

    public TripsRepository(TripsDbContext context)
    {
        _context = context;
    }

    public async Task<List<Trip>> GetTripsPageOrderByTripFromDescAsync(int pageNumber,
        CancellationToken cancellationToken)
    {
        return await _context.Trips.Include(t => t.ClientTrips).ThenInclude(ct => ct.IdClientNavigation)
            .Include(t => t.IdCountries)
            .OrderByDescending(t=>t.DateFrom)
            .Skip((pageNumber - 1) * 10)
            .Take(10)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetTripsCount()
    {
        return await _context.Trips.CountAsync();
    }
}
using APBD12.Models;

namespace APBD12.DTOs;

public class TripPage
{
    public int pageNum { get; set; }
    public int pageSize { get; set; }
    public int allPages { get; set; }
    public List<TripDTO> trips { get; set; }
    
}
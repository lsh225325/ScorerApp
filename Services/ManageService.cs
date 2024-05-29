using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ScorerApp;

public class ManageService
{
    private readonly ApplicationDbContext _context;

    public ManageService(ApplicationDbContext context)
    {
        _context = context;

    }

    public async Task<NoPlayerRooms[]> GetNoPlayerRooms()
    {
        var items = await _context.Room
            .Where(c => c.RoomPlayers.Count() < 2)
            .Select(c => new NoPlayerRooms
            {
                Id=c.Id,
                Code = c.Code,
                CreatTime = c.CreateTime,
                Count = c.RoomPlayers.Count()
            }).ToArrayAsync();

        return items;
    }

    public async Task<int> RemoveRooms(List<string> rooms)
    {

       return await _context.Room.Where(c => rooms.Contains(c.Id)).ExecuteDeleteAsync();
 
        
          
    }

   


}

using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ScorerApp;

public class RoomService
{
    private readonly ApplicationDbContext _context;
    private readonly IHubContext<SignHub> _hubContext;

    public RoomService(ApplicationDbContext context, IHubContext<SignHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }

    public async Task<Room?> GetRoomAsync(string roomId)
    {
        return await _context.Room
            .FirstOrDefaultAsync(s => s.Id == roomId);
    }

    public async Task<Room?> GetRoomByCode(string code)
    {
        return await _context.Room
            .FirstOrDefaultAsync(s => s.Code == code);
    }


    public async Task<List<Room>> GetRoomsByUserAsync(string userId)
    {
        return await _context.Room
            .Where(s => s.CreateUserId == userId)
            .ToListAsync();
    }

    public async Task<Room> CreateRoomAsync(Room room)
    {
        _context.Room.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task JoinGame(string roomId, string userId, string? secret = null)
    {
        if (await _context.RoomPlayer.AnyAsync(s => s.RoomId == roomId && s.UserId == userId))
        {
            return;
        }

        var player = new RoomPlayer()
        {
            Id = Guid.NewGuid().ToString(),
            RoomId = roomId,
            UserId = userId
        };

        _context.RoomPlayer.Add(player);
        await _context.SaveChangesAsync();
        await _hubContext.Clients.All.SendAsync("SendMessage");
    }


    public async Task<List<RoomPlayer>> GetPlayersByRoom(string roomId)
    {
        return await _context.RoomPlayer
            .Where(c => c.RoomId == roomId)
            .Include(c => c.User)
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<List<RoomPlayer>> GetPlayerJoinRooms(string playerId)
    {
        return await _context.RoomPlayer
            .Where(c => c.UserId == playerId)
            .Include(c => c.Room)
            .AsNoTracking()
            .ToListAsync();
    }


}

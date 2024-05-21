using Microsoft.EntityFrameworkCore;

namespace ScorerApp;

public class ScoreService
{
    private readonly ApplicationDbContext _context;
    public ScoreService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ScoreItem>> GetItemsByUserId(string userId, string roomId)
    {
        return await _context.ScoreItem
        .Where(o=>o.UserId==userId && o.RoomId==roomId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<ScoreItem>> GetItemsByRoomId(string roomId)
    {
        return await _context.ScoreItem
            .Where(o => o.RoomId == roomId)
            .OrderByDescending(o => o.CreateTime)
            .Include(o => o.FromUser)
            .AsNoTracking()
            .ToListAsync();
    }


    public async Task<int> GetUserScoreValue(string userId, string roomId)
    {
        var result = await GetItemsByUserId(userId, roomId);
        return result.Sum(c => c.Score);
    }


    public async Task AddScore(string userId, string roomId, int score, string fromUserId)
    {
        if (userId == fromUserId) return;

        var my = new ScoreItem();
        my.Score = -score;
        my.FromUserId = fromUserId;
        my.UserId = userId;
        my.RoomId = roomId;
        my.Id = Guid.NewGuid().ToString();

        var to = new ScoreItem();
        to.Score = score;
        to.FromUserId = userId;
        to.UserId = fromUserId;
        to.RoomId = roomId;
        to.Id = Guid.NewGuid().ToString();

        _context.ScoreItem.Add(my);
        _context.ScoreItem.Add(to);
        await _context.SaveChangesAsync();
    }

}

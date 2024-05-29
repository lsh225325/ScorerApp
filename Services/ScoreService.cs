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

        //使用了事务处理来确保两个分数项要么都成功添加，要么都不添加
        try
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.ScoreItem.Add(my);
                _context.ScoreItem.Add(to);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
        }
        catch (Exception ex)
        {
          throw new Exception("更新错误"+ex.Message);
        }

    }

}

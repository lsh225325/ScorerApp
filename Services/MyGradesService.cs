using Microsoft.EntityFrameworkCore;

namespace ScorerApp
{
    public class MyGradesService
    {
        private readonly ApplicationDbContext _context;
        public MyGradesService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<MyGrades> MyGrades(string userId)
        {

            var userRoomScores = _context.Room
                .SelectMany(c => c.ScoreItems)
                .Where(o => o.UserId == userId);
          
            //var lastyear = DateTime.Now.AddYears(-1);
            //var lastoneGrades = myGrades.Where(c => c.CreateTime >= lastyear).Sum(c => c.Score);
            var totalGrades =await userRoomScores.SumAsync(c => c.Score);
            var gameCount = userRoomScores.Select(p => p.RoomId).Distinct().Count();


            var roomScoreList = await userRoomScores
                .GroupBy(c => c.RoomId)
                .Select(o => new
                {
                    roomId=o.Key,
                    score=o.Sum(c => c.Score)
                }).ToListAsync();



            return new MyGrades()
            {
                LastOneYearGrades = 0,
                TotalGrades = totalGrades,
                GamesCount = gameCount,
                WinCount = roomScoreList.Where(c => c.score > 0).Count(),
                LostCount= roomScoreList.Where(c => c.score < 0).Count()
            };
        }





    }
}

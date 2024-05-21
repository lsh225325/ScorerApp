using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScorerApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Room> Room { get; set; }
        public DbSet<RoomPlayer> RoomPlayer { get; set; }
        public DbSet<ScoreItem> ScoreItem { get; set; }
        public DbSet<UserHeadImg> UserHeadImg{get;set;}
    }
}

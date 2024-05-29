using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ScorerApp;
public class RolesService
{
    private readonly ApplicationDbContext _context;

    public RolesService(ApplicationDbContext context, HttpClient httpClient)
    {
        _context = context;
    }

    public async Task<List<IdentityRole>> GetRoles()
    {
        return await _context.Roles.ToListAsync();
    }




    public async Task<ApplicationUser?> GetUser(string userId)
    {
        return await _context.Users.FindAsync(userId);
    }



}

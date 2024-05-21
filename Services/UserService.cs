using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace ScorerApp;

public class UserService
{
    private readonly ApplicationDbContext _context;
    private readonly HttpClient _httpClient;

    public UserService(ApplicationDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<string?> GetOpenId(string code)
    {

        var url = XiaochengxuInfo.GetCode2SessionUrl(code);
        //获取微信code2session
        var code2sessionResponse = await _httpClient.GetAsync(url);
        var code2sessionString = await code2sessionResponse.Content.ReadAsStringAsync();
        var code2Session = JsonSerializer.Deserialize<JsCode2Session>(code2sessionString);

        return code2Session?.openid;
    }

    public async Task<bool> CheckUserHeadImg(string userId)
    {
        var user = await _context.Users.Include(u => u.UserHeadImg).FirstOrDefaultAsync(u => u.Id == userId);
        if (user!.UserHeadImg.UserHeadImgContent == null || user!.UserHeadImg.UserHeadImgContent.Length < 2) return false;
        return true;
    }


    public async Task UpdateUserHeadImg(string openId, byte[] img)
    {
        var user = await _context.Users.Include(u => u.UserHeadImg).FirstOrDefaultAsync(u => u.WeixinOpenId == openId);
        user!.UserHeadImg.UserHeadImgContent = img;
        await _context.SaveChangesAsync();
    }


    public async Task<bool> CheckUser(string openid)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.WeixinOpenId == openid);
        user ??= await _context.Users.FirstOrDefaultAsync(u => u.UserName == openid);

        if (user == null) return false;
        return true;
    }

    public async Task<ApplicationUser?> GetUser(string openid)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.WeixinOpenId == openid);
        user ??= await _context.Users.FirstOrDefaultAsync(u => u.UserName == openid);

        return user;
    }

}
 
using Microsoft.AspNetCore.Identity;

namespace ScorerApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    { 
     
        public string? WeixinOpenId { get; set; }
        public string? HeadImgUrl { get; set; } = "favicon.png";
        public string? NickName { get; set; }

        public string? WeixinCode { get; set; }

        public string? WeixinUnionId { get; set; }

        public UserHeadImg UserHeadImg { get; set; } = new();
    }

}

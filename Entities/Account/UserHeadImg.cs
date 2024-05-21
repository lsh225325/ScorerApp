using ScorerApp.Data;

namespace ScorerApp
{
    public class UserHeadImg
    {
        public int Id { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public byte[]? UserHeadImgContent { get; set; }
    }
}

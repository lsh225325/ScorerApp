namespace ScorerApp;

public class MyInfo
{
    public string? UserId { get; set; }
    public string? UserName { get; set; } = string.Empty;
	public string? Code { get; set; } = string.Empty;
    public string? NickName { get; set; } = string.Empty;
	public string? HeadImgUrl { get; set; }=string.Empty;
    public int Score { get; set; } = 0;
    public DateTime? Created { get; set; }

}

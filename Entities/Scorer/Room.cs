namespace ScorerApp;

public class Room : Base
{
  //记分器的代码，可以使用记分器的代码来加入房间
  public string Code { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  //记分器Id
  public string CreateUserId { get; set; } = string.Empty;
  public ApplicationUser? CreateUser { get; set; }

  /// 加入时，是否需要输入密码。如果密码为空，则不用输入
  public string Secret { get; set; } = string.Empty;

  public List<ScoreItem> ScoreItems { get; set; } = new List<ScoreItem>();
  public List<RoomPlayer> RoomPlayers { get; set; } = new();

}

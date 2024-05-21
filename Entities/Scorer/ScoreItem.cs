namespace ScorerApp;

public class ScoreItem:Base
{
    //得分
public int Score { get; set; } = 0;

//玩家ID
public string? UserId { get; set; }

    
//记分员ID
public string?  RoomId { get; set; }
public Room? Room { get; set; }

//得分来源玩家ID
public string? FromUserId { get; set; }
public ApplicationUser? FromUser { get; set; }

}

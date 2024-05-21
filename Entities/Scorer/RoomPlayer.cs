namespace ScorerApp;

public class RoomPlayer:Base
{
    public string? RoomId { get; set; }
    public Room? Room { get; set; }

    //玩家ID
    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

}

namespace WebAPI.DTO;

public class CommentDto
{
    public string AppUserId { get; set; }
    public int MovieId { get; set; }
    public string Text { get; set; }
}
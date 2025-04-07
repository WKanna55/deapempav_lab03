namespace Lab03_WillianKana.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public string Comment1 { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

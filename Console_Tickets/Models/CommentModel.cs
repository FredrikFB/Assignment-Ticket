using Console_Tickets.Models.Entitites;


namespace Console_Tickets.Models
{
    internal class CommentModel
    {
        public int CommentId { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

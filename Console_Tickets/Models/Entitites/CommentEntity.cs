
using System.ComponentModel.DataAnnotations;

namespace Console_Tickets.Models.Entitites;

internal class CommentEntity
{
    [Key]
    public int CommentId { get; set; }
    public string Comment { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public int TicketId { get; set; }
    public TicketEntity Ticket { get; set; } = null!;
}

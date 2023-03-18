using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;


namespace Console_Tickets.Models.Entitites;

internal class TicketEntity
{
    [Key]
    public int TicketId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    [StringLength(30)]
    public string Status { get; set; } = null!;
    public DateTime Created { get; set; }

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
    public virtual ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
}


namespace Console_Tickets.Models;

internal class Errand
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public string Status { get; set; } = null!;
}

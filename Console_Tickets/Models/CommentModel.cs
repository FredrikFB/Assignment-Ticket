using Console_Tickets.Models.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Tickets.Models
{
    internal class CommentModel
    {
        public int CommentId { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

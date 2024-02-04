#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace SDS.Models
{
    public class History
    {
        public string Choix { get; set; }
        public string? Poste { get; set; }
        public DateTime Date { get; set; } 

    }
}

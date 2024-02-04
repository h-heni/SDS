#pragma warning disable CS8618
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDS.Models
{
    public class Caisse 
    {
        [Key]
        public int CaisseId { get; set; }
        [Range(typeof(DateTime), "1/2/2024", "3/4/2054",
                ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime Journee { get; set; }
        public float? Fond { get; set; }
               
        public float Poste1 { get; set; }
       
        public float Poste2 { get; set; }
       
        public float Poste3 { get; set; }
               
        public float Lavage { get; set; }
               
        public float Lubrifiant { get; set; }
       
        public float Autre { get; set; }
       
        public float Espece { get; set; }
               
        public float Cheque { get; set; }
               
        public float TPE { get; set; }
       
        public float Credit { get; set; }
       
        public float SNDP { get; set; }
               
        public float Depenses { get; set; }
               
        public float Filtres { get; set; }
               
        public float CreditGerant { get; set; }
       
        public float SortieContreBon { get; set; }
       
        public List<ContreBon> ListContreBon { get; set; }
        [NotMapped]
        public ContreBon ContreBon { get; set; }


        public float ContreBonTotal { get; set; }
        public Caisse()
        {
            ContreBon = new ContreBon();
            ListContreBon = new List<ContreBon>(); 
        }
    }
    public class ContreBon
    {
        [Key]
        public int ContreBonId { get; set; }
        public float Valeur { get; set; }
        public float Nombre { get; set; }
        [ForeignKey("CaisseId")]
        public int CaisseId { get; set; }
        public Caisse Caisse { get; set; }
        
    }
}

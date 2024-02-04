#pragma warning disable CS8618
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace SDS.Models
{
    public class Rapport
    {
        [Key]
        public int RapportId { get; set; }
        [Required]
        public DateTime Journee { get; set; }
        [Required]
        public string Poste { get; set; }
        [Required]
        public string Equipe { get; set; }
        [Required]        
        public float G1Depart { get; set; }
        [Required]        
        public float G1Final { get; set; }               
        public float? G1Diff { get; set; }                
        public float? G1Cash { get; set; }
        [Required]        
        public float G2_1Depart { get; set; }
        [Required]        
        public float G2_1Final { get; set; }               
        public float? G2_1Diff { get; set; }                
        public float? G2_1Cash { get; set; }
        [Required]        
        public float G2_2Depart { get; set; }
        [Required]        
        public float G2_2Final { get; set; }               
        public float? G2_2Diff { get; set; }                
        public float? G2_2Cash { get; set; }
        [Required]        
        public float SSP1Depart { get; set; }
        [Required]        
        public float SSP1Final { get; set; }
        public float? SSP1Diff { get; set; }
        public float? SSP1Cash { get; set; } 
        [Required]        
        public float SSP2Depart { get; set; }
        [Required]        
        public float SSP2Final { get; set; }
        public float? SSP2Diff { get; set; }
        public float? SSP2Cash { get; set; } 
        [Required]        
        public float SSP3Depart { get; set; }
        [Required]        
        public float SSP3Final { get; set; }
        public float? SSP3Diff { get; set; }
        public float? SSP3Cash { get; set; } 
        [Required]        
        public float G501Depart { get; set; }
        [Required]        
        public float G501Final { get; set; }
        public float? G501Diff { get; set; }
        public float? G501Cash { get; set; }
        [Required]
        public float GasoilPrice { get; set; }
        [Required]
        public float SansPlombPrice { get; set; }
        [Required]
        public float G50Price { get; set; }
        public float? Total { get; set; } 
        public DateTime CreatedAt { get; set; }=DateTime.Now;

    }
}

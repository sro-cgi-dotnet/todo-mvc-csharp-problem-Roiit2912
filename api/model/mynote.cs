using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample
{
    public class mynotes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Required]
        public int ? id {get; set;} 

        public string title {get; set;}

        public string text {get; set;}

        public string type{get;set;}

        public bool favourite{get;set;}

    }

  
}
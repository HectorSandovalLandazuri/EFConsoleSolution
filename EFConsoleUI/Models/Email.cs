using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleUI.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        public int ContactId { get; set; }


        [Required]
        [MaxLength(100)]
        [Column(TypeName ="varchar(100)")]
        public string EmailAddress { get; set; }
    }
}

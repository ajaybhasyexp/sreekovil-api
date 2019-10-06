using System;
using System.ComponentModel.DataAnnotations;

namespace Sreekovil.Models.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}

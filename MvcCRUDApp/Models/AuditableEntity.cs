using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCRUDApp.Models
{
    // for common fields in table
    public abstract class AuditableEntity
    {
        [Required(ErrorMessage = "{0} required")]
        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        public int? CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public int? ModifiedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Created { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? Modified { get; set; }
    }
}
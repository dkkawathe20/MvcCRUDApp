using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCRUDApp.Models
{
    public class MstAddress : AuditableEntity
    {
        //primary key by default DatabaseGenerated(DatabaseGeneratedOption.Identity) set, if you dont want auto generated identitty
        // then use DatabaseGenerated(DatabaseGeneratedOption.None) in this case you have to provide Id while adding record
        [Key]
        public int Id { get; set; }

        [Display(Name = "Address Line1"), Required(ErrorMessage = "{0} required"), MaxLength(300)]
        public string AddressLine1 { get; set; }
        [MaxLength(300)]
        public string AddressLine2 { get; set; }
                
        [Column(TypeName = "char"), MaxLength(10)]
        public string PinCode { get; set; }
        //this enum field support dropdown on UI
        public AddressType? AddressType { get; set; }
        [MaxLength(50), Required()]
        public string City { get; set; }
        [MaxLength(50), Required()]
        public string State { get; set; }
        [MaxLength(50), Required()]
        public string Country { get; set; }
        //foreignkey of emplyee
        
        // Foreign key
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]// for foreign key creation while code first database creation
        public virtual Employee Employee { get; set; }
    }

    public enum AddressType
    {
        Permnant = 1,
        Temporary
    }

}
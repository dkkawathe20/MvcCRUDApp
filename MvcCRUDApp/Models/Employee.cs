using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUDApp.Models
{

    //AuditableEntity: we inheriting AuditableEntity fields in this table, these fields are common,
    //its not necessary instead you can wirte createdDate IsActive fields in employee class also
    public class Employee : AuditableEntity
    {
        //key for primary key , DatabaseGeneratedOption.Identity for auto generate idenetity while adding new record in table
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Display attribute for field name on UI
        [Display(Name = "First Name"), MaxLength(50), Required()]
        public string FirstName { get; set; }
        [MaxLength(50), Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name"), MaxLength(50), Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }
        [Column(TypeName = "char"), MaxLength(15), Required()]
        public string Gender { get; set; }

        //DataType(DataType.Date) for date picker  control on UI
        //DisplayFormat(DataFormatString = "0:dd/MM/yyyy hh:mm") date time editor
        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { get; set; }

        //Employee can have multiple address it is useful for Linq extension query with ralational table
        public virtual ICollection<MstAddress> MstAddresses { get; set; }

        [NotMapped]// this is not database column its just for populate gender dropdown
        public SelectList Genders { get; set; }
        
    }


    public class Gender
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


}
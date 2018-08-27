//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trend
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HREmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HREmployee()
        {
            this.LedLeads = new HashSet<LedLead>();
            this.LedLeads1 = new HashSet<LedLead>();
            this.LedLeadFroms = new HashSet<LedLeadFrom>();
        }
    
        public int ID { get; set; }
        [StringLength(100)]
        public string EmployeeName { get; set; }
        [StringLength(100)]
        public string Surname { get; set; }
        public System.DateTime BirthDate { get; set; }
        [StringLength(20)]
        public string IdentificationNumber { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(15)]
        public string Telephone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LedLead> LedLeads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LedLead> LedLeads1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LedLeadFrom> LedLeadFroms { get; set; }
    }
}

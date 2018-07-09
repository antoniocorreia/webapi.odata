namespace WEBAPI.ODATA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq.Expressions;

    [Table("Person.ContactType")]
    public partial class ContactType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContactType()
        {
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
        }

        public int ContactTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        //public DateTime ModifiedDate { get; set; }
        public static class ContactTypeExpressions
        {
            public static readonly Expression<Func<ContactType, DateTime>> ModifiedDate = c => c.LastModifiedOnInternal;
        }

        public DateTimeOffset ModifiedDate
        {
            get { return new DateTimeOffset(LastModifiedOnInternal); }
            set { LastModifiedOnInternal = value.DateTime; }
        }

        private DateTime LastModifiedOnInternal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
    }
}

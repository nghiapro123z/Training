namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public category()
        {
            courses = new HashSet<course>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(1)]
        public string categoryName { get; set; }

        [Required]
        [StringLength(1)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course> courses { get; set; }
    }
}

namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trainer")]
    public partial class trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainer()
        {
            topics = new HashSet<topic>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int accountID { get; set; }

        [Required]
        [StringLength(1)]
        public string name { get; set; }

        [Required]
        [StringLength(1)]
        public string type { get; set; }

        [Required]
        [StringLength(1)]
        public string education { get; set; }

        [Required]
        [StringLength(1)]
        public string workingPlace { get; set; }

        [Required]
        [StringLength(1)]
        public string phoneNumber { get; set; }

        [Required]
        [StringLength(1)]
        public string email { get; set; }

        public virtual account account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<topic> topics { get; set; }
    }
}

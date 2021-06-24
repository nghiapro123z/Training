namespace Training.Models.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trainingStaff")]
    public partial class trainingStaff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int accountID { get; set; }

        [Required]
        [StringLength(1)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(1)]
        public string phoneNumber { get; set; }

        [Required]
        [StringLength(1)]
        public string email { get; set; }

        public virtual account account { get; set; }
    }
}

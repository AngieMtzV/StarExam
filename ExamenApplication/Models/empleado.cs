namespace ExamenApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("empleado")]
    public partial class empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int emp_id { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_empleado { get; set; }

        [Required]
        [StringLength(40)]
        public string ap_pat { get; set; }

        [Required]
        [StringLength(40)]
        public string ap_mat { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Ingresa un email válido")]
        public string email { get; set; }


        public int area_id { get; set; }

        public virtual area area { get; set; }
    }
}

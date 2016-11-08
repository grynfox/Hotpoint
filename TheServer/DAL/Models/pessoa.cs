namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banco_bar.pessoa")]
    public partial class pessoa
    {
        [Key]
        public int idPessoa { get; set; }

        public int idgrupoPermicoes { get; set; }

        [Required]
        [StringLength(45)]
        public string login { get; set; }

        [Required]
        [StringLength(45)]
        public string password { get; set; }

        [Required]
        [StringLength(45)]
        public string nome { get; set; }

        public bool isEnabled { get; set; }

        public virtual grupopermicoes grupopermicoes { get; set; }
    }
}

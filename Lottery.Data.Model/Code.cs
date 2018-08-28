﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lottery.Data.Model
{
    [Table("Codes")]
    public class Code : IEntity
    {
        [Key]
        [Column("CodeID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CodeValue { get; set; }
        public bool Winning { get; set; }
        [DefaultValue(false)]
        public bool Used { get; set; }
    }
}

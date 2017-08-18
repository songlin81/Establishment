using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWork
{
    [Table("Model")]
    public partial class Model
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string ModelId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string ProductClassID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime PriceListDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte ProductStructureSource { get; set; }

        [StringLength(100)]
        public string DefaultText { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string ProductTypeID { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime TimestampCreated { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool Deleted { get; set; }

        public short? SortOrder { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte PricelistStatus { get; set; }
    }
}

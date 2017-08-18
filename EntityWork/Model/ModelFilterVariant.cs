namespace EntityWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModelFilterVariant")]
    public partial class ModelFilterVariant
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MarketId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ModelId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string VariantId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string ProductClassID { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte ProductStructureSource { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime PriceListDate { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(3)]
        public string FamilyId { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool Deleted { get; set; }

        [Key]
        [Column(Order = 8)]
        public byte PricelistStatus { get; set; }
    }
}

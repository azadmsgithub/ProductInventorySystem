using System;

namespace ProductInventorySystem.Models
{
    public class SubVariant
    {
        public Guid Id { get; set; }
        public Guid VariantId { get; set; }
        public string Option { get; set; }
        public decimal Stock { get; set; }

        public Variant Variant { get; set; }
    }
}


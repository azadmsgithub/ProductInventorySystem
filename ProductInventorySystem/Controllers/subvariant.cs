using System;
using System.Collections.Generic;

namespace ProductInventorySystem.Models
{
    public class Variant
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }

        public Product Product { get; set; }
        public ICollection<SubVariant> SubVariants { get; set; }
    }
}

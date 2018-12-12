using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarsError.Data.Models
{
    public class Child
    {
        public long ChildId { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Thing Parent { get; set; }

        public long ParentId { get; set; }
    }
}
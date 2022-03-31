using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Domain.Entities
{
    public class CategoryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ItemReleasedDate { get; set; }

        public int CategoryId { get; set; }
        public int MediaTypeId { get; set; }

    }
}

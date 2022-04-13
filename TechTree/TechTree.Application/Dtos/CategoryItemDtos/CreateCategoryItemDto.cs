using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Application.Dtos.CategoryItemDtos
{
    public class CreateCategoryItemDto
    {
        public string Title { get; set; }
        public DateTime ItemReleasedDate { get; set; }
        public string Description { get; set; }


        public int CategoryId { get; set; }
        public int MediaTypeId { get; set; }
    }
}

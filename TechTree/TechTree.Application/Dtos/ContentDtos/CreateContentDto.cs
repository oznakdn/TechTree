﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTree.Application.Dtos.ContentDtos
{
    public class CreateContentDto
    {
        public string Title { get; set; }
        public string HTMLContent { get; set; }
        public string VideoLink { get; set; }
        public int CategoryItemId { get; set; }
    }
}

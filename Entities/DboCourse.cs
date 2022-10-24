﻿using System;
using System.Collections.Generic;

namespace Entity_Framework_Queries.Entities
{
    public partial class DboCourse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Level { get; set; }
        public string? FullPrice { get; set; }
        public int? AuthorId { get; set; }

        public virtual DboAuthor? Author { get; set; }
    }
}

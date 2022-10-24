using System;
using System.Collections.Generic;

namespace Entity_Framework_Queries.Entities
{
    public partial class DboAuthor
    {
        public DboAuthor()
        {
            DboCourses = new HashSet<DboCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DboCourse> DboCourses { get; set; }
    }
}

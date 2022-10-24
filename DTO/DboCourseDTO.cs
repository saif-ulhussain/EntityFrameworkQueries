namespace Entity_Framework_Queries.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Level { get; set; }
        public string? FullPrice { get; set; }
        public int? AuthorId { get; set; }

        //   public virtual DboAuthor? Author { get; set; }
    }
}
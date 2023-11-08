namespace BookDapper.Models
{
    //book and student some mistake (edit is not properly work)
    //employee is properly all CRUD operation
    public class Student
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Percentage { get; set; }
        public string? City { get; set; }

    }
}


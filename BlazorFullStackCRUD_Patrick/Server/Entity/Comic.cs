using System.ComponentModel.DataAnnotations;

namespace BlazorFullStackCRUD_Patrick.Server.Entity
{
    public class Comic
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

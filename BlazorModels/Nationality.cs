using System.ComponentModel.DataAnnotations;

namespace BlazorModels
{
    public class Nationality
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

    }
}
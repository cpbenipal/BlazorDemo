using System.ComponentModel.DataAnnotations;

namespace BlazorModels
{
    public class Company 
    {
        [Key]
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public DateTime DOJ { get; set; }

    } 

}
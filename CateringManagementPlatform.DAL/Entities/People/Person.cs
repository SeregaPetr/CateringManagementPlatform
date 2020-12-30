using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities.People
{
    // public abstract class Person
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}

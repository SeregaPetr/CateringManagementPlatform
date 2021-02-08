using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities.People
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Patronymic { get; set; }


        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}

namespace dotnetAPIS.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        public int Age { get; set; }
        
        public string? PhoneNumber {get; set;}
    }
}
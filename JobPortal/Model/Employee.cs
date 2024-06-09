using System.ComponentModel.DataAnnotations;

namespace JobPortal.Model
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string MobileNumber { get; set; }
        public required string Email {  get; set; }
        public string JobRole { get; set; }
        public string WorkExperience { get; set; }
        public float  CurrentCTC { get; set; }
        public float ExpectedCTC { get; set;}
        public string NoticePeriod {  get; set; } 
    }
}

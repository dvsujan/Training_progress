using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public int Experience { get; set; }
    }
}

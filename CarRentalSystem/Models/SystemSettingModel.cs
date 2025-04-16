using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class SystemSettingModel
    {
        public int Id { get; set; }

        [Required]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string Value { get; set; } = string.Empty;
    }
}

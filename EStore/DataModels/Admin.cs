using System.ComponentModel.DataAnnotations;

namespace EStore.DataModels
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string? AdminType { get; set; }

        public string? AdminData { get; set; }

        public string? AdminIcon { get; set; }

        public bool IsActive { get; set; }
    }
}

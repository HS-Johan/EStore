using System.ComponentModel.DataAnnotations;

namespace EStore.DataModels
{
    public class LookUp
    {
        [Key]
        public int LookUpId { get; set; }

        public int LookUpType { get; set; }

        public string? LookUpData { get; set; }

        public string? LookUpIcon { get; set; }

        public bool IsActive { get; set; }
    }
}

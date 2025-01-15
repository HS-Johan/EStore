namespace EStore.ViewModel
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int LableId { get; set; }
        public string? LableName { get; set; }
        public bool IsActive { get; set; }
        public string? Category { get; set; }
        public IFormFile? UploadImage { get; set; }
    }
}

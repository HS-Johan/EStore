using EStore.DataModels;

namespace EStore.ViewModel
{
    public class HomePageVM
    {
        public IEnumerable<Product>? Product { get; set; }

        public IEnumerable<Label>? label { get; set; }

        public IEnumerable<LookUp>? LookUp { get; set; }
    }
}

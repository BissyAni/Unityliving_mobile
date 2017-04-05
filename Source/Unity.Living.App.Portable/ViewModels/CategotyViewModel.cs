using Unity.Living.App.Portable.Models;

namespace Unity.Living.App.Portable.ViewModels
{
    public class CategotyViewModel: ViewModelBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public CategotyViewModel(Category category)
        {
            id = category.id;
            name = category.name;
        }
    }
}

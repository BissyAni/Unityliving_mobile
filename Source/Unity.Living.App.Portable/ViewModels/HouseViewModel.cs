namespace Unity.Living.App.Portable.ViewModels
{
    public  class HouseViewModel: ViewModelBase
    {
        public int id { get; set; }
        public string house { get; set; }
        public HouseViewModel(Models.HouseAndCategory.House h)
        {
            id = h.Id;
            house = h.DoorNumber;            
        }
    }
}

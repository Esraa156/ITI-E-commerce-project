namespace bnm.Views.ViewModel
{
    public class productmodel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }


        public int Quantity { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}

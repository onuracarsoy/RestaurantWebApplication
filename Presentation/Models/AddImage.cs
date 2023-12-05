namespace Presentation.Models
{
    public class AddImage
    {

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public IFormFile ProductImage { get; set; }

        public string ProductContent { get; set; }

        public decimal ProductPrice { get; set; }
    }
}

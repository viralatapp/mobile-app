namespace ViralatApp.Models
{
    public class Category
    {
        public Category(string name, string image)
        {
            Name = name;
            Image = image;
        }

        public string Name { get; set; }
        public string Image { get; set; }
    }
    
}

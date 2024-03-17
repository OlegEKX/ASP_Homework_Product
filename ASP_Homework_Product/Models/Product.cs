namespace ASP_Homework_Product.Models
{
    public class Product
    {
        private static int unicId = 0;
        public int Id { get; }
        public string Name { get; }
        public int Cost { get; }
        public string Description { get; }
        public string ImageURL { get; }

        public Product(string name, int cost, string description, string imageUrl)
        {
            unicId++;
            Name = name;
            Cost = cost;
            Description = description;
            Id = unicId;
            ImageURL = imageUrl;
        }

        public override string ToString()
        {
            return $"Id: {Id}. Name = {Name}, Cost = {Cost}, Description = {Description}";
        }
    }
}

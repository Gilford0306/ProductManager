namespace ProductManager.Model
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public Product()
        {
            Id = 0;
            Name = string.Empty;
            CategoryId = 0;
            SupplierId = 0;
        }
        public Product(int id, string name, int categoryId, int supplierId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            SupplierId = supplierId;
        }

        public override string ToString()
        {
            return $"{Id}.Name - {Name}, CategoryId - {CategoryId}, SupplierId - {SupplierId}";
        }

    }

}

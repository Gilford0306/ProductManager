namespace ProductManager.Model
{
    internal class Category
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }


        public Category()
        {
            Id = 0;
           NameCategory = string.Empty;

        }
        public Category(int id, string name)
        {
            Id = id;
           NameCategory = name;
        }

        public override string ToString()
        {
            return $"{Id}.category  - {NameCategory}";
        }

    }

}

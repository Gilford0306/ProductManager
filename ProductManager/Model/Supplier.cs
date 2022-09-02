namespace ProductManager.Model
{
    internal class Supplier
    {
        public int Id { get; set; }
        public string NameSupplier { get; set; }


        public Supplier()
        {
            Id = 0;
            NameSupplier = string.Empty;

        }
        public Supplier(int id, string name)
        {
            Id = id;
            NameSupplier = name;
        }

        public override string ToString()
        {
            return $"{Id}.Supplier  - {NameSupplier}";
        }

    }

}

namespace Z_Marked.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Price { get; set; }
        public string? Category { get; set; }

        public string? Description { get; set; }

        public string? NutritionalContent { get; set; }

        public string? Imagepath { get; set; }

        public Item() : this(0, "", 0, "", "", "", "") { }

        public Item(int id, string? name, int price, string? description, string category, string? nutritionalContent, string? imagepath)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            Description = description;
            NutritionalContent = nutritionalContent;
            Imagepath = imagepath;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Description)}={Description}, {nameof(NutritionalContent)}={NutritionalContent}, {nameof(Imagepath)}={Imagepath}}}";
        }
    }
}

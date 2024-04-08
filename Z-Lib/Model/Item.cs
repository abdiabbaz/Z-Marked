using Z_Lib.Exceptions;

namespace Z_Marked.Model
{
    public class Item
    {
        public int Id
        {
            get => Id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Supplied ID is illegal");
                }
                Id = value;
            }
        }
        public string? Name
        {
            get => Name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalNameException();
                }
                Name = value;
            }
        }

        public double Price
        {
            get => Price;
            set
            {
                if (value <= 0)
                {
                    throw new IllegalPriceException(value); 
                }
            }
        }
        public string? Category { get; set; }

        public string? Description { get; set; }

        public string? NutritionalContent { get; set; }

        public string? Imagepath { get; set; }

        public Item() : this(0, "", 0.0, "", "", "", "") { }

        public Item(int id, string? name, double price, string? description, string category, string? nutritionalContent, string? imagepath)
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
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Category)}={Category}, {nameof(Description)}={Description}, {nameof(NutritionalContent)}={NutritionalContent}, {nameof(Imagepath)}={Imagepath}}}";
        }
    }
}

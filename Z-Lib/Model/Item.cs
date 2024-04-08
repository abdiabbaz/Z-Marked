using System.Net.NetworkInformation;
using Z_Lib.Exceptions;

namespace Z_Marked.Model
{
    public class Item
    {
        private int _id;
        private string _name;
        private double _price;
        private string _description;
        private string _category;
        private string _nutritionalContent;
        private string _imagePath; 
            

        public Item() : this(0, "dummy", 0.1, "dummy", "dummy", "dummy", "dummy") { }

        public Item(int id, string name, double price, string description, string category, string nutritionalContent, string imagepath)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            Description = description;
            NutritionalContent = nutritionalContent;
            ImagePath = imagepath;
        }
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 0)
                {
                    throw new IllegalIDException("Supplied ID is illegal");
                }
                _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValue();
                }
                _name = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0.0 || value >= 4001.0)
                {
                    throw new IllegalPriceException(value);
                }
                _price = value;
            }
        }
        public string Category
        {
            get => _category; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValue();
                }
                _category = value;
            }
        }

        public string Description
        {
            get => _description; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValue();
                }
                _description = value;
            }
        }

        public string NutritionalContent
        {
            get => _nutritionalContent; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValue();
                }
                _nutritionalContent = value;
            }
        }

        public string ImagePath
        {
            get => _imagePath; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValue();
                }
                _imagePath = value;
            }
        }

        
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Category)}={Category}, {nameof(Description)}={Description}, {nameof(NutritionalContent)}={NutritionalContent}, {nameof(ImagePath)}={ImagePath}}}";
        }
    }
}

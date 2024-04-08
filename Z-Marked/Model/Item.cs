﻿namespace Z_Marked.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public double Price { get; set; }
        public enum Category { }

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

using Z_Marked.Model;

namespace Z_Marked.Services
{
    public class ItemRepo : IItemRepo
    {
        private List<Item> _items;

        public ItemRepo()
        {
            _items = MockItems.GetMockItems();
            
        }
        public Item Create(Item item)
        {
            _items.Add(item);
            return item;
        }

        public Item Delete(Item item)
        {
            _items.Remove(item);
            return item;
        }

        public Item GetItem(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id)!;
        }

        public Item Update(int id, Item item)
        {
            Item existingItem = GetItem(id);

            if (existingItem == null)
            {
                throw new ArgumentNullException(nameof(existingItem), "There is no item with the specified number");
            }

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.NutritionalContent = item.NutritionalContent;
            existingItem.Imagepath = item.Imagepath;

            return existingItem;
        }

        public override string ToString()
        {
            string empty = "";

            foreach (var item in _items)
            {
                empty += item.ToString();
            }

            return $"{{{empty}}}";
        }
    }
}

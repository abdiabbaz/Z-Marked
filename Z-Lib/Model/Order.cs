namespace Z_Marked.Model
{
    public class Order
    {
        private List<Item> _itemsList;
        private Dictionary<Item, int> _itemsDictionary;

        public Order()
        {
            _itemsList = new List<Item>();
            _itemsDictionary = new Dictionary<Item, int>();
        }

        // Methods

        public void AddItem(Item item)
        {
            _itemsList.Add(item);
        }

        public void AddItemsToDic(Item item, int quantity)
        {
            if (_itemsDictionary.ContainsKey(item))
            {
                _itemsDictionary[item] += quantity;
            }
            else
            {
                _itemsDictionary.Add(item, quantity);
            }
        }

        public void RemoveItemFromDic(Item item)
        {
            _itemsDictionary.Remove(item);
        }

        public void RemoveItem(Item item)
        {
            _itemsList.Remove(item);
        }

        public double SumOfAllItems()
        {
            double sum = 0;
            foreach (Item item in _itemsList)
            {
                sum += item.Price;
            }
            return sum;
        }

        public double SumOfAllItemsDic()
        {
            double sum = 0;
            foreach (var kvp in _itemsDictionary)
            {
                double itemTotal = kvp.Key.Price * kvp.Value;
                sum += itemTotal;
            }
            return sum;
        }


        public List<Item> GetAllOrderItems()
        {
            return _itemsList;
        }

        public Dictionary<Item,int> GetItemsDictionary()
        {
            return _itemsDictionary;
        }
    }
}

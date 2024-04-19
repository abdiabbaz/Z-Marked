using System.Runtime.CompilerServices;

namespace Z_Marked.Model
{
    public class Order
    {
        private List<Item> _itemsList;
        private Dictionary<Item, int> _itemsDictionary;

        public Dictionary<Item, int> ItemsPerPage { get; private set; }


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
            bool foundItemInDict = false;

            foreach (var itemDic in _itemsDictionary.Keys)
            {
                if (itemDic.Id == item.Id)
                {
                    _itemsDictionary[itemDic] = _itemsDictionary[itemDic] + quantity;
                    foundItemInDict = true;
                }
            }
            if (!foundItemInDict)
            {
                _itemsDictionary.Add(item, quantity);
            }
        }

        public void RemoveItem(Item item, int quantityToRemove)
        {
            if (_itemsDictionary.ContainsKey(item))
            {
                _itemsDictionary[item] = _itemsDictionary[item] - quantityToRemove;
                if (_itemsDictionary[item] <= 0)
                {
                    _itemsDictionary.Remove(item);
                }
            }
        }


        public Item? GetItemById(int id)
        {
            foreach (var item in _itemsDictionary.Keys)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
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
            foreach (var items in _itemsDictionary)
            {
                double itemTotal = items.Key.Price * items.Value;
                sum += itemTotal;
            }
            return sum;
        }

        public Dictionary<Item, int> GetItemsDictionary()
        {
            return _itemsDictionary;
        }
    }
}

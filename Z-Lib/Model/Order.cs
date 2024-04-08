namespace Z_Marked.Model
{
    public class Order
    {
        private List<Item> _itemsList;

        public Order()
        {
            _itemsList = new List<Item>();
        }


        // Methods

        public void AddItem(Item item)
        {
            _itemsList.Add(item);
        }

        public double SumOfAllItems()
        {
            double sum = 0;
            foreach( Item item in _itemsList)
            {
                sum += item.Price;
            }
            return sum;
        }

        public List<Item> GetAllOrderItems()
        {
            return _itemsList;
        }
    }
}

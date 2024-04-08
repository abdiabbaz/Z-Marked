namespace Z_Marked.Model
{
    public class MockItems
    {
        private static List<Item> _items = new List<Item>()
        {
          new Item(1, "Æble", 2.50, "Frugt", "Et saftigt og sødt æble. Æbler er rige på kostfibre og C-vitamin.", "Kalorier: 52 per 100g, Kulhydrater: 14g, Fedt: 0.2g, Protein: 0.3g, Kostfibre: 2.4g, Vitamin C: 4.6mg", "/images/Æble.jpg"),
          new Item(2, "Faxe Kondi", 15, "Sodavand", "En forfriskende sodavand med en sprudlende og sød smag.", "Kalorier: 150 per 330ml, Sukker: 39g, Nul fedt, Koffein: 38mg", "/images/Sodavand.png"),
          new Item(3, "Fuldkornsbrød", 20, "Bageri", "Fuldkornsbrød bagt med en blanding af fuldkornsmel.", "Kalorier: 265 per 100g, Kulhydrater: 49g, Fedt: 3.5g, Protein: 13g, Kostfibre: 7g, Jern: 3mg", "/images/Broed.jpg"),
          new Item(4, "KiMs Chips",14, "Snacks", "Sprøde kartoffelchips, bagt til perfektion for at give en tilfredsstillende crunch.", "Kalorier: 536 per 100g, Kulhydrater: 53g, Fedt: 34g, Protein: 7g, Salt: 1.5g", "/images/Chips.jpg")

        };

        public static List<Item> GetMockItems() 
        {
            return _items; 
        }

        
    }
}


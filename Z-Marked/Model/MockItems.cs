namespace Z_Marked.Model
{
    public class MockItems
    {
        private static List<Item> _items = new List<Item>()
        {
          new Item(1, "Æble", 5, "Frugt", "Et saftigt og sødt æble, perfekt til snack eller som en del af din morgenmad. Æbler er rige på kostfibre og C-vitamin.", "Kalorier: 52 per 100g, Kulhydrater: 14g, Fedt: 0.2g, Protein: 0.3g, Kostfibre: 2.4g, Vitamin C: 4.6mg", "/images/aeble.png"),
          new Item(2, "Sodavand", 15, "Drikkevare", "En forfriskende sodavand med en sprudlende og sød smag. Perfekt som tørstslukker eller til at nyde sammen med et måltid.", "Kalorier: 150 per 330ml, Sukker: 39g, Nul fedt, Koffein: 38mg", "/images/sodavand.png"),
          new Item(3, "Brød", 20, "Bageri", "Fuldkornsbrød bagt med en blanding af fuldkornsmel for en rig og tilfredsstillende smag. En god kilde til kostfibre og protein.", "Kalorier: 265 per 100g, Kulhydrater: 49g, Fedt: 3.5g, Protein: 13g, Kostfibre: 7g, Jern: 3mg", "/images/broed.png"),
          new Item(4, "Chips", 25, "Snacks", "Sprøde og krydrede kartoffelchips, bagt til perfektion for at give en tilfredsstillende crunch. Et populært valg til fest eller som en hurtig snack.", "Kalorier: 536 per 100g, Kulhydrater: 53g, Fedt: 34g, Protein: 7g, Salt: 1.5g", "/images/chips.png")
        };


        public static List<Item> GetMockItems() 
        {
            return _items; 
        }
    }
}


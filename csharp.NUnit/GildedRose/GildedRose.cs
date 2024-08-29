using System.Collections.Generic;
using System.Xml.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality < 50)
            {
                item.Quality++;
            }
            if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality < 50 && item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Quality < 50 && item.SellIn < 11)
            {
                item.Quality++;
            }
            if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality < 50 && item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Quality < 50 && item.SellIn < 6)
            {
                item.Quality++;
            }
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn--;
            }
            if (item.Name != "Sulfuras, Hand of Ragnaros" && !(item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality > 0)
            {
                item.Quality--;
            }
            if (item.SellIn < 0 && item.Name == "Aged Brie" && item.Quality < 50)
            {
                item.Quality++;
            }
            if (item.SellIn < 0 && !(item.Name == "Aged Brie") && item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0;
            }
            if (item.SellIn < 0 && !(item.Name == "Aged Brie") && !(item.Name == "Backstage passes to a TAFKAL80ETC concert") && (item.Quality > 0) && item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.Quality--;
            }
        }
    }
}
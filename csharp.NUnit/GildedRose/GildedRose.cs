using System.Collections.Generic;

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
            switch (item.Name)
            {
                case "Aged Brie":
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    item.SellIn--;
                    if (item.SellIn < 0 && item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    if (item.Quality < 50 && item.SellIn < 11)
                    {
                        item.Quality++;
                        if (item.Quality < 50 && item.SellIn < 6)
                        {
                            item.Quality++;
                        }
                    }
                    item.SellIn--;
                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    item.SellIn--;
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                    if (item.SellIn < 0 && item.Quality > 0)
                    {
                        item.Quality--;
                    }
                    break;
            }
        }
    }
}
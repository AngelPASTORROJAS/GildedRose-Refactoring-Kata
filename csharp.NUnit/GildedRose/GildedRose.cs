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
            if ((isAgedBrie(item) || isPasses(item)) && item.Quality < 50)
            {
                item.Quality++;
            }
            if (item.Quality < 50 && isPasses(item) && item.SellIn < 11)
            {
                item.Quality++;
                if (item.Quality < 50 && item.SellIn < 6)
                {
                    item.Quality++;
                }
            }
            if (isNotSulfuras(item))
            {
                item.SellIn--;
                if (!(isAgedBrie(item) || isPasses(item)) && item.Quality > 0)
                {
                    item.Quality--;
                }
                if (item.SellIn < 0)
                {
                    if (isAgedBrie(item) && item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    if (isPasses(item))
                    {
                        item.Quality = 0;
                    }
                    if (!(isAgedBrie(item)) && !(isPasses(item)) && item.Quality > 0)
                    {
                        item.Quality--;
                    }
                }
            }
        }

        static bool isAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        static bool isPasses(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        static bool isNotSulfuras(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}
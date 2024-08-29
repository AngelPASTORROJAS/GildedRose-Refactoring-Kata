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
            if ((IsNameAgeBrie(item) || IsNameBackstage(item)) && IsQualityLessOn50(item))
            {
                item.Quality++;
            }
            if ((IsNameAgeBrie(item) || IsNameBackstage(item)) && IsQualityLessOn50(item) && IsNameBackstage(item) && IsQualityLessOn50(item) && item.SellIn < 11)
            {
                item.Quality++;
            }
            if ((IsNameAgeBrie(item) || IsNameBackstage(item)) && IsQualityLessOn50(item) && IsNameBackstage(item) && IsQualityLessOn50(item) && item.SellIn < 6)
            {
                item.Quality++;
            }
            if (IsNameNotSulfuras(item))
            {
                item.SellIn--;
            }
            if (IsNameNotSulfuras(item) && !(IsNameAgeBrie(item) || IsNameBackstage(item)) && item.Quality > 0)
            {
                item.Quality--;
            }
            if (IsSellInNegative(item) && IsNameAgeBrie(item) && IsQualityLessOn50(item))
            {
                item.Quality++;
            }
            if (IsSellInNegative(item) && !IsNameAgeBrie(item) && IsNameBackstage(item))
            {
                item.Quality = 0;
            }
            if (IsSellInNegative(item) && !IsNameAgeBrie(item) && !IsNameBackstage(item) && (item.Quality > 0) && IsNameNotSulfuras(item))
            {
                item.Quality--;
            }
        }
    }

    private static bool IsSellInNegative(Item item)
    {
        return item.SellIn < 0;
    }

    private static bool IsNameNotSulfuras(Item item)
    {
        return item.Name != "Sulfuras, Hand of Ragnaros";
    }

    private static bool IsQualityLessOn50(Item item)
    {
        return item.Quality < 50;
    }

    private static bool IsNameBackstage(Item item)
    {
        return item.Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    private static bool IsNameAgeBrie(Item item)
    {
        return item.Name == "Aged Brie";
    }
}
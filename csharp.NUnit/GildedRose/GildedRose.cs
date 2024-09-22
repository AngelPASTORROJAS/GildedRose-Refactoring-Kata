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
                    UpdateQualityAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateQualityBackstage(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    ReduceQualityNormalItem(item);
                    break;
            }
        }

    }

    private static void ReduceQualityPositive(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }
    }

    private static void UpgradeQualityLowAged(Item item)
    {
        const int LIMIT_VALUE_QUALITY = 50;
        if (item.Quality < LIMIT_VALUE_QUALITY)
        {
            item.Quality++;
        }
    }

    private static void ReduceQualityNormalItem(Item item)
    {
        item.SellIn--;
        ReduceQualityPositive(item);
        if (item.SellIn < 0)
        {
            ReduceQualityPositive(item);
        }
    }

    private static void UpdateQualityAgedBrie(Item item)
    {
        UpgradeQualityLowAged(item);
        item.SellIn--;
        if (item.SellIn < 0)
        {
            UpgradeQualityLowAged(item);
        }
    }

    private static void UpdateQualityBackstage(Item item)
    {
        UpgradeQualityLowAged(item);
        if (item.SellIn <= 10)
        {
            UpgradeQualityLowAged(item);
            if (item.SellIn <= 5)
            {
                UpgradeQualityLowAged(item);
            }
        }
        item.SellIn--;
        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }
}
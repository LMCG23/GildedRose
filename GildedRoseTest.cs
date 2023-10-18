using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
		[Test]
		public void updateQualityAndSellInTest()
		{
			IList<Item> items = new List<Item>
		    {
			new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
			new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
		    };
			var app = new GildedRose(items);

			app.UpdateQuality();
			Assert.AreEqual(19, items[0].Quality);
			Assert.AreEqual(1, items[1].SellIn);
		}

		[Test]
		public void UpdateQualityConjuredTest()
		{
			IList<Item> items = new List<Item>
		{
			new Item { Name = "Conjured", SellIn = 3, Quality = 6 }
		};
			var app = new GildedRose(items);
			app.UpdateQuality();
			Assert.AreEqual(4, items[0].Quality);
		}

		[Test]
		public void UpdateQualitySulfurasTest()
		{
			IList<Item> items = new List<Item>
		{
			new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 }
		};
			var app = new GildedRose(items);
			app.UpdateQuality();
			Assert.AreEqual(10, items[0].SellIn); 
			Assert.AreEqual(80, items[0].Quality); 
		}
	}
}

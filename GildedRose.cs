using ApprovalUtilities.Utilities;
using System;
using System.Collections.Generic;

namespace csharp
{
	public class GildedRose
	{
		IList<Item> Items;
		const string AngedBrie = "Aged Brie";
		const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
		const string Sulfuras = "Sulfuras, Hand of Ragnaros";
		const string Conjured = "Conjured";

		public GildedRose(IList<Item> Items)
		{
			this.Items = Items;
		}

		public void UpdateQuality()
		{
			Items.ForEach(item =>
			{
				if (item.Name != AngedBrie && item.Name != Backstage)
				{
					if (item.Quality > 0 && item.Name != Sulfuras)
					{
						if (item.Name.Contains(Conjured))
						{
							item.Quality = item.Quality == 1 ? 0 : item.Quality - 2 ;
						}
						else
						{
							item.Quality--;
						}
					}
				}
				else
				{
					if (item.Quality < 50)
					{
						item.Quality++;

						if (item.Name == Backstage)
						{
							if (item.SellIn < 11 && item.Quality < 50)
							{
								item.Quality++;
							}

							if (item.SellIn < 6 && item.Quality < 50)
							{
								item.Quality++;
							}
						}
					}
				}

				if (item.Name != Sulfuras)
				{
					item.SellIn -= 1;
				}

				if (item.SellIn < 0)
				{
					if (item.Name != AngedBrie)
					{
						if (item.Name != Backstage)
						{
							if (item.Quality > 0 && item.Name != Sulfuras)
							{
								item.Quality -= item.Name.Contains(Conjured) ? 2 : 1;
							}
						}
						else
						{
							item.Quality = 0;
						}
					}
					else if (item.Quality < 50)
					{
						item.Quality++;
					}
				}
			});
		}
	}
}

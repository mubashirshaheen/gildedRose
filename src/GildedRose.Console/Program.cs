using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

     
        public void UpdateQuality()
        {           
                foreach (var item in Items)
                {
                    if (item.Name == "Sulfuras, Hand of Ragnaros")
                    {
                        // Sulfuras is a legendary item and its Quality never changes
                        continue;
                    }
                    item.SellIn--;

                    if (item.Name == "Aged Brie")
                    {
                        // Aged Brie increases in Quality as it ages
                        item.Quality = Math.Min(item.Quality + 1, 50);
                    }
                    else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        // Backstage passes increase in Quality as the concert date approaches
                        if (item.SellIn < 0)
                        {
                            item.Quality = 0;
                        }
                        else if (item.SellIn < 5)
                        {
                            item.Quality = Math.Min(item.Quality + 3, 50);
                        }
                        else if (item.SellIn < 10)
                        {
                            item.Quality = Math.Min(item.Quality + 2, 50);
                        }
                        else
                        {
                            item.Quality = Math.Min(item.Quality + 1, 50);
                        }
                    }
                    else if (item.Name == "Conjured Mana Cake")
                    {
                        // Conjured items degrade in Quality twice as fast as normal items
                        item.Quality = Math.Max(item.Quality - 2, 0);
                    }
                    else
                    {
                        // All other items degrade in Quality as they age
                        item.Quality = Math.Max(item.Quality - 1, 0);
                        if (item.SellIn < 0)
                        {
                            // Once the sell by date has passed, Quality degrades twice as fast
                            item.Quality = Math.Max(item.Quality - 1, 0);
                        }
                    }
                }
            

        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}

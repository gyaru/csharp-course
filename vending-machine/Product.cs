using System;

namespace vending_machine
{
    public abstract class Product
    {
        public string Name { get; protected init; }
        public int Price { get; protected init; }
        public int Stock { get; set; }

        public virtual string Examine()
        {
            return $"You bought: {Name} for the price of {Price}kr and there's {Stock} left in stock.";
        }

        public virtual string Use()
        {
            return "no clue how to use this, error!";
        }
    }

    internal class ProductFood : Product
    {
        public ProductFood(string name, int price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override string Use()
        {
            return $"You devour the delicious {Name}.";
        }
    }

    internal class ProductToy : Product
    {
        public ProductToy(string name, int price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override string Use()
        {
            Random rnd = new();
            int feelingLucky = rnd.Next(1, 5);
            return feelingLucky == 2
                ? "You open the booster pack and somehow find a Black Lotus, wow!"
                : "You open the booster pack and didn't get anything fun at all, sucks!";
        }
    }

    public class ProductDrink : Product
    {
        public ProductDrink(string name, int price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override string Use()
        {
            return $"You drink the {Name}, you suddenly feel energetic!";
        }
    }
}
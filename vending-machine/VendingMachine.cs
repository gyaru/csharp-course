using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace vending_machine
{
    public class VendingMachine : Product, IVending
    {
        private static Dictionary<int, Product> _availableProducts;
        private static bool _productsLoaded;
        private readonly Currency _cd;

        public int Money { get; private set; }

        public VendingMachine()
        {
            _cd = new Currency();
        }

        public Dictionary<int, Product> GetProducts()
        {
            if (!_productsLoaded)
            {
                PopulateProducts();
            }

            return _availableProducts;
        }

        public string ShowAll()
        {
            const string productList = "\nId\tName\tPrice\tStock";
            if (!_productsLoaded)
            {
                PopulateProducts();
            }

            return _availableProducts.Aggregate(productList,
                (current, product) =>
                    current +
                    $"\n{product.Key}\t{product.Value.Name}\t{product.Value.Price}kr\t{product.Value.Stock}");
        }


        public int Insert(int denomination, int quantity)
        {
            int result = 0;
            int previousValue = Money;
            bool validDenomination =
                ((IList) _cd.Denominations).Contains(denomination) && denomination > 0 && quantity > 0;
            if (!validDenomination) return result;
            int insertedAmount = denomination * quantity;
            Money += insertedAmount;
            result = Money - previousValue;
            return result;
        }
        
        public Product Purchase(int key)
        {
            bool productIsAvailable = _availableProducts.ContainsKey(key) && _availableProducts[key].Stock > 0;
            if (!productIsAvailable || _availableProducts[key].Price > Money) return null;
            _availableProducts[key].Stock -= 1;
            Money -= _availableProducts[key].Price;
            Product purchasedItem = _availableProducts[key];
            return purchasedItem;
        }


        public int[,] EndTransaction()
        {
            int length = _cd.Denominations.Length;
            int[] denominations = _cd.Denominations;
            int[,] change = new int[length, length];
            int remaining = 0;
            for (int i = 0; i < length; i++)
            {
                change[i, 0] = remaining / denominations[i];
                change[i, 1] = denominations[i];
                remaining %= denominations[i];
            }

            Money = 0;
            return change;
        }
        
        public static void PopulateProducts()
        {
            if (_productsLoaded) return;
            _availableProducts = new Dictionary<int, Product>();
            int id = 0;
            _availableProducts.Add(id++, new ProductToy("Magic: The Gathering - Core 2021 Booster Pack", 40, 40));
            _availableProducts.Add(id++, new ProductDrink("Monster Energy Ultra", 20, 5));
            _availableProducts.Add(id, new ProductFood("Gott & Blandat Supersur", 20, 10));
            _productsLoaded = true;
        }
    }
}
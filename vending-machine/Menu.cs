using System;

namespace vending_machine
{
    public class VendingMachineUi
    {
        private readonly VendingMachine _vendingMachine;
        private readonly Currency _cd;
        private bool _active;

        public VendingMachineUi()
        {
            _vendingMachine = new VendingMachine();
            _cd = new Currency();
            _active = false;
        }

        public static void Initialize()
        {
            VendingMachine.PopulateProducts();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the vending machine.\n" +
                              "1) Deposit money.\n" +
                              "2) Show all products.\n" +
                              "3) Purchase a product.\n" +
                              "4) Show current balance.\n" +
                              "5) Get change.\n" +
                              "0) Exit\n" +
                              "Press a number to select.");
            switch (Console.ReadLine())
            {
                case "0":
                    Environment.Exit(1);
                    break;
                case "1":
                    Transaction();
                    return;
                case "2":
                    Console.WriteLine(DisplayProducts());
                    Console.ReadKey();
                    return;
                case "3":
                    Purchase();
                    return;
                case "4":
                    Console.WriteLine($"Balance: {Balance()}kr");
                    Console.ReadKey();
                    return;
                case "5":
                    Console.WriteLine($"Balance: {Balance()}\n" +
                                      $"{Change()}");
                    return;
                default:
                    return;
            }
        }

        private void Purchase()
        {
            var availableProducts = _vendingMachine.GetProducts();
            _active = true;
            while (_active)
            {
                Console.WriteLine(DisplayProducts());
                Console.WriteLine($"Balance: {Balance()}kr\n" +
                                  "What do you want to buy? select a product with the corresponding number:");
                int selected = SelectProduct();
                if (selected < 0)
                {
                    _active = false;
                    Menu();
                }
                else if (availableProducts[selected].Price > Balance())
                {
                    Console.WriteLine("Your balance is too low, would you like to deposit some cash?");
                    Console.WriteLine($"Balance = {Balance()}kr\n" +
                                      "Press y to deposit more money or press any other key to go back to the product menu.");
                    ConsoleKeyInfo reply = Console.ReadKey(true);
                    if (reply.Key == ConsoleKey.Y)
                    {
                        Transaction();
                    }
                }
                else if (availableProducts[selected].Stock == 0)
                {
                    Console.WriteLine(
                        $"{availableProducts[selected].Name} is currently out of stock, you'll have to settle for something else.");
                    Console.ReadKey();
                }
                else
                {
                    Product purchasedProduct = _vendingMachine.Purchase(selected);
                    Console.WriteLine($"{purchasedProduct.Examine()}");
                    Console.WriteLine("Press any key to interact with what you just bought.");
                    Console.ReadKey();
                    Console.WriteLine($"{purchasedProduct.Use()}");
                    Console.ReadKey();
                }
            }
        }

        private int Balance()
        {
            return _vendingMachine.Money;
        }

        private string GetDenominationInfo()
        {
            Console.WriteLine("What denomination do you want to insert?");
            string denominationList = "";
            for (int index = _cd.Denominations.Length - 1; index >= 0; index--)
            {
                denominationList += $"\n{index}) {_cd.Denominations[index]}kr";
            }

            return denominationList;
        }

        private void Transaction()
        {
            bool transaction = true;
            while (transaction)
            {
                Console.WriteLine($"Current balance = {Balance()}kr");
                int[] cashDeposit = CashDepositValue();
                _vendingMachine.Insert(cashDeposit[0], cashDeposit[1]);
                Console.WriteLine($"Your current balance is: {Balance()}, do you want to insert more money?\n" +
                                  "Press y for additional depositing or press any other key to go back to the menu.");
                string reply = Console.ReadLine();
                if (reply == "y")
                {
                    continue;
                }

                transaction = false;
            }
        }

        private int[] CashDepositValue()
        {
            int[] inputDenomination = new int[2];
            Console.WriteLine(GetDenominationInfo());
            int maxValue = _cd.Denominations.Length - 1;
            const int minValue = 0;
            int denominationId = GetUserInput(minValue, maxValue);
            if (denominationId < 0)
            {
                inputDenomination[1] = 0;
                return inputDenomination;
            }

            Console.WriteLine(
                $"You've selected the denomination: {_cd.Denominations[denominationId]}kr\n" +
                "How many are you inserting?");
            int quantity = GetUserInput(minValue, 100);
            inputDenomination[0] = _cd.Denominations[denominationId];
            inputDenomination[1] = quantity;

            return inputDenomination;
        }

        private int SelectProduct()
        {
            int maxValue = _vendingMachine.GetProducts().Count - 1;
            int selected = GetUserInput(0, maxValue);
            return selected;
        }

        private int GetUserInput(int min, int max)
        {
            bool validated = false;
            Console.WriteLine($"Enter a number between {min}-{max} or type menu to go back to the menu.");
            int valid = 0;
            while (!validated)
            {
                string userInput = Console.ReadLine();
                if (userInput == "menu")
                {
                    _active = false;
                    return -1;
                }

                if (!int.TryParse(userInput, out valid)) continue;
                if (min <= valid && valid <= max)
                {
                    validated = true;
                }
                else
                {
                    Console.WriteLine($"error, type something between {min} or {max}");
                }
            }

            return valid;
        }

        private string Change()
        {
            int deposit = Balance();
            string message = $"You're getting {deposit} kr back in change.";
            int[,] change = _vendingMachine.EndTransaction();
            if (deposit == 0)
            {
                message += "There is no change to be had.";
            }

            for (int index = _cd.Denominations.Length - 1; index >= 0; index--)
            {
                message += change[index, 0] > 0
                    ? "\n\t" + change[index, 0] + " x " + _cd.Denominations[index] + "kr"
                    : "";
            }

            _active = false;
            return message;
        }

        private string DisplayProducts()
        {
            return _vendingMachine.ShowAll();
        }
    }
}
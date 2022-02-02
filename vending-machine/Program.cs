namespace vending_machine
{
    internal static class Program
    {
        private static void Main()
        {
            VendingMachineUi menu = new();
            VendingMachineUi.Initialize();
            while (true)
            {
                menu.Menu();
            }
        }
    }
}
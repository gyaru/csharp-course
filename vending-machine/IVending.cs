namespace vending_machine
{
    public interface IVending
    {
        Product Purchase(int key);

        string ShowAll();

        int Insert(int denomination, int quantity);

        int[,] EndTransaction();
    }
}
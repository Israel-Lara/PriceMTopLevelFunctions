partial class Program
{
    public static void TimesTable(byte table, byte rowsLimit)
    {
        for (int row =1; row <=rowsLimit; row++)
        {
            Console.WriteLine($"| {row} x {table} = {row*table} |");
        }

    }


}

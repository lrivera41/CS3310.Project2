namespace CS3310.Project2;

public class Program
{
    private static int inversions;
    public static void Main(string[] args)
    {
        inversions = 0;
        var array = new int[] { 3, 1, 2 };
        Sort(array);
        Console.WriteLine($"Sorted array: {string.Join(", ", array)}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");
        
        inversions = 0;
        array = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
        Sort(array);
        Console.WriteLine($"Sorted array: {string.Join(", ", array)}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");
    }

    private static void Sort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                var temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
                inversions++; 
            }
        }
    }
}

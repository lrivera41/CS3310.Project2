namespace CS3310.Project2;

public class Program
{
    private static int inversions;
    private static readonly string RootDirectory = @"C:\Users\luismi\Documents\source\School\CS3310.Project2\CS3310.Project2\CS3310.Project2\CS3310.Project2";
    public static void Main(string[] args)
    {
        inversions = 0;
        var array = new int[] { 3, 1, 2 };
        CountInverse(array);
        Console.WriteLine($"Array: {string.Join(", ", array)}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");

        inversions = 0;
        array = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
        CountInverse(array);
        Console.WriteLine($"Array: {string.Join(", ", array)}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");

        inversions = 0;
        array = ExtractFile("problem3.5test.txt");
        CountInverse(array);
        Console.WriteLine($"Array: {string.Join(", ", array ?? [])}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");

        inversions = 0;
        array = ExtractFile("problem3.5.txt");
        CountInverse(array);
        Console.WriteLine($"Array: {string.Join(", ", array ?? [])}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");
    }

    private static int[]? ExtractFile(string fileName)
    {
        int[] array = Array.Empty<int>();
        var filePath = Path.Combine(RootDirectory, fileName);
        if (!File.Exists(filePath)) return null;
        var list = File.ReadLines(filePath)
                       .Where(line => !string.IsNullOrWhiteSpace(line))
                       .Select(line => int.Parse(line.Trim()))
                       .ToList();

        array = list.ToArray();

        return array;
    }

    private static void CountInverse(int[]? array)
    {
        if (array is null) return;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j]) inversions++;
            }
        }
    }
}

namespace CS3310.Project2;

public class Program
{
    private static long inversions;
    private static readonly string RootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../"));
    public static void Main(string[] args)
    {
        int[] array = [1, 2, 3];
        array = SortAndCount(array);
        Console.WriteLine($"Sorted Array: {string.Join(", ", array)}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");

        array = [3, 1, 2];
        array = SortAndCount(array);
        Console.WriteLine($"Sorted Array: {string.Join(", ", array)}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");

        array = ExtractFile("problem3.5test.txt");
        array = SortAndCount(array);
        Console.WriteLine($"Sorted Array: {string.Join(", ", array ?? [])}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");

        array = ExtractFile("problem3.5.txt");
        array = SortAndCount(array);
        //Console.WriteLine($"Array: {string.Join(", ", array ?? [])}");
        Console.WriteLine($"Inversions {inversions}{Environment.NewLine}");
    }

    private static int[] ExtractFile(string fileName)
    {
        int[] array = Array.Empty<int>();
        var filePath = Path.Combine(RootDirectory, fileName);
        if (!File.Exists(filePath)) throw new($"File path \"{filePath}\" does not exist");
        var list = File.ReadLines(filePath)
                       .Where(line => !string.IsNullOrWhiteSpace(line))
                       .Select(line => int.Parse(line.Trim()))
                       .ToList();

        array = list.ToArray();

        return array;
    }

    private static int[] SortAndCount(int[] array)
    {
        inversions = 0;
        var sortedArray = MergeSortAndCount(array);
        return sortedArray;
    }

    private static int[] MergeSortAndCount(int[] array)
    {
        if (array.Length <= 1) return array;
        int mid = array.Length / 2;
        int[] left = array[..mid];
        int[] right = array[mid..];
        left = MergeSortAndCount(left);
        right = MergeSortAndCount(right);
        return MergeAndCount(left, right);
    }

    private static int[] MergeAndCount(int[] left, int[] right)
    {
        int i = 0, j = 0;
        List<int> merged = new();
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                merged.Add(left[i]);
                i++;
            }
            else
            {
                merged.Add(right[j]);
                inversions += left.Length - i;
                j++;
            }
        }
        while (i < left.Length)
        {
            merged.Add(left[i]);
            i++;
        }
        while (j < right.Length)
        {
            merged.Add(right[j]);
            j++;
        }
        return merged.ToArray();
    }
}

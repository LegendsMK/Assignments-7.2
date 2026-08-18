//Implement merge sort on an unsorted array of numbers.
//Take the array input from user.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("   Merge Sort   ");

        int[] numbers = GetArrayFromUser();

        //User incompetence failsafe
        if (numbers.Length == 0)
        {
            Console.WriteLine("Empty array, cannot sort");
            return;
        }

        Console.WriteLine("\nOriginal array:");
        PrintArray(numbers);

        MergeSort(numbers, 0, numbers.Length - 1);

        Console.WriteLine("\nSorted Array:");
        PrintArray(numbers);
    }

    //Method to prompt user for Array
    static int[] GetArrayFromUser()
    {
        Console.Write("Enter the number of elements: ");
        if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
        {
            Console.WriteLine("Invalid size entered, creating an empty array.");
            return new int[0];
        }

        int[] arr = new int[size];
        Console.WriteLine($"Enter {size} integers (press Enter after each):");

        for (int i = 0; i < size; i++)
        {
            while (true)
            {
                Console.Write($"Element [{i}]: ");
                if (int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    break;
                }
                Console.WriteLine("Invalid input, enter an integer.");
            }
        }
        return arr;
    }

    //Method to merge
    static void Merge(int[] array, int left, int middle, int right)
    {
        //Sizing the two halves of the array
        int n1 = middle - left + 1;
        int n2 = right - middle;

        //Temp storage for numbers
        int[] leftTempArray = new int[n1];
        int[] rightTempArray = new int[n2];

        //Copy data from left array into left Temp
        for (int index = 0; index < n1; index++)
        {
            leftTempArray[index] = array[left + index];
        }

        //Copy data from right array into right Temp
        for (int index = 0; index < n2; index++)
        {
            rightTempArray[index] = array[middle + 1 + index];
        }

        //Create pointers i = left arrary, j = right array, k = main array
        int i = 0;
        int j = 0;
        int k = left;

        //Reconstruction in ascending order
        while (i < n1 && j < n2)
        {
            if (leftTempArray[i] <= rightTempArray[j])
            {
                array[k] = leftTempArray[i];
                i++;
            }
            else
            {
                array[k] = rightTempArray[j];
                j++;
            }
            k++;
        }
        //Gather remaining values from the left temp segment
        while (i < n1)
        {
            array[k] = leftTempArray[i];
            i++;
            k++;
        }

        //Gather remaining values from the right temp segment
        while (j < n2)
        {
            array[k] = rightTempArray[j];
            j++;
            k++;
        }
    }
    //Method to merge sort
    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;

            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);

            Merge(array, left, middle, right);
        }
    }

    //Display method
    static void PrintArray(int[] array)
    {
        Console.Write("[ ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i < array.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" ]");
    }
}

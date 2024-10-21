using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4,0};
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 3, 2, 4 };
            int target = 6;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2};
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 5;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                if (nums == null)
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null");
                List<int> result = new List<int>();
                int n = nums.Length;
                // Creating a boolean array to mark present numbers
                bool[] present = new bool[n + 1];

                // If number is within valid range (1 to n), marking it as present
                foreach (int num in nums)
                {
                    if (num <= n)
                    {
                        present[num] = true;
                    }
                }

                // Checking which numbers from 1 to n are missing
                // If number is not marked as present, adding it to result
                for (int i = 1; i <= n; i++)
                {
                    if (!present[i])
                    {
                        result.Add(i);
                    }
                }

                return result;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                if (nums == null)
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null");

                List<int> evenNums = new List<int>();
                List<int> oddNums = new List<int>();

                // Separating even and odd numbers
                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                        evenNums.Add(num);
                    else
                        oddNums.Add(num);
                }

                // Sorting sorted even numbers in ascending order
                evenNums.Sort();
                

                // Combining the sorted lists
                int[] result = new int[nums.Length];
                int index = 0;

                // Adding even numbers first
                foreach (int num in evenNums)
                {
                    result[index++] = num;
                }

                // Adding odd numbers next
                foreach (int num in oddNums)
                {
                    result[index++] = num;
                }

                return result;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                if (nums == null)
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null");
                if (nums.Length < 2)
                    throw new ArgumentException("Array must contain at least 2 elements");

                Dictionary<int, int> numMap = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    // Calculate the complement needed to reach target
                    int complement = target - nums[i];

                    // If complement exists in dictionary, we found a pair
                    if (numMap.ContainsKey(complement))
                    {
                        return new int[] { numMap[complement], i };
                    }

                    // Adding current number and its index to dictionary if not present
                    if (!numMap.ContainsKey(nums[i]))
                    {
                        numMap.Add(nums[i], i);
                    }
                }

                return new int[0]; // Returns empty array if no solution found
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                if (nums == null)
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null");
                if (nums.Length < 3)
                    throw new ArgumentException("Array must contain at least 3 elements");
                // Sorting array to easily find largest and smallest numbers
                Array.Sort(nums);
                int n = nums.Length;

                // Returns maximum of:
                // 1. Product of three largest numbers
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],
                              nums[0] * nums[1] * nums[n - 1]);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber < 0)
                    throw new ArgumentException("Input must be a non-negative integer");
                // Handling special case of zero
                if (decimalNumber == 0)
                    return "0";

                string binary = "";
                // Repeatedly divide by 2 and prepend remainder to result
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber /= 2;
                }

                return binary;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                if (nums == null)
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null");
                if (nums.Length == 0)
                    throw new ArgumentException("Array cannot be empty");

                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // If middle element is greater than rightmost element,
                    // minimum must be in right half
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    // Otherwise, minimum must be in left half (including mid)
                    else
                    {
                        right = mid;
                    }
                }

                return nums[left]; // Left pointer will be at minimum element
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindromes
                if (x < 0)
                    return false;

                // Convert to string for easy comparison
                string numStr = x.ToString();
                int left = 0;
                int right = numStr.Length - 1;

                // Use two pointers to check if string reads same from both ends
                while (left < right)
                {
                    if (numStr[left] != numStr[right])
                        return false;
                    left++;
                    right--;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n < 0 || n > 30)
                    throw new ArgumentOutOfRangeException(nameof(n), "Input must be between 0 and 30 inclusive");

                if (n <= 1)
                    return n;

                int prev1 = 1;
                int prev2 = 0;
                int current = 0;

                for (int i = 2; i <= n; i++)
                {
                    current = prev1 + prev2;
                    prev2 = prev1;
                    prev1 = current;
                }

                return current;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}

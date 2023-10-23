

using System;
using System.Text;
using System.Collections.Generic;

namespace ISM6225_Fall_2023_Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Handle the case when array is empty, return a range to cover full specified range.
                if (nums == null || nums.Length == 0)
                {
                    return new List<IList<int>> { GetRange(lower, upper) };
                }

                IList<IList<int>> rangemiss = new List<IList<int>>();
                long start = (long)lower;

                // Iterate through the array to find missing ranges.
                foreach (int num in nums)
                {
                    // If there's a gap between 'start' and the current 'num', add it as a missing range.
                    if (num > start)
                    {
                        rangemiss.Add(GetRange(start, num - 1));
                    }
                    // Update 'start' to the next potential starting point.
                    start = (long)num + 1;
                }

                // If there's a missing range from the last 'start' to 'upper'.
                if (start <= upper)
                {
                    rangemiss.Add(GetRange(start, upper));
                }

                return rangemiss;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GetRange method creates a list to represent range from 'start' to 'end'.
        // The list contains two elements, 'start' as the first one and 'end' as the second one.
        public static IList<int> GetRange(long start, long end)
        {
            return new List<int> { (int)start, (int)end };
        }



        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                Stack<char> stack = new Stack<char>();  // Create a stack to keep track of open brackets

                foreach (char c in s)
                {
                    // Check if the current character is an open bracket
                    if (c == '(' || c == '{' || c == '[')
                    {
                        stack.Push(c);  // If open bracket, push onto the stack
                    }
                    else
                    {
                        // If the current character is a closing bracket
                        if (stack.Count == 0)
                        {
                            // If there are no open brackets available for matching, the expression is unbalanced.
                            return false;
                        }

                        char openbrkt = stack.Pop();  // Remove the most recently added open bracket from the stack.

                        // Check the current closing bracket matches the corresponding open bracket
                        if (c == ')' && openbrkt != '(') return false;
                        if (c == '}' && openbrkt != '{') return false;
                        if (c == ']' && openbrkt != '[') return false;
                    }
                }

                // Check if there are any remaining open brackets in the stack
                return stack.Count == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                if (prices == null || prices.Length < 2)
                {
                    // If there are insufficient days for transactions, return a profit of 0.
                    return 0;
                }

                int minprice = prices[0];
                int maxprofit = 0;

                // Iterate through the prices to determine the maximum profit.
                for (int i = 1; i < prices.Length; i++)
                {
                    int currentPrice = prices[i];

                    if (currentPrice < minprice)
                    {
                        // Update the minimum price if a lower price is encountered.
                        minprice = currentPrice;
                    }
                    else
                    {
                        // Calculate the potential profit if selling at the current price.
                        int potentialProfit = currentPrice - minprice;
                        if (potentialProfit > maxprofit)
                        {
                            // Update the maximum profit if a higher potential profit is found.
                            maxprofit = potentialProfit;
                        }
                    }
                }

                // Return the calculated maximum profit.
                return maxprofit;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {

                // Write your code here and you can modify the return value according to the requirements
                 // Check if the input string is null or empty, in which case it is not strobogrammatic.
                    if (string.IsNullOrEmpty(s))
                    {
                        return false;
                    }

                    // Initialize two pointers, 'left' pointing to the start of the string,
                    // and 'right' pointing to the end of the string.
                    int left = 0;
                    int right = s.Length - 1;

                    // Iterate through the string while the 'left' pointer is less than or equal to the 'right' pointer.
                    while (left <= right)
                    {
                        char leftChar = s[left];
                        char rightChar = s[right];

                        // Check if the characters at the 'left' and 'right' positions form a valid pair:
                        if (leftChar == '0' && rightChar == '0' ||
                            leftChar == '1' && rightChar == '1' ||
                            leftChar == '8' && rightChar == '8' ||
                            leftChar == '6' && rightChar == '9' ||
                            leftChar == '9' && rightChar == '6')
                        {
                            // Move the 'left' pointer one step to the right and the 'right' pointer one step to the left.
                            left++;
                            right--;
                        }
                        else
                        {
                            // If the characters do not form a valid pair, the string is not a valid strobogrammatic number.
                            return false;
                    }
                }

                // If the entire string has been checked and all pairs are valid, the string is a valid strobogrammatic number.
                return true;
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

      public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                //Creating an array to keep track of the frequency of each number.
                int[] occurrences = new int[101]; // Since 1 <= nums[i] <= 100

                int perfectpairs = 0;

                // Iterate through the array and count occurrences
                foreach (int num in nums)
                {
                    // For each occurrence, increment perfectpairs by the current count
                    perfectpairs += occurrences[num];

                    // Increment the count of occurrences for the current number
                    occurrences[num]++;
                }

                return perfectpairs;
                
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

       public static int ThirdMax(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Store unique numbers in descending order using a HashSet.
                HashSet<int> uniqnums = new HashSet<int>(nums);

                // If unique numbers are less than 3, return the maximum number
                if (uniqnums.Count < 3)
                {
                    return uniqnums.Max();
                }

                // else, return the third maximum
                int thirdMax = uniqnums.OrderByDescending(n => n).ElementAt(2);
                return thirdMax;
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

       public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                IList<string> moves = new List<string>();

                // Iterate the string to find right moves
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // make a move by flipping "++" to "--"
                        char[] nextState = currentState.ToCharArray();
                        nextState[i] = '-';
                        nextState[i + 1] = '-';
                        moves.Add(new string(nextState));
                    }
                }

                return moves;
                

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

     public static string RemoveVowels(string s)
        {
            // Write your code here and you can modify the return value according to the requirements
            // Convert string to a character array
            char[] charray = s.ToCharArray();

            // Create StringBuilder to build the result
            System.Text.StringBuilder result = new System.Text.StringBuilder();

            // Iterate through each character in the array
            foreach (char c in charray)
            {
                // Check if the character is vowel (a, e, i, o, u)
                if (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
                {
                    // Append the non-vowel character to result
                    result.Append(c);
                }
            }

            // Convert the StringBuilder to a string and return the result

            return $"\"{result.ToString()}\"";
            


        }

        /* Inbuilt Functions - Don't Change the below functions */
       public static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


      public  static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
    

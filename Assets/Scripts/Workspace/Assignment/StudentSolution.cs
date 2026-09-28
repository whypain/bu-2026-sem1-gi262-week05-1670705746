using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture
        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            return numbers;
        }

        public int[] LCT02_BubbleSortAscending(int[] numbers)
        {
            return numbers;
        }

        public int[] LCT03_InsertionSortAscending(int[] numbers)
        {
            return numbers;
        }

        #endregion

        #region Assignment

        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int largest = int.MinValue;
                int largestIndex = -1;
                for (int j = i; j < numbers.Length; j++)
                {
                    int num = numbers[j];
                    if (num > largest)
                    {
                        largest = num;
                        largestIndex = j;
                    }
                }

                if (largestIndex == -1)
                    continue;

                int temp = numbers[i];
                numbers[i] = largest;
                numbers[largestIndex] = temp;
            }

            return numbers;
        }

        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            return numbers;
        }

        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] < current)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = current;
            }

            return numbers;
        }

        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            int[] sorted = AS01_SelectionSortDescending(numbers);
            var sortedHashSet = new HashSet<int>(sorted);
            return sortedHashSet.ElementAt(1);
        }

        #endregion

        #region Extra

        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            var sorted = AS01_SelectionSortDescending(numbers)
                .Distinct()
                .ToArray();

            int longestStreak = 1;
            int currStreak = 1;
            for (int j = 0; j < sorted.Length - 1; j++)
            {
                if (sorted[j] == sorted[j + 1] + 1)
                {
                    currStreak++;
                }
                else
                {
                    longestStreak = Mathf.Max(longestStreak, currStreak);
                    currStreak = 1;
                }
            }

            return Mathf.Max(longestStreak, currStreak);
        }

        #endregion
    }
}

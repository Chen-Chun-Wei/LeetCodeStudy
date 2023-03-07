using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {
        /// <summary>
        /// Input: nums = [2,7,11,15], target = 9
        //  Output: [0,1]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            // 網路解法，跟我的思維是反過來的，是把迴圈過的資料放入 Dictionary 中，再看目標值減去本次找的陣列值，是否有存在
            if (nums == null || nums.Length < 2)
                return new int[2];

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                { 
                    var result = new int[] { i, dic[target - nums[i]] };
                    return result;
                }
                else if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], i);
            }

            return new int[2];
            /*自己第一次寫法 速度跟效能都不好，想法是把陣列先加入一個新的 Dictionary，然後再排除本次比對的陣列Key，用迴圈一個個比對
            var bb = new Dictionary<int, int>();
            var cc = 0;
            foreach (var item in nums)
            {
                bb.Add(cc, item);
                cc++;
            }
            int firstIndex = 0;
            int secondIndex = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                int aa = target - nums[i];
                var gg = bb.Where(x => x.Key != i && x.Value == aa);
                if (gg.Any())
                {
                    secondIndex = gg.Select(x => x.Key).FirstOrDefault();
                    return new int[] { firstIndex, secondIndex };
                }
                else firstIndex++;
            }
            return new int[] { 0, 1 };
            */
        }


        /// <summary>
        /// 1523. Count Odd Numbers in an Interval Range
        /// 取奇數_原有寫法
        /// </summary>
        /// <returns></returns>
        public int CountOdds1(int low, int high)
        {
            int resultCount = 0;
            for (int i = low; i <= high; i++)
            {
                if (i % 2 != 0) resultCount++;
            }
            return resultCount;
        }

        /// <summary>
        /// 1523. Count Odd Numbers in an Interval Range
        /// 取奇數_最快寫法
        /// </summary>
        /// <returns></returns>
        public int CountOdds2(int low, int high)
        {
            if (low % 2 != 0 || high % 2 != 0) return ((high - low) / 2) + 1;
            else return (high - low) / 2 ;
        }

        /// <summary>
        /// 1491. Average Salary Excluding the Minimum and Maximum Salary
        /// 取平均薪資 但是排除 最大跟最小值
        /// </summary>
        public double Average1(int[] salary)
        {
            double result = 0;
            if (salary.Length >= 3)
            {
                double maxSalary = salary.Max();
                double minSalary = salary.Min();
                double countSalary = salary.Length - 2;
                double totalSalary = salary.Sum();
                result = (totalSalary - maxSalary - minSalary) / countSalary;
            }
            return result;
        }

        /// <summary>
        /// 191. Number of 1 Bits
        /// 取二進之中 有幾個 1
        /// </summary>
        public int HammingWeight(uint n)
        {
            /* 把輸入改成 string
            int result = 0;

            var stringList = n.Split('1');
            foreach (var item in stringList)
            {
                if (item == "")
                {
                    result++;
                }
            }
            return result;
            */
            
            uint mask = 1;

            var result = 0;

            while (n != 0)
            {
                result += (int)(n & mask);
                n >>= 1;
            }

            return result;
        }

        /// <summary>
        /// 1281. Subtract the Product and Sum of Digits of an Integer
        /// 取 input int n 的各別數字之乘積 與 各別數字之總和
        /// </summary>
        public int SubtractProductAndSum(int n)
        {
            var numbers = n.ToString().ToArray();
            int a = 1;
            int b = 0;
            foreach (var number in numbers)
            {
                a = a * number;
                b = b + number;
            }
            return a-b;
        }

        /// <summary>
        /// 1672. Richest Customer Wealth
        /// 取 input int[][]  N 個一維陣列中 的總數最大值
        /// </summary>
        public int MaximumWealth(int[][] accounts)
        {
            int result = 0;
            foreach (var account in accounts)
            {
                var r = account.Sum();
                if(r > result) result = r;
            }
            return result;
        }

        /// <summary>
        /// 412. Fizz Buzz
        /// 取 input 的數字去跑回圈，如果遇到 對應的數字換成指定 string  
        /// </summary>
        public IList<string> FizzBuzz(int n)
        {
            var result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) result.Add("FizzBuzz");
                else if (i % 3 == 0) result.Add("Fizz");
                else if (i % 5 == 0) result.Add("Buzz");
                else result.Add(i.ToString());
            }
            return result;
        }

        /// <summary>
        /// 1342. Number of Steps to Reduce a Number to Zero
        /// 將 input 的數字歸零 需要幾個步驟
        /// </summary>
        public int NumberOfSteps(int num)
        {
            if (num == 0) return 0;
            var result = 0;
            do 
            {
                //如果是偶數
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                //如果是奇數
                else 
                {
                    num--;
                }
                result++;
            }
            while (num > 0);

            return result;
        }

        /// <summary>
        /// 876. Middle of the Linked List
        /// 取 input 的 model 的中間值
        /// </summary>
        public class ListNode 
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode MiddleNode(ListNode head)
        {
            ListNode faster = head; // head as slow runner
            while (faster != null && faster.next != null)
            {
                faster = faster.next.next;
                head = head.next;
            }
            return head;
        }

        /// <summary>
        /// 383. Ransom Note 贖金信
        /// 取 input 的兩個字串中 magazine 如果有 ransomNote 的字母要回 True 
        /// </summary>
        public bool CanConstruct(string ransomNote, string magazine)
        {
            //先建立一個比對用的 Dictionary
            Dictionary<char, int> letters = new Dictionary<char, int>();
            
            //迴圈將右手的資料 英文字拆分結構，同字母 Value 會往上+1，代表字母連在一起
            foreach (char c in magazine)
                letters[c] = (letters.ContainsKey(c)) ? letters[c] + 1 : 1;

            //迴圈將左手的資料 英文字拆分結構，並逐筆字母比對，看是否存在又手的資料，如果存在，比對用的 Value 會-1
            foreach (char c in ransomNote)
            { 
                //var aa = letters[c];
                if (letters.ContainsKey(c) && letters[c] > 0)
                {
                    letters[c]--;
                }
                else
                    return false;
            }    
            return true;
        }
    }
}

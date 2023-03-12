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
        /// 1. Two Sum 兩數之和 
        /// 說明 : 在一個輸入的整數陣列中，算出兩數相加 等於 target 的目標值，在輸出 是哪兩個值得 index
        ///  Input: nums = [2,7,11,15], target = 9
        ///  Output: [0,1]
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
            //自己第一次寫法 速度跟效能都不好，想法是把陣列先加入一個新的 Dictionary，然後再排除本次比對的陣列Key，用迴圈一個個比對
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
            
        }

        /// <summary>
        /// 2. Add Two Numbers 
        /// 說明 : 兩位數相加，但是要 output LinkList 結構
        /// Input: l1 = [2,4,3], l2 = [5,6,4]
        /// Output: [7,0,8]
        /// Explanation: 342 + 465 = 807.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            /* 網友思路版本 https://www.youtube.com/watch?v=wDf2wcyP1iU
            //初始點 
            var dummy = new ListNode(-1);
            //新設一個 pre 節點 類似 result
            var pre = dummy;
            var p1 = l1;
            var p2 = l2;
            //記錄進位值
            int carry = 0;
            while (p1 != null || p2 != null)
            { 
                //取現在當前節點的 LinkList 的 val 值
                int x = p1 != null ? p1.val : 0;
                int y = p2 != null ? p2.val : 0;
                //總和 = 將兩個 LinkList 與 上一次計算的進位加總
                int sum = carry + x + y;
                //計算進位值 = 總和 /10 如果有值代表下一次要加
                carry = sum / 10;
                //設定現在 pre 節點的下一個數值
                pre.next = new ListNode(sum % 10);
                //
                pre = pre.next;
                //將 p1 與 p2 的 LinkList 往下一個節點設定
                if (p1 != null) p1 = p1.next;
                if (p2 != null) p2 = p2.next;
            }
            //若迴圈跑完，還是有近位，代表下一個位數要加上
            if (carry > 0)
                pre.next = new ListNode(carry);
            //dummy 最後會是 -1 7 0 8，因為 .next 所以輸出是 7 0 8
            return dummy.next;
            */

            //自己做一次
            //設定初始點 -1， 因為範例只位有正整數
            var result = new ListNode(-1);
            //設定 等等實作的 per 節點
            var pre = result;
            //設定進位值
            int carry = 0;
            //只要 LinkList 還有值都要做
            while (l1 != null || l2 != null)
            { 
                //取現在節點的值，沒有就帶0
                int x = l1 != null ? l1.val : 0;
                int y = l2 != null ? l2.val : 0;
                //總和 = 進位值+兩者相加
                int sum = carry + x + y;
                //判斷總和有無超過 10 ，有則需紀錄後續使用
                carry = sum / 10;
                //設定 pre 節點為本次總和的個位數
                pre.next = new ListNode(sum % 10);
                //將結點往前移動
                pre = pre.next;
                //設定下一個迴圈要跑的節點
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            //代表迴圈跑完，但還是有進位
            if (carry > 0) 
            { 
                pre.next = new ListNode(carry);
            }
            return result.next;
        }

        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// 說明 : 在一串字串中，找出最長且不重複的字串，需應用 Sliding Window 的概念
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            //如果 無字串 返回0
            if (s.Length == 0) return 0;
            //如果 字串1 返回1
            if (s.Length == 1) return 1;
            //如果字串 >1 才需實作比對內容
            int result = 0;
            var map = new int[256];
            //第一個指針
            int start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                
            }

            return result;
        }

        /// <summary>
        /// 209. Minimum Size Subarray Sum 
        /// 說明 : 取陣列中的整數相加>= target 數，並找出最使用的數字幾次
        /// https://www.youtube.com/watch?v=176lP8rE0o4&list=PL7O5Ubado0Q08ES5dVgnw1w30XkADz5q8&index=16
        /// Input: target = 7, nums = [2,3,1,2,4,3]
        /// Output: 2
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int target, int[] nums)
        {
            /*網路解法
            //輸出預設 int 最大，因為此需求要比小
            var output = int.MaxValue;
            //建立 紀錄與幾個數字相加的比較暫存
            int curr_length = 0;
            //建立 紀錄回圈內數字的總和，拿來判斷是否有超過 Target 的基準
            int curr_sum = 0;
            //建立 起始指針 startIndex
            int startIndex = 0;
            //迴圈 endIndex 是第二指針
            for (int endIndex =0; endIndex <nums.Length; endIndex++)
            {
                //由第二指針開始相加數字，且每次相加時要把長度也記起來
                curr_sum += nums[endIndex];
                curr_length++;
                //如果相加的數字總和 >= Target
                while (curr_sum >= target)
                {
                    //輸出 用 Math.Min 抓兩者最小的數字
                    output = Math.Min(output, curr_length);
                    //減掉窗戶左邊的數值
                    curr_sum = curr_sum - nums[startIndex];
                    //減掉窗戶的寬度 (次數)
                    curr_length--;
                    //指針往後一個
                    startIndex++;
                }
            }
            //如果 output 沒變代表沒有進到 while 回圈內，就回 0 
            if (output == int.MaxValue) return 0;
            return output;
            */

            //自己寫一次
            int result = int.MaxValue;
            int curr_lenght = 0;
            int curr_sum = 0;
            int startIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                curr_sum = curr_sum + nums[i];
                curr_lenght++;
                while (curr_sum >= target)
                { 
                    result = Math.Min(result, curr_lenght);
                    curr_sum = curr_sum - nums[startIndex];
                    curr_lenght--;
                    startIndex++;
                }
            }
            if (result == int.MaxValue) return 0;
            return result;
        }


        /// <summary>
        /// 340. Longest Substring with At Most K Distinct Characters
        /// 在 input 字串中找出 最長的字，且需不同字但不能超過 target 規範的值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 
        public int Get304(string input, int target)
        {
            return 0;
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

}

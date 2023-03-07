using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

public class ArraySolution
{
    /// <summary>
    /// Max Consecutive Ones 最大連續數，找出 input 陣列中，連續出現 1 的次數
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int count = 0;
        int result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                count++;
                if (count > result) result = count;
            }
            else
            {
                count = 0;
            }
        }
        return result;
    }

    /// <summary>
    /// Find Numbers with Even Number of Digits ， 找出 input 陣列中，數字的位數是偶數有幾次 EX: 雙位數10 千位數 1000...依此類推
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int FindNumbers(int[] nums)
    {
        int result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i].ToString().Length % 2 == 0) result++;
        }
        return result;
    }

    /// <summary>
    /// Squares of a Sorted Array，找出 input 陣列中，每個整數的平方後再由小到大排序
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] SortedSquares(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var aa = Math.Pow(nums[i], 2);
            nums[i] = (int)Math.Pow(nums[i], 2);
        }
        Array.Sort(nums);
        return nums;
    }

    /// <summary>
    /// Duplicate Zeros，找出 input 陣列中，如果遇到數字 0 ，就在此位置後插入一個 0，讓後面的數字往後
    /// </summary>
    /// <param name="arr"></param>
    public int[] DuplicateZeros(int[] arr)
    {
        /* 網路解法
        var zeros = 0;
        for (var i = 0; i < arr.Length; i++)
            if (arr[i] == 0)
                zeros++;

        var len = arr.Length - 1;

        while (len > 0 && zeros > 0)
        {
            if (len + zeros <= arr.Length - 1)
                arr[len + zeros] = arr[len];

            if (arr[len] == 0)
                zeros--;

            arr[len] = 0;
            len--;
        }
        return arr;
        */
        //自己解法
        int[] result = new int[arr.Length];
        var a = 0;
        for (int i = 0; i + a < arr.Length; i++)
        {
            result[i + a] = arr[i];
            if (arr[i] == 0)
            {
                result[i + 1] = 0;
                a++;
            }
        }
        return result;
    }

    /// <summary>
    /// Merge Sorted Array ，合併兩個 input 的整數陣列，並做排序
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="m"></param>
    /// <param name="nums2"></param>
    /// <param name="n"></param>
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        /*
        //網路解法
        for (int i = 0; i < n; i++)
        {
            nums1[m + i] = nums2[i];
        }
        Array.Sort(nums1);
        */
        //自已的解法
        var result = new List<int>();
        var nums1count = 0;
        var nums2count = 0;
        foreach (var item1 in nums1)
        {
            if (nums1count == m) break;
            result.Add(item1);
            nums1count++;
        }
        foreach (var item2 in nums2)
        {
            if (nums2count == n) break;
            result.Add(item2);
            nums1count++;
        }
        nums1 = result.OrderBy(x => x).ToArray();
        var console5 = string.Empty;
        foreach (int item in nums1)
        {
            console5 += item.ToString() + ",";
        }
        Console.WriteLine($"output5 : {console5}");

    }

    /// <summary>
    /// Remove Element，從 input 的整數陣列中，刪除 val 參數的數字，並由小到大排序
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public int RemoveElement(int[] nums, int val)
    {
        // 網路解法，其實應該是題目出得不好
        int res = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[res] = nums[i];
                res++;
            }
        }

        return res;

        /* 自己寫的，但比較像是實務會使用
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {
                nums[i] = 0;
            }
        }
        //Array.Sort(nums);
        nums = nums.Where(x => x > 0).ToArray();
        int resultArrayCount = nums.Where(x => x > 0).Count();
        return resultArrayCount;
        */
    }

    /// <summary>
    /// RemoveDuplicates， 從 input 的整數陣列中，刪除重複值，並用 ASC 排列，最後 return 沒重複值的總數
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RemoveDuplicates(int[] nums)
    {
        /* linq
        //nums = nums.Distinct().ToArray();
        //return nums.Count();
         */

        if (nums == null || nums.Length == 0)
            return 0;
        else if (nums.Length == 1)
            return 1;

        int index1 = 0,
            index2 = 1;

        while (index2 <= nums.Length - 1)
            if (nums[index1] == nums[index2])
                index2++;
            else
                nums[++index1] = nums[index2++];

        return ++index1;
    }

    /// <summary>
    /// CheckIfExist， 從 input 的整數陣列中，如滿足下面三個條件 (簡單來說 輸入的陣列某個值*2 是否有存在此陣列中)
    /// i != j && 
    /// 0 <= i, j<arr.length && 
    /// arr[i] == 2 * arr[j]
    /// 就 return true 不然就是 false
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public bool CheckIfExist(int[] arr)
    {
        //Linq 解法
        /*
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr.Where(i => i == 0).Count() > 1) return true;
            if (arr[i] == 0) continue;
            if (arr.Any(x => x == arr[i] *2)) return true;
        }
        return false;
        */

        //非 Linq 解法，第一個迴圈將陣列的第N個值*2，第二個迴圈方式檢查該值是否存在 
        bool exist = false;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[i] * 2 == arr[j] && i != j)
                {
                    return true;
                }
            }
        }
        return exist;
    }


    /// <summary>
    /// Valid Mountain Array 檢查 input 的陣列是否為山型陣列，就是由左至右的值，低>中>高>中>低 這類似的邏輯就回覆 ture
    /// </summary> 
    /// <param name="arr"></param>
    /// <returns></returns>
    public bool ValidMountainArray(int[] arr)
    {
        /* 一次迴圈硬解，邏輯是先判斷最高與最低的數字，由左至右的判斷，但要寫很多判斷式，效能不好
        bool result = false;
        int max = arr.Max();
        int min = arr.Min();
        int flag = 0;
        if (arr.Length < 3 || arr[0] == max || arr.Where(x => x == max).Count()>1 || arr.Where(x => x == min).Count() > 1) return result;
        for (int i = 0; i < arr.Length; i++)
        {
            if (i+1 == arr.Length) return result;
            if (arr[i] == arr[i + 1]) return result;
            if (arr[i] != max && arr[i] > arr[i + 1]) return result;
            {
                if (arr[i] == max)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        flag++;
                        if (arr[j] > arr[i]) return result;
                        if (j + 1 == arr.Length)
                        {
                            if (arr[j] > arr[j-1]) return result;
                        }
                        continue;
                    }
                    return flag > 0 ? true : false;
                }
            }
        }
        return result;
        */
        //從陣列的 左右兩邊跑迴圈 看是否均符合遞增
        if (arr == null || arr.Length < 3)
            return false;

        int left = -1,
            right = arr.Length;

        for (int i = 1; i < arr.Length; i++)
            if (arr[i - 1] < arr[i])
                left = i;
            else
                break;

        for (int i = arr.Length - 2; i > -1; i--)
            if (arr[i] > arr[i + 1])
                right = i;
            else
                break;

        return left == right;
    }

    /// <summary>
    /// Replace Elements with Greatest Element on Right Side 檢查 input 的陣列，由左至右的比較，如果右邊比較大就替換，最後一個值設定-1
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] ReplaceElements(int[] arr)
    {
        for (int i = 0; i < arr.Length-1; i++)
        {
            int maxNumber = 0;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] > maxNumber)
                {
                    maxNumber = arr[j];
                }
            }
            arr[i] = maxNumber;
        }
        arr[arr.Length - 1] = -1;
        
        return arr;
    }

    /// <summary>
    /// Move Zeroes 將 input 的整數陣列中，將 0 移動到最右邊 
    /// </summary>
    /// <param name="nums"></param>
    public void MoveZeroes(int[] nums)
    {
        int index1 = 0;
        int index2 = 1;
        int a = 0; 
        int zeroCount = nums.Where(x => x == 0).Count();
        while (nums[nums.Length-1] != 0) 
        {
            if (nums[index1] < nums[index2])
            {
                a = nums[index1];
                nums[index1] = nums[index2];
                nums[index2] = a;
            }
            index1++;
            index2++;
        }

    }
}

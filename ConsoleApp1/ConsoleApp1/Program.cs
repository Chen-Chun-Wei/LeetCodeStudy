// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System;
using static ConsoleApp1.Solution;

Console.WriteLine("Hello, World!");

#region 初步LeetCode
var aa = new Solution();

//var bb = aa.CountOdds1(3, 7); Console.WriteLine(bb);
//var cc = aa.CountOdds2(3, 7); Console.WriteLine(cc);

//var dd = aa.Average1(new int[] { 4000, 3000, 1000, 2000 }); Console.WriteLine(dd);

//uint x = 0b_1111_1111_1111_1111_1111_1111_1111_1101;
//var ee = aa.HammingWeight(x); Console.WriteLine(ee);

//var ff = aa.SubtractProductAndSum(4432); Console.WriteLine(ff);

//int[][] input = { new int[]{1,2,3}, new int[]{3,2,1}};
//var gg = aa.MaximumWealth(input);

//var hh = aa.FizzBuzz(15);

//var ii = aa.NumberOfSteps(123);

//var jModel = new ListNode(6, new ListNode(6));
//var jj = aa.MiddleNode(jModel);

//var kk = aa.CanConstruct("aa", "aab");
#endregion

#region Array觀念教學
var arraySolution = new ArraySolution();
//int[] intput1 = new int[] { 1, 1, 0, 1, 1, 1 };
int[] intput1 = new int[] { 1, 0, 1, 1, 0, 1 };
var output1 = arraySolution.FindMaxConsecutiveOnes(intput1);
Console.WriteLine($"output1 : {output1}");

int[] intput2 = new int[] { 12, 345, 2, 6, 7896 };
//int[] intput2 = new int[] { 555,901,482,1771 };
var output2 = arraySolution.FindNumbers(intput2);
Console.WriteLine($"output2 : {output2}");

//int[] intput3 = new int[] { -4, -1, 0, 3, 10 };
int[] intput3 = new int[] { -7,-3,2,3,11 };
var output3 = arraySolution.SortedSquares(intput3);
var console3 = string.Empty;
foreach (int i in output3)
{
    console3 += i.ToString()+",";
}
Console.WriteLine($"output3 : {console3}");


int[] intput4 = new int[] { 1,0,2,3,0,4,5,0};
//int[] intput4 = new int[] { 1,2,3 };
var output4 = arraySolution.DuplicateZeros(intput4);
var console4 = string.Empty;
foreach (int i in output4)
{
    console4 += i.ToString() + ",";
}
Console.WriteLine($"output4 : {console4}");


int[] intput5A = new int[] { 1, 2, 3, 0, 0, 0 };
int m = 3;
int[] intput5B = new int[] { 2, 5, 6 };
int n = 3;
arraySolution.Merge(intput5A,m, intput5B,n);

int[] intput6 = new int[] { 3, 2, 2, 3 };
int val = 3;
var output6 = arraySolution.RemoveElement(intput6, val);
Console.WriteLine($"output6 : {output6}");


int[] intput7A = new int[] { 1, 1, 2,};
int[] intput7B = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
var output7 = arraySolution.RemoveDuplicates(intput7B);
Console.WriteLine($"output7 : {output7}");


int[] intput8A = new int[] { 10, 2, 5, 3 };
int[] intput8B = new int[] { 3, 1, 7, 11 };
int[] intput8C = new int[] { -20, 8, -6, -14, 0, -19, 14, 4 };
int[] intput8D = new int[] { 0, 0 };

var output8 = arraySolution.CheckIfExist(intput8B);
Console.WriteLine($"output8 : {output8}");

int[] intput9A = new int[] { 2, 1 };
int[] intput9B = new int[] { 3,5,5 };
int[] intput9C = new int[] { 0, 3, 2, 1 };
int[] intput9D = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int[] intput9E = new int[] { 0, 1, 2, 1, 2 };
int[] intput9F = new int[] { 3, 7, 6, 4, 3, 0, 1, 0 };

var output9 = arraySolution.ValidMountainArray(intput9F);
Console.WriteLine($"output9 : {output9}");


int[] intput10A = new int[] { 17, 18, 5, 4, 6, 1 };
int[] intput10B = new int[] { 400 };
var output10 = arraySolution.ReplaceElements(intput10B);
Console.WriteLine($"output10 : {output10}");

int[] intput11A = new int[] { 0, 1, 0, 3, 12 };
int[] intput11B = new int[] { 0 };
arraySolution.MoveZeroes(intput11A);

#endregion

#region 開始刷提
var testcase = new Solution();
var input1 = new int[] {2,7,11,15};
int target1 = 9;
//var input1 = new int[] { 3, 2, 4 };
//int target1 = 6; 
var outPutNo1 = testcase.TwoSum(input1, target1);
#endregion
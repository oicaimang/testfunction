
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeletedAndEarn : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] data = new int[] { 2, 2, 3, 3, 3, 4, 5, 5, 5, 7, 7, 7, };
    Dictionary<string, int> Memo = new Dictionary<string, int>();
    Dictionary<string, int> MemoSupport = new Dictionary<string, int>();
    void Start()
    {
        Debug.Log(DeleteAndEarn(data, 0));
    }
    public int DeleteAndEarn(int[] nums, int valueCacheKey)
    {
        if (nums.Length == 0) return 0;
        if (Memo.ContainsKey(ChangeArrayToSortString(nums) + "_" + valueCacheKey.ToString()))
        {
            return Memo[ChangeArrayToSortString(nums) + "_" + valueCacheKey.ToString()];
        }
        else
        {
            int[] cacheNums;
            int maxValue = 0;
            MemoSupport.Clear();
            for (int i = 0; i < nums.Length; i++)
            {
                List<int> listCacheNums = nums.ToList();
                int valueIndex = nums[i];
                listCacheNums.RemoveAt(i);
                cacheNums = listCacheNums.ToArray();
                cacheNums = cacheNums.Where(val => (val != valueIndex + 1 && val != valueIndex - 1)).ToArray();
                if (!MemoSupport.ContainsKey(ChangeArrayToSortString(cacheNums)))
                {
                    int valueInX = DeleteAndEarn(cacheNums, valueIndex) + valueIndex;
                    MemoSupport[ChangeArrayToSortString(cacheNums)] = valueInX;
                    if (valueInX > maxValue)
                    {
                        maxValue = valueInX;
                    }
                    Memo[ChangeArrayToSortString(nums) + "_" + valueIndex.ToString()] = maxValue;
                }
            }
            return maxValue;
        }
    }
    private string ChangeArrayToSortString(int[] nums)
    {
        string result = "";
        List<int> listSort = nums.ToList();
        listSort.Sort();
        foreach (var x in listSort)
        {
            result += $"{x}";
        }
        return result;
    }
}

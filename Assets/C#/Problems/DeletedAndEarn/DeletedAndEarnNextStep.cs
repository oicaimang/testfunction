
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeletedAndEarNextStep : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] data = new int[] { 2, 2, 3, 3, 3, 4 };
    Dictionary<string, int> Memo = new Dictionary<string, int>();
    void Start()
    {
        Debug.Log(DeleteAndEarn(data));
    }
    public int DeleteAndEarn(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (Memo.ContainsKey(ChangeArrayToSortString(nums)))
        {
            return Memo[ChangeArrayToSortString(nums)];
        }
        else
        {
            int[] cacheNums;
            int maxValue = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                List<int> listCacheNums = nums.ToList();
                int valueIndex = nums[i];
                int valueIndexLoop = listCacheNums.Where(_ => _ == valueIndex).Count();
                listCacheNums.RemoveAll(_ => (_ == valueIndex || _ == valueIndex + 1 || _ == valueIndex - 1));
                cacheNums = listCacheNums.ToArray();
                int valueInNumsI = DeleteAndEarn(cacheNums) + valueIndex * valueIndexLoop;
                if (valueInNumsI > maxValue)
                {
                    maxValue = valueInNumsI;
                }
                Memo[ChangeArrayToSortString(nums)] = maxValue;
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

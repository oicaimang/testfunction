
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeletedAndEarNextStepStep : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] data = new int[] { 2, 2, 3, 3, 3, 4 };
    void Start()
    {
        Debug.Log(Rob(ProcessData(data)));
    }
    public int Rob(int[] nums)
    {
        int prev1 = 0;
        int prev2 = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int val = prev1;
            prev1 = Mathf.Max(prev1, prev2 + nums[i]);
            prev2 = val;
        }
        return prev1;
    }

    private int[] ProcessData(int[] data)
    {
        List<int> listData = data.ToList();
        listData.Sort();
        int cacheData = 0;
        List<int> listCacheIndexFillZero = new List<int>();
        for (int i = 0; i < listData.Count; i++)
        {
            if (cacheData != 0)
            {
                if (listData[i] != (cacheData + 1) && listData[i] != cacheData)
                {
                    Debug.Log("cacheData: " + cacheData + " " + "listData[i]: " + listData[i] + " " + i);
                    listCacheIndexFillZero.Add(i);
                }
                else cacheData = listData[i];
            }
            cacheData = listData[i];
        }
        listCacheIndexFillZero.Reverse();
        foreach (var x in listCacheIndexFillZero)
        {
            listData.Insert(x, 0);
        }
        int currentSum = 0;
        int currentCache = 0;
        List<int> listFinal = new List<int>();
        for (int i = 0; i < listData.Count; i++)
        {
            if (currentCache == 0) currentCache = listData[i];
            if (listData[i] == 0)
            {
                listFinal.Add(currentSum);
                listFinal.Add(0);
                currentSum = 0;
            }
            else
            {
                if (currentCache != listData[i])
                {
                    listFinal.Add(currentSum);
                    currentSum = 0;
                    currentCache = listData[i];

                }
                currentSum += listData[i];
                if (i == listData.Count - 1)
                {
                    listFinal.Add(currentSum);
                }
            }
        }
        foreach (var x in listFinal)
        {
            Debug.Log(x);
        }
        return listFinal.ToArray();
    }
}

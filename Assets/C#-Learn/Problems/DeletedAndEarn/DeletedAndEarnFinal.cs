
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeletedAndEarnFinal : MonoBehaviour
{
    // Start is called before the first frame update
    private int[] data = new int[] { 3, 4, 2 };
    int[] Array = new int[10001];
    int MaxInData = 0;
    void Start()
    {
        Debug.Log(DeletedAndEarn(data));
    }
    public int DeletedAndEarn(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            Array[nums[i]]++;
            if (MaxInData < data[i]) MaxInData = data[i];
        }
        // after that we can create a Array like that  [0,0,2,3,1]
        // with quantity of index => Array[0]=0; Array[1]=0; Array[2]=2; Array[3]=3; Array[4]=1
        // =>it is house rob matter
        int sum = 0;
        int prev2 = 0;
        for (int i = 0; i <= MaxInData; i++)
        {
            if (!nums.Contains(i)) continue;
            int val = sum;
            sum = Mathf.Max(sum, prev2 + i * Array[i]);
            prev2 = val;
        }
        return sum;
        // continue loop to calculate sum =>
        // because for from 0 to MaxInData so it auto sort from small to larger than
        // because in index do not have in Array Data => quantity= zero so do not sum other value to result
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseRobber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


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

        // Update is called once per frame
        void Update()
        {

        }
    }
}

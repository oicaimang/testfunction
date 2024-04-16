using UnityEngine;

public class MinCostClimbingStair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] cost = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
        int[] CostToTop = new int[cost.Length + 1];
        CostToTop[cost.Length] = 0;
        // start loop from "CostToTop.Length - 2" because max index of CostToTop.Length is CostToTop.Length-1==cost.Length
        for (int i = CostToTop.Length - 2; i >= 0; i--)
        {
            // if not exit CostToTop[i+1] && CostToTop[i+2] => break=>> because i run from CostToTop.length-2 and CostToTop - max index is CostToTop.Length-1 so 
            //i+2<=CostToTop.Length-1
            if (i <= CostToTop.Length - 3)
            {
                CostToTop[i] = cost[i] + Mathf.Min(CostToTop[i + 1], CostToTop[i + 2]);
            }
            else
            {
                Debug.Log("only two time in first i:= " + i);
                CostToTop[i] = cost[i] + CostToTop[i + 1];
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

using UnityEngine;

public class MinCostClimbingStair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] cost = new int[] { 10, 15, 20 };
        int[] CostToTop = new int[cost.Length + 1];
        CostToTop[cost.Length] = 0;
        for (int i = cost.Length; i >= 0; --i)
        {
        }
    }
    private int Min(int a, int b)
    {
        return a < b ? a : b;
    }
    // Update is called once per frame
    void Update()
    {

    }
}

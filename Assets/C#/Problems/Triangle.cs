using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    // Start is called before the first frame update
    int[][] data = new int[][] {new int[]{2},
                                new int[]{3,4},
                                new int[]{6,5,7},
                                new int[]{4,1,8,3}};
    int[][] result;
    int resultMin;
    void Start()
    {
        int valRow = data.Length;
        int valColumn = data[data.Length - 1].Length;
        int[,] result = new int[valRow, valColumn];
        for (int i = 0; i < valRow; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (i == 0)
                {
                    result[i, j] = data[i][j];
                    // Debug.Log(result[i, j]);
                    continue;
                }
                if (j == 0)
                {
                    result[i, j] = result[i - 1, j] + data[i][j];
                    // Debug.Log(result[i, j]);
                    continue;
                }
                if (j == data[i - 1].Length)
                {
                    result[i, j] = result[i - 1, j - 1] + data[i][j];
                    // Debug.Log(result[i, j]);
                }
                else
                {
                    try
                    {
                        result[i, j] = Mathf.Min(result[i - 1, j - 1], result[i - 1, j]) + data[i][j];
                        // Debug.Log(result[i, j]);
                    }
                    catch
                    {
                        Debug.Log("i:=" + i + " " + "j:=" + j);
                    }
                }
            }
        }
        resultMin = result[data.Length - 1, 0];
        for (int i = 1; i < data[data.Length - 1].Length; i++)
        {
            // Debug.Log("the last array result:= " + result[data.Length - 1, i]);
            if (result[data.Length - 1, i] < resultMin) resultMin = result[data.Length - 1, i];
        }
        Debug.Log(resultMin);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimumFallingPathSum : MonoBehaviour
{
    // Start is called before the first frame update
    int[][] matrix = new int[][] {new int[]{2,1,3},
                                new int[]{6,5,4},
                                new int[]{7,8,9}};
    int resultMin;
    void Start()
    {
        int valRow = matrix.Length;
        int valColumn = matrix[matrix.Length - 1].Length;
        int[,] result = new int[valRow, valColumn];
        for (int i = 0; i < valRow; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (i == 0)
                {
                    result[i, j] = matrix[i][j];
                }
                else
                {
                    if (j == 0)
                    {
                        result[i, j] = Mathf.Min(result[i - 1, j], result[i - 1, j + 1]) + matrix[i][j];
                    }
                    else if (j == matrix[i].Length - 1)
                    {
                        result[i, j] = Mathf.Min(result[i - 1, j - 1], result[i - 1, j]) + matrix[i][j];
                    }
                    else
                    {
                        result[i, j] = Mathf.Min(Mathf.Min(result[i - 1, j - 1], result[i - 1, j]), result[i - 1, j + 1]) + matrix[i][j];
                    }
                }
            }
        }
        resultMin = result[matrix.Length - 1, 0];
        for (int i = 1; i < matrix[matrix.Length - 1].Length; i++)
        {
            // Debug.Log("the last array result:= " + result[matrix.Length - 1, i]);
            if (result[matrix.Length - 1, i] < resultMin) resultMin = result[matrix.Length - 1, i];
        }
        Debug.Log(resultMin);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

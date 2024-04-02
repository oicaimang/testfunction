using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MaximalSquare : MonoBehaviour
{
    // Start is called before the first frame update
    char[][] matrix = new char[][] {new char[]{'1','0','1','0','0'},
                                    new char[]{'1','0','1','1','1'},
                                    new char[]{'1','1','1','1','1'},
                                    new char[]{'1','0','0','1','0'}};
    int resultMax;
    void Start()
    {
        int valRow = matrix.Length;
        int valColumn = matrix[matrix.Length - 1].Length;
        int[,] result = new int[valRow, valColumn];
        if (valRow == 1 && valColumn == 1 && int.Parse(matrix[0][0].ToString()) == 0)
        {
            Debug.Log(0);
            return;
        }
        for (int i = 0; i < valRow; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (i == 0 || j == 0)
                {
                    result[i, j] = int.Parse(matrix[i][j].ToString());
                }
                else
                {
                    if (int.Parse(matrix[i][j].ToString()) == 0)
                    {
                        result[i, j] = 0;
                        continue;
                    }
                    else
                    {
                        result[i, j] = Mathf.Min(Mathf.Min(result[i - 1, j - 1], result[i - 1, j]), result[i, j - 1]) + 1;
                    }
                }
            }
        }
        resultMax = result[0, 0];
        for (int i = 0; i < valRow; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                // Debug.Log("the last array result:= " + result[matrix.Length - 1, i]);
                if (result[i, j] > resultMax) resultMax = result[i, j];
            }
        }
        Debug.Log(resultMax * resultMax);
    }
}

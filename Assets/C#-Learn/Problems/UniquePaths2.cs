using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniquePaths2 : MonoBehaviour
{
    // Start is called before the first frame update
    int[][] data = new int[][] {    new int[] { 0,1},
                                    new int[] { 0,0}};
    void Start()
    {
        int valRow = data.Length;
        int valColumn = data[0].Length;
        int[,] result = new int[valRow, valColumn];
        if (data[0][0] == 1) return;
        result[0, 0] = 1;
        for (int i = 0; i < valRow; i++)
        {
            for (int j = 0; j < valColumn; j++)
            {
                if (data[i][j] == 1)
                {
                    result[i, j] = 0;
                }
                else
                {
                    if (i == 0 && j == 0) continue;
                    if (i == 0 && j != 0)
                    {
                        result[i, j] = result[i, j - 1];
                    }
                    else if (j == 0 && i != 0)
                    {
                        result[i, j] = result[i - 1, j];

                    }
                    else
                    {
                        result[i, j] = result[i, j - 1] + result[i - 1, j];
                    }
                }
            }
        }
        Debug.Log(result[valRow - 1, valColumn - 1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

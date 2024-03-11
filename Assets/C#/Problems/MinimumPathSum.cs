using UnityEngine;

public class MinimumPathSum : MonoBehaviour
{
    // Start is called before the first frame update
    int[][] data = new int[][] { new int[] { 1, 2, 3 },
                                    new int[] { 4, 5, 6 } };

    void Start()
    {
        int valRow = data.Length;
        int valColumn = data[0].Length;
        Debug.Log("valRow: " + valRow + " " + "valColumn: " + valColumn);
        int[,] result = new int[valRow, valColumn];
        result[0, 0] = data[0][0];
        for (int i = 0; i < valRow; i++)
        {
            for (int j = 0; j < valColumn; j++)
            {
                if (i == 0 && j == 0) continue;
                if (i == 0 && j != 0) result[i, j] = data[i][j] + result[i, j - 1];
                else if (j == 0 && i != 0) result[i, j] = data[i][j] + result[i - 1, j];
                else result[i, j] = data[i][j] + Mathf.Min(result[i - 1, j], result[i, j - 1]);
            }
        }
        Debug.Log(result[valRow - 1, valColumn - 1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AlphabetBoardPath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[,] board = new string[,]
        {
            {"a","b","c","d","e"},
            {"f","g","h","i","j"},
            {"k","l","m","n","o"},
            {"p","q","r","s","t"},
            {"u","v","w","x","y"},
            {"z","","","",""}
        };
        string target = "zdz";
        char[] targetListChar = target.ToArray();
        int startPointX = 0;
        int startPointY = 0;
        string resultAll = "";
        foreach (var x in targetListChar)
        {
            // check and cache value string for string
            // check value of char x in board
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != "")
                    {
                        if (x == board[i, j].ToCharArray().First())
                        {
                            resultAll += ConvertVector2ToString(i - startPointX, j - startPointY);
                            startPointX = i;
                            startPointY = j;
                        }
                    }

                }
            }
        }
        Debug.Log(resultAll);
    }
    private string ConvertVector2ToString(int valueX, int valueY)
    {
        int cacheValueX = valueX;
        int cacheValueY = valueY;
        string result = "";
        if (cacheValueY < 0)
        {
            for (int i = 0; i < (-cacheValueY); i++)
            {
                result += "L";
            }
        }
        if (cacheValueX < 0)
        {
            for (int i = 0; i < (-cacheValueX); i++)
            {
                result += "U";
            }
        }
        if (cacheValueX > 0)
        {
            for (int i = 0; i < (cacheValueX); i++)
            {
                result += "D";
            }
        }
        if (cacheValueY > 0)
        {
            for (int i = 0; i < (cacheValueY); i++)
            {
                result += "R";
            }
        }
        return result + "!";
    }
}

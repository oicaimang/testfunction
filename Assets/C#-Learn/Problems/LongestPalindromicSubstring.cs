using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LongestPalindromicSubstring : MonoBehaviour
{
    string s = "xaabacxcabaaxcabaax";

    void Start()
    {
        char[] cacheS;
        int[] indexLoop = new int[100000];
        List<List<char>> listResult = new List<List<char>>();
        ProcessListBeforeCal(out cacheS, s, indexLoop, listResult);
        for (int i = 0; i < cacheS.Length; i++)
        {
            var currentPointInS = 0;
            for (int j = 0; j < i; j++)
            {
                currentPointInS += indexLoop[j];
            }
            ExtendAndCheckPalindrome(listResult, ReturnTrueArray(indexLoop[i], cacheS[i]), currentPointInS, ReturnTrueArrayCheck(i, s, indexLoop, cacheS), 0);
        }
        foreach (var x in listResult)
        {
            var myString = new string(x.ToArray());
            Debug.Log(myString);
        }
    }
    private void ExtendAndCheckPalindrome(List<List<char>> listResult, char[] currentCheck, int startIndex, char[] cacheS, int currentExtend = 0)
    {
        currentExtend++;
        if (startIndex - currentExtend < 0 || startIndex + currentExtend > cacheS.Length - 1)
        {
            // Debug.Log("end check: " + currentCheck.Length);
            if (!listResult.Contains(currentCheck.ToList()))
            {
                listResult.Add(currentCheck.ToList());
            }
        }
        else
        {
            if (cacheS[currentExtend + startIndex] == cacheS[startIndex - currentExtend])
            {
                var newCurrentCheck = currentCheck.ToList();
                newCurrentCheck.Add(cacheS[currentExtend + startIndex]);
                newCurrentCheck.Insert(0, cacheS[startIndex - currentExtend]);
                ExtendAndCheckPalindrome(listResult, newCurrentCheck.ToArray(), startIndex, cacheS, currentExtend);
            }
            else
            {
                // Debug.Log("end check: " + currentCheck.ToArray().Length);
                if (!listResult.Contains(currentCheck.ToList()))
                {
                    listResult.Add(currentCheck.ToList());
                }
            }
        }
    }
    private void ProcessListBeforeCal(out char[] cacheS, string s, int[] indexLoop, List<List<char>> listResult)
    {
        char[] organicArray = s.ToArray();
        List<char> lastArray = new List<char>();
        int cacheIndexLoop = 1;
        for (int i = 1; i < organicArray.Length; i++)
        {
            if (organicArray[i - 1] == organicArray[i])
            {
                cacheIndexLoop++;
                if (i == organicArray.Length - 1)
                {
                    lastArray.Add(organicArray[i]);
                    indexLoop[lastArray.Count - 1] = cacheIndexLoop;
                }
            }
            else
            {
                lastArray.Add(organicArray[i - cacheIndexLoop]);
                indexLoop[lastArray.Count - 1] = cacheIndexLoop;
                if (cacheIndexLoop > 1)
                {
                    var oneResult = ReturnTrueArray(cacheIndexLoop, organicArray[i - cacheIndexLoop]);
                    foreach (var x in oneResult)
                    {
                        Debug.Log(x);
                    }
                    listResult.Add(oneResult.ToList());
                }
                cacheIndexLoop = 1;
                if (i == organicArray.Length - 1)
                {
                    lastArray.Add(organicArray[i]);
                    indexLoop[lastArray.Count - 1] = cacheIndexLoop;
                }
            }
        }
        cacheS = lastArray.ToArray();
    }
    private char[] ReturnTrueArray(int cacheIndexLoop, char charCurrentLoop)
    {
        List<char> lastChar = new List<char>();
        for (int i = 0; i < cacheIndexLoop; i++)
        {
            lastChar.Add(charCurrentLoop);
        }
        return lastChar.ToArray();
    }
    private char[] ReturnTrueArrayCheck(int cacheIndexLoop, string s, int[] indexLoop, char[] cacheS)
    {
        // calculate pos index of current loop point from s
        var currentPointInS = 0;
        for (int i = 0; i < cacheIndexLoop; i++)
        {
            currentPointInS += indexLoop[i];
        }
        List<char> lastChar = s.ToArray().ToList();
        lastChar.RemoveRange(currentPointInS, indexLoop[cacheIndexLoop]);
        lastChar.Insert(currentPointInS, cacheS[cacheIndexLoop]);
        return lastChar.ToArray();
    }
}

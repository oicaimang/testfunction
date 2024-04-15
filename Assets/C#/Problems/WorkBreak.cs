using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBreak : MonoBehaviour
{
    // Start is called before the first frame update
    string s = "leetcode";
    IList<string> wordDict;
    // 1 <= s.length <= 300
    // 1 <= wordDict.length <= 1000
    // 1 <= wordDict[i].length <= 20
    // s and wordDict[i] consist of only lowercase English letters.
    // All the strings of wordDict are unique.
    void Start()
    {
        wordDict.Add("leet");
        wordDict.Add("code");
        // all the strings of wordDict are unique => if have loop in strings => only extend size
    }
    private bool CheckABelongB(string A, string B)
    {
        return false;
    }
}

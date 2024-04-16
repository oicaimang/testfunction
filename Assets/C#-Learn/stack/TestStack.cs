using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Stack<string> hanghoa = new Stack<string>();
        hanghoa.Push("mat hang 1");
        hanghoa.Push("mat hang 2");
        hanghoa.Push("mat hang 3");
        var mathang = hanghoa.Pop();
        Debug.Log("Boc do" + mathang);
        mathang = hanghoa.Pop();
        Debug.Log("Boc do" + mathang);
        mathang = hanghoa.Pop();
        Debug.Log("Boc do" + mathang);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

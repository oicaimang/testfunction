using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorTest : MonoBehaviour
{
    string a = null;
    void Start()
    {
        string b = a ?? "asdasd";
        Debug.Log(b);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

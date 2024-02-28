using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDictionary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, int> sodem = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
        };
        sodem["three"] = 3;
        var keys = sodem.Keys;
        foreach (var x in keys)
        {
            var value = sodem[x];
            Debug.Log("key:" + x + " = " + "value: " + value);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TestQueue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Queue<string> cachoso = new Queue<string>();
        cachoso.Enqueue("Ho so 1");
        cachoso.Enqueue("Ho so 2");
        cachoso.Enqueue("Ho so 3");
        foreach (var x in cachoso)
        {
            Debug.Log(x);
            Debug.Log("--------------");
        }
        cachoso.Dequeue();
        foreach (var x in cachoso)
        {
            Debug.Log(x);
        }
    }

}

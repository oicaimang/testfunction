using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLinkedList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LinkedList<string> cacbaihoc = new LinkedList<string>();
        var bh1 = cacbaihoc.AddFirst("bai hoc 1");
        var bh3 = cacbaihoc.AddLast("bai hoc 3");
        LinkedListNode<string> bh2 = cacbaihoc.AddAfter(bh1, "bai hoc 2");
        cacbaihoc.AddLast("bai hoc 4");
        cacbaihoc.AddLast("bai hoc 5");
        // var node = bh2;
        // Debug.Log(node.Value);
        // node = node.Previous;
        // Debug.Log(node.Value);
        // node = node.Previous;
        // Debug.Log(node.Value);
        var node = cacbaihoc.Last;
        Debug.Log(node.Value);
        while (node != null)
        {
            Debug.Log(node.Value);
            node = node.Previous;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}

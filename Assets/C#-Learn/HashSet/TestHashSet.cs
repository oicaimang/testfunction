using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHashSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7 };
        HashSet<int> set2 = new HashSet<int> { 1, 5, 3, 7, 5, 9, 10 };
        set1.Add(11);
        set1.Remove(7);
        // hop
        // set1.UnionWith(set2);
        // giao
        set1.IntersectWith(set2);
        foreach (var item in set1)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

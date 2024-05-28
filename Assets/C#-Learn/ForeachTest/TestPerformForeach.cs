using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPerformForeach : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isForeach = true;
    void Start()
    {
        var listA = new List<int>() { 1, 2, 3, 231, 3, 123, 23, 4, 213 };
        if (isForeach)
        {
            foreach (var x in listA)
            {
                Debug.Log(x);
            }
        }

        else
        {
            for (int i = 0; i < listA.Count; i++)
            {
                Debug.Log(listA[i]);
            }
        }
    }
}

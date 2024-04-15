using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddElementInForStruc : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<int> listInt = new List<int>();
    void Start()
    {
        listInt.Add(1);
        listInt.Add(2);
        listInt.Add(3);
        for (int i = 0; i < listInt.Count; i++)
        {
            if (i == 2) listInt.Add(2);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

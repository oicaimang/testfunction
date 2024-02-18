using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorIndexer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var indexerExam = new IndexerExam();
        indexerExam[0] = "Nguyen";
        indexerExam[1] = "Quyet";
        Debug.Log("ho va ten vi du la: " + indexerExam[0] + " " + indexerExam[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
public class IndexerExam
{
    string ho = "";
    string name = "";
    public string this[int index]
    {
        get
        {
            if (index == 0) return ho;
            else if (index == 1) return name;
            else throw new System.Exception("khong ton tai");
        }
        set
        {
            if (index == 0) ho = value;
            else if (index == 1) name = value;
            else throw new System.Exception("khong ton tai");
        }
    }
}

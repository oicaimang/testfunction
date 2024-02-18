
using System;
using UnityEngine;

public class DirectoryTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets";
        ListFileDirectory(path);
        // var files = Directory.GetFiles(path);
        // var directories = Directory.GetDirectories(path);
        // foreach (var x in directories)
        // {
        //     Debug.Log(x);
        // }
        // Debug.Log("________________");
        // foreach (var x in files)
        // {
        //     Debug.Log(x);
        // }
        // Directory.Delete(path);
        // if (Directory.Exists(path))
        // {
        //     Debug.Log(" thu muc ABC co ton tai");
        // }
        // else
        // {
        //     Debug.Log("thu muc ABC khong ton tai");
        // }

    }
    static void ListFileDirectory(string path)
    {
        String[] directories = System.IO.Directory.GetDirectories(path);
        String[] files = System.IO.Directory.GetFiles(path);
        foreach (var file in files)
        {
            Debug.Log(file);
        }
        foreach (var directory in directories)
        {
            Debug.Log(directory);
            ListFileDirectory(directory); // Đệ quy
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

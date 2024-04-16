using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InforDriveTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var drives = DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
            Debug.Log("drive name: " + drive.Name);
            Debug.Log("drive type: " + drive.DriveType);
            Debug.Log("drive label: " + drive.VolumeLabel);
            Debug.Log("drive format: " + drive.DriveFormat);
            Debug.Log("drive size: " + drive.TotalSize);
            Debug.Log("drive free: " + drive.TotalFreeSpace);
        }
    }
}

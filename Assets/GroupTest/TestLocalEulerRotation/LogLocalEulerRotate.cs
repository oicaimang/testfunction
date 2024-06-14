using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogLocalEulerRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 vector3LocalEulerValue = new Vector3();

    // Update is called once per frame
    void Update()
    {
        vector3LocalEulerValue = transform.rotation.eulerAngles;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorOperator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var vectora = new Vector(1, 2);
        var vectorb = new Vector(2, 3);
        var vectorTong = vectora + vectorb;
        Debug.Log("vector tong cua 2 vector la ");
        vectorTong.ShowXY();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
public class Vector
{
    double x;
    double y;
    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public void ShowXY()
    {
        Debug.Log("x= " + x);
        Debug.Log("y= " + y);
    }
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y);
    }
}

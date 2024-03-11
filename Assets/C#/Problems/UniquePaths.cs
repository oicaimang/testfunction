using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniquePaths : MonoBehaviour
{
    int m = 36;
    int n = 10;
    void Start()
    {
        int TotalWay = 1;
        // lua chon cho de xep m-1 buoc di ngang vao tong m+n-2 buoc
        // vi cac buoc m-1 la nhu nhau => quy ve bai toan tinh so cach de xep m-1 phan tu vao m+n-2 cho trong
        // chon vi tri xep phan tu dau tien => co m+n-2 cach chon 
        // TotalWay += (m + n - 2);
        // chon vi tri xep phan tu tiep theo => co m+n-3 cach chon
        // TotalWay += (m + n - 3);
        ///...
        /// den khi toan bo cac phan tu trong m-1 phan tu dc xep
        for (int i = 0; i < m - 1; i++)
        {
            TotalWay *= (m + n - 2 - i);
        }
        // boi vi cac buoc di ngang la nhu nhau nen so lua chon tren se phai chia cho (m-1)! vi tat ca cac phan tu trong m-1 deu co the the cho tuy y - cac lan lap nhau
        // con lai la xep cac phan tu n-1 vao cac o con lai vi cac o la nhu nhau => ko xep tuy y => ko con cach nao
        if (m == 1 || n == 1) TotalWay = 1;
        double valueMMinusOne = Factorial(m - 1);
        Debug.Log(valueMMinusOne);
    }
    public int Factorial(int f)
    {
        if (f == 0)
            return 1;
        else
            return f * Factorial(f - 1);
    }
    // best way

    // public int UniquePaths(int m, int n) {
    //     if(m ==1 || n==1) return 1;
    //     int min=m>n?n:m;
    //     double TotalWay=1;
    //     // select pos to fill m-1 step
    //     for(int i=0;i<min-1;i++)
    //     {
    //         TotalWay*=m+n-2-i;
    //         TotalWay /=(i+1);
    //     }
    //     return (int)TotalWay;
    // }
}

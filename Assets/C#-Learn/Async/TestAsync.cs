using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class TestAsync : MonoBehaviour
{
    // Start is called before the first frame update
    public async void Start()
    {
        // DoSomeThing(5, "T1", "red");
        // Task(Action)

        // Task(Action<object>,object)

        // Task t2 = Task2();
        // Task t3 = Task3();
        // await t2;
        // await t3;
        // Task.WaitAll(t2, t3);

        Task<string> T4 = new Task<string>(() =>
        {
            Debug.Log("T4 da hoan thanh");
            return "Return from T4";
        });
        Task<string> T5 = new Task<string>((object ob) =>
        {
            var t = (string)ob;
            Debug.Log("T5 da hoan thanh");
            return $"Return from T5 {t}";
        }, "asd");
        T4.Start();
        T5.Start();
        Task.WaitAll(T4, T5);
        var resultT4 = T4.Result;
        Debug.Log(resultT4);
        var resultT5 = T5.Result;
        Debug.Log(resultT5);
        Debug.Log("End");
    }
    async Task Task2()
    {
        Task t2 = new Task(() =>
        {
            DoSomeThing(10, "T2", "white");
        });
        t2.Start();
        await t2;
        Debug.Log("T2 da hoan thanh");
    }
    async Task Task3()
    {
        Task t3 = new Task((object ob) =>
        {
            string tentacvu = (string)ob;
            DoSomeThing(4, tentacvu, "blue");
        }, "T3");
        t3.Start();
        await t3;
        Debug.Log("T3 da hoan thanh");
    }
    public void DoSomeThing(int Seconds, string mgs, string ColorName)
    {
        for (int i = 0; i < Seconds; i++)
        {
            Debug.Log($"<color={ColorName}>{mgs} {i}: </color>");
            Thread.Sleep(1000);
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UnityEngine;

public class TestObservableCollection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObservableCollection<string> obs = new ObservableCollection<string>();
        obs.CollectionChanged += change;
        obs.Add("ZTest1");
        obs.Add("DTest2");
        obs.Add("ATest3");
        obs[2] = "AAAAA";

        obs.RemoveAt(1);
        obs.Clear();

    }
    public static void change(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (String s in e.NewItems)
                    Debug.Log($"Thêm :  {s}");
                break;

            case NotifyCollectionChangedAction.Reset:
                Debug.Log("Clear");
                break;

            case NotifyCollectionChangedAction.Remove:
                foreach (String s in e.OldItems)
                    Debug.Log($"Remove :  {s}");
                break;
            case NotifyCollectionChangedAction.Replace:
                Debug.Log("Repaced - " + e.NewItems[0]);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIEnumerable : MonoBehaviour
{

    private void Start()
    {
        // create data
        Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };
        //fill data to IEnumerable
        People peopleList = new People(peopleArray);

        // collect(get) data to show
        foreach (Person p in peopleList)
            Debug.Log(p.firstName + " " + p.lastName);
    }

}
public class Person
{
    public string firstName;
    public string lastName;
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }
}
public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];
        for (int i = 0; i < pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
    public IEnumerator GetEnumerator()
    {
        Debug.Log("here call foreach");
        return new PeopleEnum(_people);
    }
}
public class PeopleEnum : IEnumerator
{
    public Person[] _people;
    int position = -1;
    public PeopleEnum(Person[] list)
    {

        _people = list;
    }
    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }
    public void Reset()
    {
        position = -1;
    }
    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }
    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}


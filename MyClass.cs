using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExamples.Generic;

public class MyClass<T>
{
    private T[] _arr;
    private int top; // Index of the top item in the stack

    public MyClass()
    {
        _arr = new T[0];
        top = -1; // Initialize top to -1 indicating an empty stack
    }

    public void Add(T obj)
    {
        Array.Resize(ref _arr, _arr.Length + 1);
        _arr[++top] = obj; // Increment top and then assign the value
    }

    public void ShowAll()
    {
        foreach (var item in _arr)
        {
            Console.WriteLine(item);
        }
    }

    public int FindIndexOf(T obj)
    {
        for (int i = 0; i <= top; i++)
        {
            if (Equals(_arr[i], obj)) //here I wanted to try Equals method because !!it is reference equality here!!
            {
                return i;
            }
        }
        return -1; // Object not found
    }

    public void Remove(T obj)
    {
        int index = FindIndexOf(obj);
        if (index != -1)
        {
            // Shift elements to the left to fill the gap
            for (int i = index; i < top; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            Array.Resize(ref _arr, _arr.Length - 1); // Resize to remove the last element
            top--;
        }
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public void Clear()
    {
        _arr = new T[0];
        top = -1;
    }
}
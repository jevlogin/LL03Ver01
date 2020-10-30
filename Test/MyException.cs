using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyException : Exception
{
    public int Value { get; }

    public MyException(string message, int value) : base(message)
    {
        Value = value;
    }
}

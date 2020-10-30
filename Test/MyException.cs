using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyException : Exception
{
    public int Value { get; }
    public Button Button { get; }

    public MyException(string message, int value) : base(message)
    {
        Value = value;
    }

    public MyException(string message, Button button) : base(message)
    {
        Button = button;
    }
}

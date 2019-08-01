using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TestManager 
{
    private static TestManager _instance;
    public static TestManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new TestManager();
            }
            return _instance;
        }
    }

    public delegate void TestDelegate();

    public TestDelegate GetTestMethodDG()
    {
        TestDelegate cb = TestMethod;
        return cb;
    }

    public void TestMethod()
    {
        Debug.Log("CPP: 测试 C++ 传递对象 ... ");
    }
}

public struct TestMangerStructs {
    public IntPtr TestMethodPtr;
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CppInterfacePlat
{
    private static CppInterfacePlat _instance;
    public static CppInterfacePlat Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new CppInterfacePlat();
            }
            return _instance;
        }
    }

    public void Init()
    {
        Debug.Log(Application.platform + " Init....");
    }

    public void Close()
    {
        Debug.Log(Application.platform + " Close....");
    }

    [DllImport("libCppInterface")]
    public static extern int Add(int a, int b);

    [DllImport("libCppInterface")]
    public static extern void SetDebugFunction(IntPtr intPtr);

    [DllImport("libCppInterface")]
    public static extern void init_register_luaState(IntPtr intPtr);


}

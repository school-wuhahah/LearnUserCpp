using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.IO;

public class CppInterface 
{
    private const string libpath = "Plugins/x86_64/CppInterface.dll";

    private IntPtr libPtr = IntPtr.Zero;

    private delegate int AddDelegate(int a, int b);
    private AddDelegate addDelegate;
    private delegate void PtrDelegate(IntPtr intPtr);
    private PtrDelegate setDebugFuncDelegate;
    private PtrDelegate initLuaState;

    private static CppInterface _instance;
    public static CppInterface Instance {
        get
        {
            if (null == _instance)
            {
                _instance = new CppInterface();
            }
            return _instance;
        }
    }

    public void Init()
    {
        string path = Path.Combine(Application.dataPath, libpath);
        libPtr = CppLibManager.OpenLibrary(path);
        //---
        addDelegate = CppLibManager.GetDelegate<AddDelegate>(libPtr, "Add");
        setDebugFuncDelegate = CppLibManager.GetDelegate<PtrDelegate>(libPtr, "SetDebugFunction");
        initLuaState = CppLibManager.GetDelegate<PtrDelegate>(libPtr, "init_register_luaState");
    }

    public void Close()
    {
        CppLibManager.CloseLibrary(libPtr);
    }


    public int Add(int a, int b)
    {
        return addDelegate(a, b);
    }

    public void SetDebugFunction(IntPtr ptr)
    {
        setDebugFuncDelegate(ptr);
    }

    public void init_register_luaState(IntPtr ptr)
    {
        initLuaState(ptr);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.IO;

public class CppInterfaceEditor
{
    private const string libpath = "Plugins/x86_64/CppInterface.dll";

    private IntPtr libPtr = IntPtr.Zero;

    private delegate int AddDelegate(int a, int b);
    private AddDelegate addDelegate;
    private delegate void PtrDelegate(IntPtr intPtr);
    private PtrDelegate setDebugFuncDelegate;
    private PtrDelegate initLuaState;

    private static CppInterfaceEditor _instance;
    public static CppInterfaceEditor Instance {
        get
        {
            if (null == _instance)
            {
                _instance = new CppInterfaceEditor();
            }
            return _instance;
        }
    }

    public void Init()
    {
#if UNITY_EDITOR
        string path = Path.Combine(Application.dataPath, libpath);
        libPtr = CppLibManager.OpenLibrary(path);
        //---
        addDelegate = CppLibManager.GetDelegate<AddDelegate>(libPtr, "Add");
        setDebugFuncDelegate = CppLibManager.GetDelegate<PtrDelegate>(libPtr, "SetDebugFunction");
        initLuaState = CppLibManager.GetDelegate<PtrDelegate>(libPtr, "init_register_luaState");
#endif
    }

    public void Close()
    {
#if UNITY_EDITOR
        CppLibManager.CloseLibrary(libPtr);
#endif
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

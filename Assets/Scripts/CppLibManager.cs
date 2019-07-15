using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System;

/// <summary>
/// cpp Library manager
/// Update Cpp Library Without Restarting the Editor
/// </summary>
public class CppLibManager : MonoBehaviour
{

#if UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX

    [DllImport("__Internal", EntryPoint = "dlopen")]
    public static extern IntPtr LoadLib(string path, int flag);

    [DllImport("__Internal", EntryPoint = "dlsym")]
    public static extern IntPtr GetProcAddr(IntPtr intPtr, string symbolName);

    [DllImport("__Internal", EntryPoint = "dlclose")]
    public static extern int FreeLib(IntPtr intPtr);

#elif UNITY_EDITOR_WIN

    [DllImport("kernel32", EntryPoint = "LoadLibrary")]
    public static extern IntPtr LoadLib(string path, int flag);

    [DllImport("kernel32", EntryPoint = "GetProcAddress")]
    public static extern IntPtr GetProcAddr(IntPtr intPtr, string symbolName);

    [DllImport("kernel32", EntryPoint = "FreeLibrary")]
    public static extern IntPtr FreeLib(IntPtr intPtr);

#endif


    public static IntPtr OpenLibrary(string path)
    {
        IntPtr handle = LoadLib(path, 0);
        if (handle == IntPtr.Zero)
        {
            throw new Exception("Couldn't open native library: " + path);
        }
        return handle;
    }

    public static void CloseLibrary(IntPtr libHandle)
    {
        FreeLib(libHandle);
    }

    public static T GetDelegate<T>(IntPtr libHandle, string funcName) where T : class
    {
        IntPtr symbol = GetProcAddr(libHandle, funcName);
        if (symbol == IntPtr.Zero)
        {
            throw new Exception("Couldn't get function: " + funcName);
        }
        return Marshal.GetDelegateForFunctionPointer<T>(symbol);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CppInterface
{
    private static CppInterface _instance;

    public static CppInterface Instance
    {
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

#if UNITY_ANDROID || UNITY_IPHONE
        CppInterfacePlat.Instance.Init();
#elif UNITY_EDITOR
        CppInterfaceEditor.Instance.Init();
#endif
    }

    public void Close()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        CppInterfacePlat.Instance.Close();
#elif UNITY_EDITOR
        CppInterfaceEditor.Instance.Close();
#endif
    }

    public int Add(int a, int b)
    {
#if UNITY_ANDROID || UNITY_IPHONE
        return CppInterfacePlat.Add(a, b);
#elif UNITY_EDITOR
        return CppInterfaceEditor.Instance.Add(a, b);
#endif
    }

    public void SetDebugFunction(IntPtr intPtr)
    {
#if UNITY_ANDROID || UNITY_IPHONE
        CppInterfacePlat.SetDebugFunction(intPtr);
#elif UNITY_EDITOR
        CppInterfaceEditor.Instance.SetDebugFunction(intPtr);
#endif
    }

    public void init_register_luaState(IntPtr intPtr)
    {
#if UNITY_ANDROID || UNITY_IPHONE
        CppInterfacePlat.init_register_luaState(intPtr);
#elif UNITY_EDITOR
        CppInterfaceEditor.Instance.init_register_luaState(intPtr);
#endif
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CppInterface 
{
    [DllImport("CppInterface")]
    public extern static int Add(int a, int b);

    [DllImport("CppInterface")]
    public extern static void SetDebugFunction(IntPtr ptr);
}

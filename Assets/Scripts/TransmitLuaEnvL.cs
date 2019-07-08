/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using UnityEngine;
using System.Collections;
using XLua;
using System;
using System.Runtime.InteropServices;

public class TransmitLuaEnvL : MonoBehaviour {
    LuaEnv luaenv = null;
    private delegate void DebugDelegate(IntPtr strPtr);
    // Use this for initialization
    void Start()
    {
        RegisterDebugCallback();
        luaenv = new LuaEnv();
        CppInterface.init_register_luaState(luaenv.L);
        luaenv.DoString("require 'luaTestFunc'");
    }

    // Update is called once per frame
    void Update()
    {
        if (luaenv != null)
        {
            luaenv.Tick();
        }
    }

    void OnDestroy()
    {
        luaenv.Dispose();
    }

    void RegisterDebugCallback()
    {
        DebugDelegate cb = CallBackFunction;
        IntPtr intptr_delegate = Marshal.GetFunctionPointerForDelegate(cb);
        CppInterface.SetDebugFunction(intptr_delegate);
    }

    static void CallBackFunction(IntPtr strPtr)
    {
        Debug.Log("CppLog: " + Marshal.PtrToStringAnsi(strPtr));
    }
}

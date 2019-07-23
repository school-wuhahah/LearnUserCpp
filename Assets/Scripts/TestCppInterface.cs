using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TestCppInterface : MonoBehaviour
{
    public Text showMsg;
    private int num = 0;

    private delegate void DebugDelegate(IntPtr strPtr);

    // Start is called before the first frame update
    void Start()
    {
        CppInterface.Instance.Init();
        //RegisterDebugCallback();
        StartCoroutine(UpdateNum());
    }

    IEnumerator UpdateNum()
    {
        while(true)
        {
            showMsg.text = num.ToString();
            num = CppInterface.Instance.Add(num, 1);
            yield return new WaitForSeconds(1.0f);
        }
    }

    void RegisterDebugCallback()
    {
        DebugDelegate cb = CallBackFunction;
        IntPtr intptr_delegate = Marshal.GetFunctionPointerForDelegate(cb);
        CppInterface.Instance.SetDebugFunction(intptr_delegate);
    }

    static void CallBackFunction(IntPtr strPtr)
    {
        Debug.Log("CppLog: " + Marshal.PtrToStringAnsi(strPtr));
    }

    private void OnApplicationQuit()
    {
        CppInterface.Instance.Close();
    }


}

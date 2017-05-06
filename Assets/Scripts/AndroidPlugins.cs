using System;
using System.Collections.Generic;
using UnityEngine;

class AndroidPlugins : MonoSingleton<AndroidPlugins>
{

    private AndroidJavaObject m_JavaObj = null;

    private AndroidPlugins()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        this.m_JavaObj = javaClass.GetStatic<AndroidJavaObject>("currentActivity");
#endif
    }

    public void CallStaticJavaFunc()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        m_JavaObj.CallStatic("callStaticJavaFunc");
#endif
    }

    public void CallNormalJavaFunc()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        this.m_JavaObj.Call("callNormalJavaFunc");
#endif
    }

    public void Purchase(string payCode)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        this.m_JavaObj.Call("purchase", payCode);
#endif
    }

    public void OnPurchaseResult(string result)
    {
        Debug.Log("result: " + result);
    }
}

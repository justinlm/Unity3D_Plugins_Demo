using System;
using System.Collections.Generic;
using UnityEngine;

class AndroidPlugins : MonoSingleton<AndroidPlugins>
{
 
    private AndroidJavaObject m_JavaObj = null;

    private AndroidPlugins()
    {
        AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        this.m_JavaObj = javaClass.GetStatic<AndroidJavaObject>("currentActivity");
    }

    public void CallStaticJavaFunc()
    {
        m_JavaObj.CallStatic("callStaticJavaFunc");
    }

    public void CallNormalJavaFunc()
    {
        this.m_JavaObj.Call("callNormalJavaFunc");
    }

    public void Purchase(string payCode)
    {
        this.m_JavaObj.Call("purchase", payCode);
    }

    public void OnPurchaseResult(string result)
    {
        Debug.Log("result: " + result);
    }
}

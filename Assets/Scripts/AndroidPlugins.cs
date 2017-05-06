using System;
using System.Collections.Generic;
using UnityEngine;

class AndroidPlugins
{
    private volatile static AndroidPlugins m_Instance = null;
    private readonly static object m_LockHelper = new object();

    private AndroidJavaObject m_JavaObj = null;

    public static AndroidPlugins Instance()
    {
        if(m_Instance == null)
        {
            lock(m_LockHelper)
            {
                if(m_Instance == null)
                {
                    m_Instance = new AndroidPlugins();
                }
            }
        }
        return m_Instance;
    }

    private AndroidPlugins()
    {
        AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        this.m_JavaObj = javaClass.GetStatic<AndroidJavaObject>("currentActivity");
    }

    public void CallStaticJavaFunc()
    {
        m_JavaObj.CallStatic("staicJavaFunc");
    }

    public void CallNormalJavaFunc()
    {
        this.m_JavaObj.Call("normalJavaFunc");
    }

    public void Purchase(string payCode)
    {
        this.m_JavaObj.Call("Purchase", payCode);
    }

    public void OnPurchaseResult(string result, string payCode)
    {
        Debug.Log("result: " + result + " payCode:" + payCode);
    }
}

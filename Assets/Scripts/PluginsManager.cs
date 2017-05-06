using System;
using System.Collections.Generic;
using UnityEngine;

class PluginsManager : MonoSingleton<PluginsManager>
{
    IOSPlugins m_IOSPlugins = null;
    AndroidPlugins m_AndroidPlugins = null;

    private void Awake()
    {
#if UNITY_IOS
        m_IOSPlugins = IOSPlugins.Instance();
#else
        m_AndroidPlugins = AndroidPlugins.Instance;
#endif
    }

    public void RequestProductData(string [] productIDs)
    {
        m_IOSPlugins.RequestProductData(productIDs);
    }

    public void HelloIOS()
    {
        m_IOSPlugins.HelloIOS();
    }

    public void CallNormalJavaFunc()
    {
        m_AndroidPlugins.CallNormalJavaFunc();
    }

    public void CallStaticJavaFunc()
    {
        m_AndroidPlugins.CallStaticJavaFunc();
    }

    public void PurchaseProduct(string productID)
    {
#if UNITY_IOS
        m_IOSPlugins.PurchaseProduct(productID);
#else
        m_AndroidPlugins.Purchase(productID);
#endif
    }
}


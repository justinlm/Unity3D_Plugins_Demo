using System;
using System.Collections.Generic;
using IOSStore;
using UnityEngine;
using System.Runtime.InteropServices;

class IOSPlugins: MonoSingleton<IOSPlugins>,IStoreDelegate
{
    private List<StoreProduct> m_RequestProductList;

    private String[] m_ProductIDs;

    private IOSPlugins()
    {
      
    }

    private void Awake()
    {
        m_RequestProductList = new List<StoreProduct>();
        StoreKit.Instance.Delegate = this;
    }


    public void RequestProductData(String [] productIDs)
    {
        m_ProductIDs = productIDs;

        if (!StoreKit.Instance.IsAvailable)
            return;
        StoreKit.Instance.Request(productIDs);
    }

    public void PurchaseProduct(string productID)
    {
        if (!StoreKit.Instance.IsAvailable)
            return;
        if (m_RequestProductList.Count > 0)
        {
            StoreKit.Instance.Purchase(productID);
        }
        else
        {
            StoreKit.Instance.Request(m_ProductIDs);
            OnStoreTransactionFailed(productID);
        }
    }

    public void Restore()
    {
        if (!StoreKit.Instance.IsAvailable)
            return;
        StoreKit.Instance.Restore();
    }

#if UNITY_IOS && !UNITY_EDITOR
		[DllImport("__Internal")]
		private static extern void _HelloIOS(string str);
#endif
    public void HelloIOS()
    {
#if UNITY_IOS && !UNITY_EDITOR
        _HelloIOS("Hello ios");
#endif
    }

    public void HelloIOSCallBack(string backMessage)
    {
        Debug.Log("backMessage :" + backMessage);
    }

    /// <summary>
    /// Handles the request success event.
    /// </summary>
    /// <param name="identifier">product identifier.</param>
    public void OnStoreRequestSuccess(IEnumerable<StoreProduct> products)
    {
        Debug.Log("OnStoreRequestSuccess");

        IEnumerator<StoreProduct> productEmtor = products.GetEnumerator();
        while (productEmtor.MoveNext())
        {
            m_RequestProductList.Add(productEmtor.Current);
        }
    }

    /// <summary>
    /// Handles the request failed event.
    /// </summary>
    public void OnStoreRequestFailed(string error)
    {
        Debug.Log("OnStoreRequestFailed : " + error);
    }

    /// <summary>
    /// Handles the transaction success event.
    /// </summary>
    /// <param name="identifier">product identifier.</param>
    public void OnStoreTransactionSuccess(string identifier)
    {
        Debug.Log("OnStoreTransactionSuccess : " + identifier);
    }

    /// <summary>
    /// Handles the transaction failed event.
    /// </summary>
    /// <param name="identifier">product identifier.</param>
    public void OnStoreTransactionFailed(string identifier)
    {
        Debug.Log("OnStoreTransactionFailed : " + identifier);
    }

    /// <summary>
    /// Handles the transaction restore event.
    /// </summary>
    /// <param name="identifier">product identifier.</param>
    public void OnStoreTransactionRestore(string identifier)
    {
        Debug.Log("OnStoreTransactionRestore : " + identifier);
    }
}

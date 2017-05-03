using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using IOSStore;
using UnityEngine.UI;

public class Example : MonoBehaviour, IStoreDelegate
{
	/// <summary>
	/// Fullgame identifier.
	/// </summary>
	private string m_CurProductID = "PID00000ID1";

    public Button m_BtnRequestProductData;
    public Button m_BtnPurchaseProduct;
    public Button m_BtnRestore;


    I_IOSStore m_IosStore = null;
	/// <summary>
	/// Setup store.
	/// </summary>
	private void Awake()
	{
		StoreKit.Instance.Delegate = this;
	}

    private void Start()
    {
        m_IosStore  = StoreKit.Instance;

        m_BtnRequestProductData = this.transform.Find("BtnRequestProductData").GetComponent<Button>();
        m_BtnRequestProductData.onClick.AddListener(RequestProductData);

        m_BtnPurchaseProduct = this.transform.Find("BtnPurchaseProduct").GetComponent<Button>();
        m_BtnPurchaseProduct.onClick.AddListener(PurchaseProduct);

        m_BtnRestore = this.transform.Find("BtnRestore").GetComponent<Button>();
        m_BtnRestore.onClick.AddListener(Restore);
    }

    private void RequestProductData()
    {
        Debug.Log("RequestProductData");
        if (!m_IosStore.IsAvailable)
            return;
        m_IosStore.Request(new [] { m_CurProductID });
    }

    private void PurchaseProduct()
    {
        Debug.Log("PurchaseProduct");
        if (!m_IosStore.IsAvailable)
            return;
        m_IosStore.Purchase(m_CurProductID);
    }

    private void Restore()
    {
        Debug.Log("Restore");
        if (!m_IosStore.IsAvailable)
            return;
        m_IosStore.Restore();
    }

	/// <summary>
	/// Handles the request success event.
	/// </summary>
	/// <param name="identifier">product identifier.</param>
	public void OnStoreRequestSuccess(IEnumerable<StoreProduct> products)
	{
	}
	
	/// <summary>
	/// Handles the request failed event.
	/// </summary>
	public void OnStoreRequestFailed(string error)
	{
	}
	
	/// <summary>
	/// Handles the transaction success event.
	/// </summary>
	/// <param name="identifier">product identifier.</param>
	public void OnStoreTransactionSuccess(string identifier)
	{
		switch (identifier)
		{
		//case m_CurProductID:
			// Save fullgame value in player prefs.
			//break;
		}
	}
	
	/// <summary>
	/// Handles the transaction failed event.
	/// </summary>
	/// <param name="identifier">product identifier.</param>
	public void OnStoreTransactionFailed(string identifier)
	{
	}
	
	/// <summary>
	/// Handles the transaction restore event.
	/// </summary>
	/// <param name="identifier">product identifier.</param>
	public void OnStoreTransactionRestore(string identifier)
	{
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using IOSStore;
using UnityEngine.UI;

public class Example : MonoBehaviour
{

    public GameObject m_Panel_IOS;
    public GameObject m_Panel_Android;
    // product identifier
    private string m_CurProductID = "PID00000ID1";

    public Button m_BtnPurchaseProduct;
    public Button m_BtnTest1;
    public Button m_BtnTest2;

    PluginsManager m_PluginsManager = null;

    /// <summary>
    /// Setup store.
    /// </summary>
    private void Awake()
	{
        m_PluginsManager = PluginsManager.Instance;

#if UNITY_IOS
        m_Panel_Android.SetActive(false);
        m_Panel_IOS.SetActive(true);
        m_PluginsManager.RequestProductData(new string [] { m_CurProductID });
#else
        m_Panel_Android.SetActive(true);
        m_Panel_IOS.SetActive(false);
#endif
    }

    private void Start()
    {
#if UNITY_IOS
        m_BtnPurchaseProduct = m_Panel_IOS.transform.Find("PurchaseProductBtn").GetComponent<Button>();
        m_BtnPurchaseProduct.onClick.AddListener(PurchaseProduct);

        m_BtnTest1 = m_Panel_IOS.transform.Find("HelloIOSBtn").GetComponent<Button>();
        m_BtnTest1.onClick.AddListener(HelloIOS);
#else
        m_BtnPurchaseProduct = m_Panel_Android.transform.Find("PurchaseProductBtn").GetComponent<Button>();
        m_BtnPurchaseProduct.onClick.AddListener(PurchaseProduct);

        m_BtnTest1 = m_Panel_Android.transform.Find("CallNormalJavaFuncBtn").GetComponent<Button>();
        m_BtnTest1.onClick.AddListener(CallNormalJavaFunc);

        m_BtnTest2 = m_Panel_Android.transform.Find("CallStaticJavaFuncBtn").GetComponent<Button>();
        m_BtnTest2.onClick.AddListener(CallStaticJavaFunc);
#endif
    }

#if UNITY_IOS
    private void HelloIOS()
    {
        Debug.Log("HelloIOS");
        m_PluginsManager.HelloIOS();
    }
#else
    private void CallNormalJavaFunc()
    {
        Debug.Log("CallNormalJavaFunc");
        m_PluginsManager.CallNormalJavaFunc();
    }

    private void CallStaticJavaFunc()
    {
        Debug.Log("CallStaticJavaFunc");
        m_PluginsManager.CallStaticJavaFunc();
    }
#endif

    private void PurchaseProduct()
    {
        Debug.Log("PurchaseProduct");
        m_PluginsManager.PurchaseProduct(m_CurProductID);
    }
}

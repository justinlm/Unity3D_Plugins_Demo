﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace IOSStore
{
	/// <summary>
	/// Bridge class for StoreKit and Unity.
	/// </summary>
	public sealed class StoreKit : MonoSingleton<StoreKit>
    {
        /// <summary>
        /// initialze
        /// </summary>
        private StoreKit()
        {

        }

        private void Awake()
        {
#if UNITY_IOS && !UNITY_EDITOR
			USKInit(gameObject.name);
#endif
        }


#if UNITY_IOS && !UNITY_EDITOR
		[DllImport("__Internal")]
		private static extern void USKInit(string targetClass);
		[DllImport("__Internal")]
		private static extern bool USKCanMakePayments();
		[DllImport("__Internal")]
		private static extern void USKRequest(string[] identifiers, int length);
		[DllImport("__Internal")]
		private static extern int  USKGetProducts([Out] out IntPtr productsPtr);
		[DllImport("__Internal")]
		private static extern void USKPurchase(string identifier);
		[DllImport("__Internal")]
		private static extern void USKRestore();
#endif

        /// <summary>
        /// Gets or sets the delegate.
        /// </summary>
        /// <value>The delegate.</value>
        public IStoreDelegate Delegate { get; set; }

		/// <summary>
		/// Checks that store is available on the current device.
		/// </summary>
		public bool IsAvailable 
		{ 
			get 
			{ 
#if UNITY_IOS && !UNITY_EDITOR
				return USKCanMakePayments(); 
#else
				return false;
#endif
			}
		}

		/// <summary>
		/// Fetch products data form store.
		/// </summary>
		/// <param name="products"></param>
		/// <param name="handler"></param>
		public void Request(IEnumerable<string> products)
		{
#if UNITY_IOS && !UNITY_EDITOR
			USKRequest(products.ToArray(), products.Count());
#endif
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="product"></param>
		/// <param name="handler"></param>
		public void Purchase(string productIdentifier)
		{
#if UNITY_IOS && !UNITY_EDITOR
			USKPurchase(productIdentifier);
#endif
		}

		/// <summary>
		/// 
		/// </summary>
		public void Restore()
		{
#if UNITY_IOS && !UNITY_EDITOR
			USKRestore();
#endif
		}

		/// <summary>
		/// 
		/// </summary>
		private void HandleRequestSuccess()
		{
			IntPtr source = IntPtr.Zero;
			int size = 0;

#if UNITY_IOS && !UNITY_EDITOR
			size = USKGetProducts(out source);
#endif

			IEnumerable<StoreProduct> shelf = ObjCMarshalArray<StoreProduct>(source, size, new StoreProduct[0]);

			if (Delegate != null)
				Delegate.OnStoreRequestSuccess(shelf);
		}

		/// <summary>
		/// 
		/// </summary>
		private void HandleRequestFailed(string error)
		{
			if (Delegate != null)
				Delegate.OnStoreRequestFailed(error);
		}

		/// <summary>
		/// Handles the transaction success.
		/// </summary>
		/// <param name="productIdentifier">Product identifier.</param>
		private void HandleTransactionSuccess(string identifier)
		{
			if (Delegate != null)
				Delegate.OnStoreTransactionSuccess(identifier);
		}

		/// <summary>
		/// Handles the transaction failed.
		/// </summary>
		private void HandleTransactionFailed(string identifier)
		{
			if (Delegate != null)
				Delegate.OnStoreTransactionFailed(identifier);
		}

		/// <summary>
		/// Handles the transaction restore.
		/// </summary>
		/// <param name="productIdentifier">Product identifier.</param>
		private void HandleTransactionRestore(string identifier)
		{
			if (Delegate != null)
				Delegate.OnStoreTransactionRestore(identifier);
		}

		/// <summary>
		/// Converts native Objective-C array into C# array.
		/// </summary>
		private T[] ObjCMarshalArray<T>(IntPtr source, int length, T[] @default) where T : new()
		{
			if (source == IntPtr.Zero || length == 0)
				return @default;
			
			T[] array = new T[length];
			
			for (int i = 0; i < length; i++)
			{
				int offset = Marshal.SizeOf(typeof(T)) * i;
				
				array[i] = (T)Marshal.PtrToStructure(new IntPtr(source.ToInt32() + offset), typeof(T));
			}
			
			Marshal.FreeHGlobal(source);
			
			return array;
		}
	}
}
using System;
using System.Collections.Generic;

namespace IOSStore
{
	/// <summary>
	/// Common store delegate interface.
	/// </summary>
	public interface IStoreDelegate
	{
		/// <summary>
		/// Handles the request success event.
		/// </summary>
		/// <param name="identifier">product identifier.</param>
		void OnStoreRequestSuccess(IEnumerable<StoreProduct> products);
		
		/// <summary>
		/// Handles the request failed event.
		/// </summary>
		void OnStoreRequestFailed(string error);
		
		/// <summary>
		/// Handles the transaction success event.
		/// </summary>
		/// <param name="identifier">product identifier.</param>
		void OnStoreTransactionSuccess(string identifier);
		
		/// <summary>
		/// Handles the transaction failed event.
		/// </summary>
		/// <param name="identifier">product identifier.</param>
		void OnStoreTransactionFailed(string identifier);
		
		/// <summary>
		/// Handles the transaction restore event.
		/// </summary>
		/// <param name="identifier">product identifier.</param>
		void OnStoreTransactionRestore(string identifier);
	}
}
using System;
using System.Collections.Generic;

namespace IOSStore
{
    /// <summary>
    /// Common store interface.
    /// </summary>
    public interface I_IOSStore
    {
		/// <summary>
		/// Gets or sets the delegate.
		/// </summary>
		/// <value>The delegate.</value>
		IStoreDelegate Delegate { get; set; }

		/// <summary>
		/// Checks that store is available on the current device.
		/// </summary>
		bool IsAvailable { get; }

        /// <summary>
        /// Downloads products data form store.
        /// </summary>
        /// <param name="products"></param>
        /// <param name="handler"></param>
        void Request(IEnumerable<string> identifiers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="handler"></param>
        void Purchase(string identifier);

        /// <summary>
        /// 
        /// </summary>
        void Restore();
    }
}
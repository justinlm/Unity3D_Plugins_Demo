namespace IOSStore
{
	/// <summary>
	/// Store product struct.
	/// </summary>
	public struct StoreProduct
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="id">Unique product identifier.</param>
		/// <param name="title">Product title.</param>
		/// <param name="price">ocalized product price (with price tag).</param>
		/// <param name="description">Localized description.</param>
		internal StoreProduct(string id, string title, string price, string description)
		{
		    ID = id;
		    Title = title;
		    Price = price;
		    Description = description;
		}

		/// <summary>
		/// Unique product identifier.
		/// </summary>
		public string ID { get; private set; }

		/// <summary>
		/// Product title.
		/// </summary>
		public string Title { get; private set; }

		/// <summary>
		/// Localized product price (with price tag).
		/// </summary>
		public string Price { get; private set; }

		/// <summary>
		/// Localized description.
		/// </summary>
		public string Description { get; private set; }
	}
}
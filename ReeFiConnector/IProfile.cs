namespace ReefCode.Reefi
{
	public interface IProfile
	{
		string Name { get; }

		/// <summary>
		/// 400 UV
		/// </summary>
		int Channel_0 {get;}

		/// <summary>
		/// 420
		/// </summary>
		int Channel_1 { get; }

		/// <summary>
		/// Violet
		/// </summary>
		int Channel_2 { get; }

		/// <summary>
		/// Royal Blue
		/// </summary>
		int Channel_3 { get; }

		/// <summary>
		/// Blue
		/// </summary>
		int Channel_4 { get; }

		/// <summary>
		/// Lime
		/// </summary>
		int Channel_5 { get; }

		/// <summary>
		/// Amber
		/// </summary>
		int Channel_6 { get; }

		/// <summary>
		/// Warm White
		/// </summary>		
		int Channel_7 { get; }

		/// <summary>
		/// Cool White
		/// </summary>
		int Channel_8 { get; }

	}
}

namespace Rekisteriprojekti
{
	class Auto
	{
		public string Rekisterinumero { get; }
		public string Merkki { get; }
		public string Malli { get; }

		public Auto(string rekisterinumero, string merkki, string malli)
		{
			Rekisterinumero = rekisterinumero;
			Merkki = merkki;
			Malli = malli;
		}

		public override string ToString()
		{
			return $"{Rekisterinumero};{Merkki};{Malli}";
		}
	}
}


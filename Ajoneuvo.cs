
using System;

namespace Rekisteriprojekti
{
	abstract class Ajoneuvo
	{
		public string Rekisterinumero { get; }
		public string Merkki { get; }
		public string Malli { get; }

		protected Ajoneuvo(string rekisterinumero, string merkki, string malli)
		{
			Rekisterinumero = rekisterinumero;
			Merkki = merkki;
			Malli = malli;
		}

		public abstract void TulostaTiedot();
	}
}

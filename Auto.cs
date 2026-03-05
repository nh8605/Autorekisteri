
namespace Rekisteriprojekti
{
	class Auto : Ajoneuvo, ITallennettava
	{
		public Auto(string rekisterinumero, string merkki, string malli)
			: base(rekisterinumero, merkki, malli)
		{
		}

		public override void TulostaTiedot()
		{
			Console.WriteLine($"{Rekisterinumero} – {Merkki} {Malli}");
		}

		public string MuunnaTallennusmuotoon()
		{
			return $"{Rekisterinumero};{Merkki};{Malli}";
		}

		public override string ToString()
		{
			return $"{Merkki} {Malli} ({Rekisterinumero})";
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Rekisteriprojekti
{
	class Autorekisteri
	{
		private List<Auto> autot = new List<Auto>();

		public void LisaaAuto(Auto auto)
		{
			autot.Add(auto);
		}

		public Auto HaeAuto(string rekisterinumero)
		{
			foreach (var auto in autot)
			{
				if (auto.Rekisterinumero.Equals(rekisterinumero, StringComparison.OrdinalIgnoreCase))
					return auto;
			}
			return null;
		}

		public bool PoistaAuto(string rekisterinumero)
		{
			Auto poistettava = HaeAuto(rekisterinumero);

			if (poistettava != null)
			{
				autot.Remove(poistettava);
				return true;
			}
			return false;
		}

		public void ListaaAutot()
		{
			Console.WriteLine("\nRekisterissä olevat autot:");
			foreach (var auto in autot)
				Console.WriteLine($"{auto.Rekisterinumero} – {auto.Merkki} {auto.Malli}");
		}

		public void TallennaTiedostoon(string polku)
		{
			using (StreamWriter sw = new StreamWriter(polku))
			{
				foreach (var auto in autot)
					sw.WriteLine(auto.ToString());
			}
		}

		public void LataaTiedostosta(string polku)
		{
			if (!File.Exists(polku))
				return;

			autot.Clear();

			foreach (var rivi in File.ReadAllLines(polku))
			{
				string[] osat = rivi.Split(';');
				if (osat.Length == 3)
					autot.Add(new Auto(osat[0], osat[1], osat[2]));
			}
		}
	}
}

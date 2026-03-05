
using System;
using System.Collections.Generic;
using System.IO;

namespace Rekisteriprojekti
{
	class Autorekisteri
	{
		private List<Ajoneuvo> autot = new List<Ajoneuvo>();

		public void LisaaAuto(Auto auto)
		{
			autot.Add(auto);
		}

		public Auto HaeAuto(string rekisterinumero)
		{
			foreach (var a in autot)
			{
				if (a.Rekisterinumero.Equals(rekisterinumero, StringComparison.OrdinalIgnoreCase))
					return a as Auto;
			}
			return null;
		}

		public bool PoistaAuto(string rekisterinumero)
		{
			Ajoneuvo poistettava = null;
			foreach (var a in autot)
			{
				if (a.Rekisterinumero.Equals(rekisterinumero, StringComparison.OrdinalIgnoreCase))
				{
					poistettava = a;
					break;
				}
			}

			if (poistettava != null)
			{
				autot.Remove(poistettava);
				return true;
			}
			return false;
		}

		public void ListaaAutot()
		{
			Console.WriteLine("\nRekisterissä olevat ajoneuvot:");
			foreach (var a in autot)
				a.TulostaTiedot();
		}

		public void TallennaTiedostoon(string polku)
		{
			using (StreamWriter sw = new StreamWriter(polku))
			{
				foreach (var a in autot)
				{
					if (a is ITallennettava tallennettava)
						sw.WriteLine(tallennettava.MuunnaTallennusmuotoon());
				}
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
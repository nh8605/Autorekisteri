using System;

namespace Rekisteriprojekti
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Autorekisteri rekisteri = new Autorekisteri();

			// Ladataan tiedostosta
			rekisteri.LataaTiedostosta("autot.txt");

			bool jatka = true;

			while (jatka)
			{
				Console.WriteLine("\n--- AUTOREKISTERI ---");
				Console.WriteLine("1) Lisää auto");
				Console.WriteLine("2) Hae auto");
				Console.WriteLine("3) Poista auto");
				Console.WriteLine("4) Listaa kaikki");
				Console.WriteLine("5) Tallenna ja lopeta");
				Console.Write("Valinta: ");

				string valinta = Console.ReadLine();

				switch (valinta)
				{
					case "1":
						Console.Write("Rekisterinumero: ");
						string rek = Console.ReadLine();

						Console.Write("Merkki: ");
						string merkki = Console.ReadLine();

						Console.Write("Malli: ");
						string malli = Console.ReadLine();

						rekisteri.LisaaAuto(new Auto(rek, merkki, malli));
						break;

					case "2":
						Console.Write("Anna rekisterinumero: ");
						string hae = Console.ReadLine();

						Auto loydetty = rekisteri.HaeAuto(hae);

						if (loydetty != null)
							Console.WriteLine($"Löytyi: {loydetty.Merkki} {loydetty.Malli}");
						else
							Console.WriteLine("Autoa ei löytynyt.");
						break;

					case "3":
						Console.Write("Anna poistettava rekisterinumero: ");
						string poistettava = Console.ReadLine();

						if (rekisteri.PoistaAuto(poistettava))
							Console.WriteLine("Auto poistettiin.");
						else
							Console.WriteLine("Autoa ei löytynyt.");
						break;

					case "4":
						rekisteri.ListaaAutot();
						break;

					case "5":
						rekisteri.TallennaTiedostoon("autot.txt");
						jatka = false;
						break;

					default:
						Console.WriteLine("Virheellinen valinta.");
						break;
				}
			}
		}
	}
}

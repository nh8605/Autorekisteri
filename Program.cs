namespace omaolioprojekti
{
    internal class Program
    {
		static void Main(string[] args)
		{ }

		  using System;

class Program
	{
		static void Main()
		{
			Autorekisteri rekisteri = new Autorekisteri();

			rekisteri.LisaaAuto(new Auto("ABC-123", "Toyota", "Corolla"));
			rekisteri.LisaaAuto(new Auto("XYZ-999", "Volvo", "V70"));


			Console.Write("Anna rekisterinumero: ");
			string haettava = Console.ReadLine();

			Auto loydetty = rekisteri.HaeAuto(haettava);

			if (loydetty != null)
			{
				Console.WriteLine($"Auto on {loydetty.Merkki} {loydetty.Malli}");
			}
			else
			{
				Console.WriteLine("Autoa ei löytynyt.");
			}
		}
	}

}
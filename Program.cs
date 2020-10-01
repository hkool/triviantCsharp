using System;

namespace ConsoleAppTriviant
{
    class Program
    {

        static int Score = 0; // aantal vragen goed
        static string[] Vragen; //vraag
        static string[][] Antwoorden; // array met multiple antwoorden
        static int[] JuisteAntwoord ;  // index  in array antwoorden van het juiste antwoord + 1- i.v.m. de nummering op het scherm.
        static void Main(string[] args)
        {
            maakVragen();
            
            Console.WriteLine("Welkom bij Triviant.");
            Console.WriteLine("Je ziet een vraag op het scherm.");
            Console.WriteLine("Je ziet vier antwoorden.");
            Console.WriteLine("Kies het juiste antwoord en je krijgt gelijk " +
                "het resultaat. Zullen we beginnen, geef dan een Enter.");
            Console.ReadLine();
            
            int Antwoord;
            for (int i = 0; i < Vragen.Length; i++) { 

                showVraag(i);
          
                showAntwoorden(i);
                    try
                    {
                        Antwoord = int.Parse(Console.ReadLine());
                        switch (checkAntwoord(Antwoord, i))
                        {
                            case 1:
                                Console.WriteLine("Goed gedaan.");
                                Score++;
                                break;
                            case 0:
                                Console.WriteLine("Dat is helaas niet goed. Het antwoord is " + Antwoorden[i][JuisteAntwoord[i]]);
                                break;
                            case 99:
                                Console.WriteLine("Dit is geen geldige invoer.");
                                break;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message); 
                    }
                Console.ReadLine();
            } 
            
            Console.WriteLine("Je hebt " + Score + " punt(en).");
            Console.ReadLine();
        }
        static void maakVragen()
        {
            Vragen = new string[5] {
                "In welk jaar overleed de zanger Michael Jackson?",
            "Welke componist heeft maar liefst 8 Oscars gewonnen voor de muziek voor Disneyfilms?"," Van wie is Sasha Fierce het alter ego?",
            "Hoe heet iemand die dansstukken bedenkt?", "Wie staat bekend als The King of Reggae?" }; //vraag
            Antwoorden = new string[5][];
            Antwoorden[0] = new string[] { "2000", "2009", "2010", "2011" };
            Antwoorden[1] = new string[] { "Ennio Morricone", "John Williams", "Alan Menken", "Hans Zimmer" };
            Antwoorden[2] = new string[] { "Jennifer Lopez", "Lady Gaga", "Beyonce", "Christina Aguillera" };
            Antwoorden[3] = new string[] { "choreograaf", "componist", "dirigent", "regisseur" };
            Antwoorden[4] = new string[] { "Peter Tosh", "Mike Hammer", "Bunny Wailer", "Bob Marley" };
            JuisteAntwoord = new int[] { 1, 2, 2, 0, 3 };
        }
        static void showVraag(int Nr)
        {
            Console.WriteLine("Vraag "+ Nr + ":");
            Console.WriteLine(Vragen[Nr]);
            Console.WriteLine("");
        }
        static void showAntwoorden(int Nr)
        {
            int teller = 0;
            foreach (string antwoord in Antwoorden[Nr])
            {
                teller++;
                Console.WriteLine((teller) + ". " + antwoord);
            } 
            Console.WriteLine("");
            Console.WriteLine("Type uw keuze : 1,2,3 of 4");
        }
        static int checkAntwoord(int Antw, int Nr)
        {
            if (Antw == JuisteAntwoord[Nr] + 1)
            {
                return 1;
            }
            else if (Antw > 4 )
            {
                return 99;
            }
            else
            {
                return 0;
            }
        }
    }
}

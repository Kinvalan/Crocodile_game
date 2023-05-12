/*
Du skal bruke det du har lært til å programmere “krokodille spillet”

For hver runde skal det printes ut til skjermen et random tall mellom 1-11,
et mellomrom og et nytt tall mellom 1-11 med en underscore mellom slik at det ser sånn ut: 3 _ 5

Brukeren kan skrive inn <, > eller =

i tilfellet brukeren får 3 _ 5 vil svaret være <, altså 3 < 5

Tallene må sjekkes om det første er større eller mindre eller lik det andre tallet,
Det må verifiseres om brukeren har valgt riktig alternativ.
Brukeren får et poeng per riktig svar, og mister et poeng per feil svar.
Poengsummen printes til skjermen for hvert svar brukeren har gitt.

Spillet avsluttes når brukeren skriver inn noe annet enn de tre alternativene
*/



namespace Crocodile_game
{
    internal class Program
    {
        private static int _points = 0; // Utafor for å huske scoren uavhengig av Game metoden. understrek fordi den er private
        // private - brukes i metoder som kun skal brukes i klassen den ligger i. - private er default

        private static bool _gameRunning = true;

        private static void Main(string[] args)
        {
            while (_gameRunning) //kjører så lenge _gameRunning == true
            {
                Game();
                Console.Clear();
            }
        }

        private static void Game()
        {
            Console.WriteLine("Score: " + _points +"\n\n");
            var random = new Random();

            var randomNum1 = random.Next(1, 12);
            var randomNum2 = random.Next(1, 12);
            char correctSymbol;

            if (randomNum1 == randomNum2) correctSymbol = '=';
            else if (randomNum1 > randomNum2) correctSymbol = '>';
            else correctSymbol = '<';

            Console.WriteLine(randomNum1 + "_" + randomNum2);
            var selectedSymbol = Console.ReadLine();

            if (selectedSymbol == null || selectedSymbol.Length != 1)
            {
                Console.WriteLine("You must enter only 1 character.\nPress any key to continue...");
                Console.ReadKey(true);
                return;
            }

            char[] symbols = { '>', '<', '=' };
            if (selectedSymbol.IndexOfAny(symbols) == -1) //finn indeksen til selectedSymbol i symbols arrayet. -1 er default verdi
            {
                Console.WriteLine("The only allowed symbols are: '>', '<' and '='\nPress any key to continue...");
                Console.ReadKey(true);
                return;
            }

            if (selectedSymbol == correctSymbol.ToString()) _points++;
            else _points--;

            if (_points >= 10) _gameRunning = false;
        }
    }
}
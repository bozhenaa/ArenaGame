using ArenaGame;

namespace ConsoleGame
{
    internal class Program
    {
        public static Hero ChooseHero()
        {
            Console.WriteLine("Wellcome to the arena! \n " +
               "\nCharacters: \n" +
               "1. Rogue \n2. Knight \n3. Elf \n4. The Magician \n");
            int heroNumber = 0;
            while (heroNumber < 1 || heroNumber > 4)
            {
                Console.Write("Choose your character: ");
                heroNumber = Int32.Parse(Console.ReadLine());
            }
            Console.Write("Choose the name for your hero:");
            string heroName =  Console.ReadLine();
            switch (heroNumber) 
            {
                case 1:
                    return new Rogue(heroName);
                    break;
                case 2:
                    return new Knight(heroName);
                    break;
                case 3:
                    return new Elf(heroName);
                case 4:
                    return new Magician(heroName);
                    break;
                default:
                    return null;
            }
        }

        public static Weapon ChooseWeapon(int weaponNumber)
        {
            while (weaponNumber > 3 || weaponNumber < 0)
            {
                Console.WriteLine("Choose your desired weapon: ");
                weaponNumber = int.Parse(Console.ReadLine());
            }
            switch (weaponNumber)
            {
                case 0:
                    return null;
                case 1:
                    return new Bow();
                    break;
                case 2:
                    return new Sword();
                    break;
                case 3:
                    return new Dagger();
                default:
                    return null;
            }
        }
        public static Hero RandomOpponent()
        {
            Random random = new Random();
            Hero[] opponents = {
                new Elf("Legolas"),
                new Magician("Merlin"),
                new Rogue("Robin Hood"),
                new Knight("Sir Lancelot")
            };
            //creating an opponent, who can be the same character as your own
            Hero opponent;
            opponent = opponents[random.Next(opponents.Length)];
            return opponent;
        }
        static void Main(string[] args)
        {
            //defining your own hero
            Hero one = ChooseHero();
            Console.WriteLine();
            Console.WriteLine($"Your hero is: {one.GetType().Name} - {one.Name}\n");
            Console.WriteLine("Searching for an opponent...");

            //creating the opponent 
            Hero two = RandomOpponent();
            Console.WriteLine($"Opponent found! \nYour opponent will be {two.GetType().Name} - {two.Name} \n");
            Random rand = new Random();
            int opponentWeapon = rand.Next(4);
            two.Weapon = ChooseWeapon(opponentWeapon);
            Console.WriteLine(two.Weapon != null ? $"Your opponent weapon is: {two.Weapon.GetType().Name} \n" : 
                "Your opponent choose no weapon. \n");


            //choosing my weapon
            Console.Write("Weapons: \n" +
               "0. None \n1. Bow \n2. Sword \n3. Dagger \n");
            int myWeapon = int.Parse(Console.ReadLine());
            one.Weapon = ChooseWeapon(myWeapon);
            if (one.Weapon != null)
            {
                Console.WriteLine($"Your weapon is: {one.Weapon.GetType().Name} \n");
            }
            else
            {
                Console.WriteLine("You choose no weapon. We respect your decision, brave worrior! \n"); 
            }

            //defining number of battles
            Console.Write("Enter number of battles: ");
            int rounds = Int32.Parse(Console.ReadLine());
            int oneWins = 0, twoWins = 0;
            string oneName = one.Name;
            string twoName = two.Name;

            //start of each round
            for (int i = 0; i < rounds; i++)
            {
                Console.WriteLine($"Arena fight between: {one.Name} and {two.Name}");
                Arena arena = new Arena(one, two);
                Hero winner = arena.Battle();
                Console.WriteLine($"Winner is: {winner.Name}");
                if (winner == one) oneWins++; else twoWins++;
            }
            Console.WriteLine();

            //calculating the winrate
            double winrateOne = ((double)oneWins / rounds) * 100.0;

            Console.WriteLine($"{oneName} has {oneWins} wins.");
            Console.WriteLine($"{twoName} has {twoWins} wins.");
            Console.WriteLine();
            if (winrateOne > 50)
            {
                Console.WriteLine($"You won the game with {(int)winrateOne}% WR");
            }
            else
            {
                Console.WriteLine($"You lost the game with {(int)winrateOne}% WR");
            }
            Console.ReadLine();
        }
    }
}

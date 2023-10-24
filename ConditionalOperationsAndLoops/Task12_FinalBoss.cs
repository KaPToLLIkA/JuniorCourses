using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperationsAndLoops_Task12
{
    internal class FinalBoss
    {
        public static void Main(string[] args)
        {
            const string FireBallCommand = "1";
            const string FireStormCommand = "2";
            const string WaterBallCommand = "3";
            const string WaterStormCommand = "4";

            Random random = new Random();

            float playerManaPoints = 0;
            float playerHealthPoints = 100;

            float manaPointsIncrement = 15;

            float playerFireBallDamage = 10;
            float playerFireStormDamage = 20;
            float playerWaterBallDamage = 10;
            float playerWaterStormDamage = 20;

            float playerFireBallMPCost = 10;
            float playerFireStormMPCost = 20;
            float playerWaterBallMPCost = 10;
            float playerWaterStormMPCost = 20;

            float elementsReactionMultiplier = 1.5f;

            bool isLastAttackFireElement = false;
            bool isLastAttackWaterElement = false;

            float bossHealthPoints = 100;

            int bossMinDamage = 15;
            int bossMaxDamage = 25;
            float bossDamageOnInputError = 10;

            bool isGameRunning = true;

            Console.WriteLine("!!!BOSS FIGHT!!!");

            while (isGameRunning)
            {
                playerManaPoints += manaPointsIncrement;

                Console.WriteLine(
                    $"Get ready, it's your turn now...\n\n" +
                    $"HP: {playerHealthPoints}\n" +
                    $"MP: {playerManaPoints}\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"BOSS HP: {bossHealthPoints}\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(
                    "Select attack type (print index):\n" +
                    $"{FireBallCommand} \"FireBall\" (DMG:{playerFireBallDamage}; MP:{playerFireBallMPCost})\n" +
                    $"{FireStormCommand} \"FireStorm\" (DMG:{playerFireStormDamage}; MP:{playerFireStormMPCost})\n" +
                    $"{WaterBallCommand} \"WaterBall\" (DMG:{playerWaterBallDamage}; MP:{playerWaterBallMPCost})\n" +
                    $"{WaterStormCommand} \"WaterStorm\" (DMG:{playerWaterStormDamage}; MP:{playerWaterStormMPCost})\n\n");

                string attackInput = Console.ReadLine();

                switch (attackInput)
                {
                    case FireBallCommand:
                        if (playerFireBallMPCost <= playerManaPoints)
                        {
                            isLastAttackFireElement = true;

                            playerManaPoints -= playerFireBallMPCost;

                            float damage = playerFireBallDamage;

                            if (isLastAttackWaterElement)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    "The effect of increasing damage " +
                                    "due to the combination of elements has worked!");
                                Console.ForegroundColor = ConsoleColor.White;

                                damage *= elementsReactionMultiplier;
                                isLastAttackWaterElement = false;
                            }

                            Console.WriteLine(
                                $"Your fireball hits the boss and deals him {damage} points of damage!");

                            bossHealthPoints -= damage;
                        } 
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not enough MP. Your fireball has gone out...");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case FireStormCommand:
                        if (playerFireStormMPCost <= playerManaPoints)
                        {
                            isLastAttackFireElement = true;

                            playerManaPoints -= playerFireStormMPCost;

                            float damage = playerFireStormDamage;

                            if (isLastAttackWaterElement)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    "The effect of increasing damage " +
                                    "due to the combination of elements has worked!");
                                Console.ForegroundColor = ConsoleColor.White;

                                damage *= elementsReactionMultiplier;
                                isLastAttackWaterElement = false;
                            }

                            Console.WriteLine(
                                $"Your firestorm hits the boss and deals him {damage} points of damage!");

                            bossHealthPoints -= damage;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not enough MP. Your firestorm has subsided...");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case WaterBallCommand:
                        if (playerWaterBallMPCost <= playerManaPoints)
                        {
                            isLastAttackWaterElement = true;

                            playerManaPoints -= playerWaterBallMPCost;

                            float damage = playerWaterBallDamage;

                            if (isLastAttackFireElement)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    "The effect of increasing damage " +
                                    "due to the combination of elements has worked!");
                                Console.ForegroundColor = ConsoleColor.White;

                                damage *= elementsReactionMultiplier;
                                isLastAttackFireElement = false;
                            }

                            Console.WriteLine(
                                $"Your waterball hits the boss and deals him {damage} points of damage!");

                            bossHealthPoints -= damage;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not enough MP. Your waterball has gone out...");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case WaterStormCommand:
                        if (playerWaterStormMPCost <= playerManaPoints)
                        {
                            isLastAttackWaterElement = true;

                            playerManaPoints -= playerWaterStormMPCost;

                            float damage = playerFireStormDamage;

                            if (isLastAttackFireElement)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(
                                    "The effect of increasing damage " +
                                    "due to the combination of elements has worked!");
                                Console.ForegroundColor = ConsoleColor.White;

                                damage *= elementsReactionMultiplier;
                                isLastAttackFireElement = false;
                            }

                            Console.WriteLine(
                                $"Your waterstord hits the boss and deals him {damage} points of damage!");

                            bossHealthPoints -= damage;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Not enough MP. Your waterstorm has subsided...");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(
                            "You missed the button and angered the boss.\n" +
                            $"It deals you an additional {bossDamageOnInputError} points of damage.\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        playerHealthPoints -= bossDamageOnInputError;

                        break;
                }

                if (bossHealthPoints <= 0)
                {
                    isGameRunning = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You've defeated the boss!");
                    Console.ForegroundColor = ConsoleColor.White;
                } 
                else
                {
                    float damage = random.Next(bossMinDamage, bossMaxDamage);

                    playerHealthPoints -= damage;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The boss attacks and deals you {damage} units of damage!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (playerHealthPoints <= 0)
                {
                    isGameRunning = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("HP: 0. You are lost...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}

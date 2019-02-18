using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {

        public class Fighter
        {
            public string Name { get; private set; }
            public int Health { get; set; } // жизнь
            public int DamagePerAttack { get; private set; } // сила удара, урон

            public Fighter(string name, int health, int damage)
            {
                this.Name = name;
                this.Health = health;
                this.DamagePerAttack = damage;
            }
        }


        // Написать метод, который определяет победителя схватки двух бойцов.​

        // Схватка происходит следующим образом: случайным образом определяется
        // первый нападающий, после чего он наносит удар.Далее бойца наносят удары по очереди.​

        //В результате удара у бойца отнимается столько жизней, какой силой удара обладает нападающий.​
        //Проигравшим считается тот, у кого уровень жизней меньше или равно 0.​




        public static class Battle
        {
            public static int Strike(Fighter fighter1, Fighter fighter2) // нанести удар
            {
                // В результате удара у бойца отнимается столько жизней,
                // какой силой удара обладает нападающий
                return fighter1.Health -= fighter2.DamagePerAttack;
            }

            //Получить очередное (в данном случае - первое) случайное число
            //int value = rnd.Next();


            public static Fighter BattleF(Fighter fighter1, Fighter fighter2)
            {
                // рандомно выбрать нападающего
                Random rnd = new Random();
                int value = rnd.Next(0, 2);
                // через тики

                int tick = 0;

                if (value == 0)
                {
                    do
                    {
                        if (tick == 0)
                        {
                            Strike(fighter1, fighter2);
                            tick++;
                        }
                        else
                        {
                            Strike(fighter2, fighter1);
                            tick++;
                        }

                    } while (fighter1.Health > 0 && fighter2.Health > 0);
                }
                else
                {
                    do
                    {
                        if (tick == 0)
                        {
                            Strike(fighter1, fighter2);
                            tick++;
                        }
                        else
                        {
                            Strike(fighter2, fighter1);
                            tick++;
                        }
                    } while (fighter1.Health > 0 && fighter2.Health > 0);
                }
                

                if (fighter1.Health > 0)
                {
                    return fighter2; // победитель
                }
                else
                    return fighter1;
            }
        }
        



        static void Main(string[] args)
        {
            var fighter1 = new Fighter("fighter1", 10, 2);
            var fighter2 = new Fighter("fighter2", 10, 5);

            //var battle = new Battle();

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine((Battle.BattleF(fighter1, fighter2)).Name);
            }
            

            Console.WriteLine();
        }
    }
}

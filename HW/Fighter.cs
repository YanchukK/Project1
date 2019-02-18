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
            
            // В результате удара у бойца отнимается столько жизней,
            // какой силой удара обладает нападающий
            public int Strike(Fighter fighter1, Fighter fighter2) // нанести удар
            {
                return fighter1.Health -= fighter2.DamagePerAttack;
            }


            Random rnd = new Random();

            //Получить очередное (в данном случае - первое) случайное число
            //int value = rnd.Next();
            

            public Fighter Battle(Fighter fighter1, Fighter fighter2)
            {
                // рандомно выбрать нападающего
                int value = rnd.Next(0, 2);
                // через тики
                
                if (value == 0)
                {
                    do
                    {
                        Strike(fighter1, fighter2);
                    } while (fighter1.Health > 0 && fighter2.Health > 0);
                }
                else
                {
                    do
                    {
                        Strike(fighter1, fighter2);
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
        
        // Написать метод, который определяет победителя схватки двух бойцов.​

        // Схватка происходит следующим образом: случайным образом определяется
        // первый нападающий, после чего он наносит удар. Далее бойца наносят удары по очереди.​

        //В результате удара у бойца отнимается столько жизней, какой силой удара обладает нападающий.​
        //Проигравшим считается тот, у кого уровень жизней меньше или равно 0.​





        static void Main(string[] args)
        {
            //Создание объекта для генерации чисел
            Random rnd = new Random();

            //Получить очередное (в данном случае - первое) случайное число
            //int value = rnd.Next();
            int value = rnd.Next(0, 2);
            //Вывод полученного числа в консоль
            Console.WriteLine(value);

            //Console.WriteLine();
        }
    }
}

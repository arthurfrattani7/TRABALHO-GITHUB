using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRABALHO_GITHUB
{
    internal class Partida
    {
        public Competidores Competidor1 { get; private set; }
        public Competidores Competidor2 { get; private set; }
        public Competidores CompetidorWinner { get; private set; } // Vai ficar 'null' se for empate

        // Um objeto Random 'static' para garantir aleatoriedade real
        private static Random random = new Random();

        public Partida(Competidores Comp1, Competidores Comp2)
        {
            this.Competidor1 = Comp1;
            this.Competidor2 = Comp2;
            this.CompetidorWinner = null;
        }
        public void Simular()
        {
            Console.WriteLine("A luta está começando...");
            

            int roll1 = random.Next(1, 7); // Rola um "dado" de 6 lados
            int roll2 = random.Next(1, 7); // Rola outro "dado"

            Console.WriteLine($"{Competidor1.Nome} tirou... {roll1}!");
            Console.WriteLine("");
            Console.WriteLine($"{Competidor2.Nome} tirou... {roll2}!");
         

            // Define o vencedor da partida
            if (roll1 > roll2)
            {
                this.CompetidorWinner = Competidor1;
            }
            else if (roll2 > roll1)
            {
                this.CompetidorWinner = Competidor2;
            }
            // Se for empate, this.CompetidorWinner continua 'null'
        }
    }
}


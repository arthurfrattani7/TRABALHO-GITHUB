using System;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
using TRABALHO_GITHUB;

namespace Trabalho
{
    class POO
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 🎰 BEM-VINDO AO JOGO DE APOSTAS! 🎰 ---");
            Console.Write("Por favor, digite o seu nome: ");
            string Nome_Jogador = Console.ReadLine();

            Console.Write("Quanto você deseja colocar na sua carteira ? ");
            double carteira_inicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Jogador jogador = new Jogador(Nome_Jogador, carteira_inicial);
            Console.WriteLine("Olá " + jogador.nome + " Sua carteira começa com R$ " + jogador.Carteira);

            while (jogador.Carteira > 0)
            {
                Console.WriteLine($"Seu saldo atual: R${jogador.Carteira}");

                Console.Write("Quer fazer uma nova aposta? (s/n): ");
                string choice = Console.ReadLine().Trim().ToLower(); // Isso é que se usar letra maiuscula vai virar minuscula 

                if (choice == "n")
                {
                    break; // Sai do loop do jogo
                }

                // Inicia uma nova rodada
                Rodando_A_BET(jogador);
            }

            // Fim de jogo
            Console.WriteLine("\n--- FIM DE JOGO ---");
            if (jogador.Carteira <= 0)
            {
                Console.WriteLine("Que pena, você perdeu todo o seu dinheiro! 😥");
            }
            else
            {
                Console.WriteLine($"Você saiu com R${jogador.Carteira:F2}. Obrigado por jogar!");
            }
        }
        public static void Rodando_A_BET(Jogador jogador)
        {
            double betAmount = GetBetAmount(jogador);

            Competidores comp1 = GetRandomCompetitor();
            Competidores comp2 = GetRandomCompetitor();

            while (comp1.Nome == comp2.Nome)
            {
                comp2 = GetRandomCompetitor();
            }

            Console.WriteLine("--- PRÓXIMA LUTA ---");
            Console.WriteLine($"[1] {comp1.Nome}");
            Console.WriteLine($"[2] {comp2.Nome}");
            Console.Write("Em quem você aposta (1 ou 2)? ");

            int playerChoice = GetNumericChoice(1, 2);
            Competidores EscolherCompetidor = (playerChoice == 1) ? comp1 : comp2;

            Console.WriteLine($"Você apostou R${betAmount:F2} em {EscolherCompetidor.Nome}!");

            // --- 2. Execução da Partida (A GRANDE MUDANÇA) ---

            // Criamos o objeto da partida
            Partida Partidaatual = new Partida(comp1, comp2);

            // Mandamos ele simular a luta
            Partidaatual.Simular();

            // --- 3. Processamento do Resultado ---
            // A lógica agora é só checar o resultado que A "Patida Atual" nos deu.

            if (Partidaatual.CompetidorWinner == null)
            {
                Console.WriteLine("Resultado: EMPATE! Ninguém venceu. Sua aposta foi devolvida.");
            }
            else if (Partidaatual.CompetidorWinner.Nome == EscolherCompetidor.Nome)
            {
                Console.WriteLine($"Resultado: PARABÉNS! {Partidaatual.CompetidorWinner.Nome} venceu! Você ganhou R${betAmount:F2}.");
                jogador.Atualizar_Carteira(betAmount); // Adiciona o valor
            }
            else
            {
                Console.WriteLine($"Resultado: QUE PENA! {Partidaatual.CompetidorWinner.Nome} venceu! Você perdeu R${betAmount:F2}.");
                jogador.Atualizar_Carteira(-betAmount); // Remove o valor
            }
        }


        private static Random randomGen = new Random();

        public static int GetNumericChoice(int min, int max)
        {
            int Escolha;
            while (!int.TryParse(Console.ReadLine(), out Escolha) || Escolha < min || Escolha > max)
            {
                Console.Write($"Escolha inválida. Digite um número entre {min} e {max}: ");
            }
            return Escolha; 
        }

        public static Competidores GetRandomCompetitor()
        {
            List<string> names = new List<string>
            {
                "Dragão Vermelho", "Lobo Cinzento", "Tubarão de Aço",
                "Águia Dourada", "Urso Pardo", "Tigre de Fogo"
            };
            int index = randomGen.Next(names.Count);
            return new Competidores(names[index]);
        }

        public static double GetBetAmount(Jogador jogador) // Comecei a usar inglês, pois estava ficando sem ideia. 
        {
            double betAmount;
            Console.Write("Quanto você quer apostar? ");
            while (!double.TryParse(Console.ReadLine(), out betAmount) || betAmount <= 0 || !jogador.Valor_Da_Bet(betAmount))
            {
                if (betAmount <= 0)
                {
                    Console.Write("Valor inválido. Digite um número positivo: ");
                }
                else if (!jogador.Valor_Da_Bet(betAmount))
                {
                    Console.Write($"Saldo insuficiente (Você tem R${jogador.Carteira:F2}). Digite um valor menor: ");
                }
            }
            return betAmount;
        }



    }
}




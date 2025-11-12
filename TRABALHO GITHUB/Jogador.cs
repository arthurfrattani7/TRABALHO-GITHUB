using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRABALHO_GITHUB
{
    internal class Jogador
    {
        public string nome {  get; private set; }
        public double Carteira { get; private set; }


        // Aqui é um construtor para criar um jogador, por isso podemos usar o mesmo nome da classe e não precisamos de um método como: Void, Int, ETC..
        public Jogador(string nome, double inicial_carteira)
        {
            this.nome = nome;
            this.Carteira = inicial_carteira;
        }

        public void Atualizar_Carteira(double Ganhos) // Aqui usamos o void, pois não precisamos retornar nada, apenas modificar a carteira.
        {
            Carteira += Ganhos; // Carteira = Ganhos + Carteira. 
        }

        public bool Valor_Da_Bet(double Valor_Bet) // essa é apenas uma função para verificar se o apostador pode ou não fazer aquela bet. 
        {
            return Carteira >= Valor_Bet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TRABALHO_GITHUB
{
    internal class Competidores
    {
        public string Nome {  get; private set; }

        public Competidores(string nome) 
        { 
            this.Nome = nome;
        }
    }
}

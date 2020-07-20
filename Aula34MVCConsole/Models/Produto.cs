using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula34MVCConsole.Models
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        private const string PATH = "Database/produto.csv";
        public Produto()
        {   
            string pasta = PATH.Split('/')[0];
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            // Cria o arquivo caso não exista
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        public List<Produto> Ler()
        {
            // Criamos uma lista para guardar o retorno
            List<Produto> prod = new List<Produto>();

            // Lemos o .csv e separamos em um array de linhas
            string[] linhas = File.ReadAllLines(PATH);

            // Varremos nossas linhas
            foreach(string linha in linhas)
            {
                
                string[] dado = linha.Split(";");

               

                Produto p   = new Produto();
                p.Codigo    = Int32.Parse( Separar(dado[0]) );
                p.Nome      = Separar(dado[1]);
                p.Preco     = float.Parse( Separar(dado[2]) );

                prod.Add(p);
            }
            return prod;
        }
        public string Separar(string dado)
        {
            return dado.Split("=")[1];
        }
    }
}


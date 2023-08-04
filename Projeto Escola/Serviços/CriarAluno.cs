using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Escola.Diretoria
{
    public class CriarAluno
    {
        public void CriarAlunos()
        {
            Console.Clear();
            Console.Write("Digite a quantidade de alunos que deseja criar (1 - 10): ");
            int quantidadeAlunos = Utils.ReadInt("");

            while (quantidadeAlunos > 10 | quantidadeAlunos < 1)
            {

                Utils.WriteLineColored(" Digite apenas numeros entre 1 a 10! !", ConsoleColor.Red);

                quantidadeAlunos = Utils.ReadInt("");
            }



            for (int i = 0; i < quantidadeAlunos; i++)
            {
                Console.Write("Digite o nome do aluno: ");
                string nome = (Console.ReadLine());

                bool digitouErrado = double.TryParse(nome, out double verificado);

                while (digitouErrado)
                {

                    Utils.WriteLineColored(" Digite apenas letras !", ConsoleColor.Red);
                    nome = (Console.ReadLine());
                    digitouErrado = double.TryParse(Console.ReadLine(), out verificado);

                }

                Console.Write("Digite a data de nascimento do aluno (dd / MM  / yyyy): ");
                DateTime dataNascimento = Utils.ReadDateTime("");

                //try prse Exact.

                int serieOpcao;
                string serie =string.Empty;

                Console.WriteLine("Escolha a série do aluno: ");
                Console.WriteLine("1 - 1ºA  |  4 - 2°A         ");
                Console.WriteLine("2 - 1ºB  |  5 - 2ºB         ");
                Console.WriteLine("3 - 1ºC  |  6 - 2ºC         ");

                Console.Write("Digite a opção (1-6): ");
                serieOpcao = Utils.ReadInt("");

                while (serieOpcao < 1 || serieOpcao > 6)
                {
                    Utils.WriteLineColored("Opção inválida. Digite numeros apenas entre (1 - 6).", ConsoleColor.Red);
                    serieOpcao = Utils.ReadInt("");
                }
                    switch (serieOpcao)
                    {
                        case 1:
                            serie = "1ºA";
                            break;
                        case 2:
                            serie = "1ºB";
                            break;
                        case 3:
                            serie = "1ºC";
                            break;
                        case 4:
                            serie = "2ºA";
                            break;
                        case 5:
                            serie = "2ºB";
                            break;
                        case 6:
                            serie = "2ºC";
                            break;
                        
                    
                }
                
                // Gerar RA aleatório
                Random random = new Random();
                int ra = random.Next(1000, 10000);


                Listas.ListaAluno.Add(new Aluno(nome, dataNascimento, serie, ra));
                foreach (Aluno obj in Listas.ListaAluno)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}

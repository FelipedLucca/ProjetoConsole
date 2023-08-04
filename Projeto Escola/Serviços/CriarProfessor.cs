using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Escola.Diretoria
{
    public class CriarProfessor
    {
        public void CriarProfessores()
        {

            Console.Clear();
            Console.WriteLine("Digite a quantidade de professores que deseja criar (1 - 10): ");
            int quantidadeProfessores = Utils.ReadInt("");

            while (quantidadeProfessores > 10 | quantidadeProfessores < 1)
            {

                Utils.WriteLineColored(" Digite apenas numeros entre 1 a 10! !", ConsoleColor.Red);

                quantidadeProfessores = Utils.ReadInt("");
            }


            for (int i = 0; i < quantidadeProfessores; i++)
            {

                Console.WriteLine("Digite o nome do Professor: ");
                string nome = (Console.ReadLine());
                bool digitouErrado = double.TryParse(nome, out double verificado);

                while (digitouErrado)
                {


                    Utils.WriteLineColored(" Digite apenas letras !", ConsoleColor.Red);
                    nome = (Console.ReadLine());
                    digitouErrado = double.TryParse(nome, out verificado);



                }

                Console.Write("Digite a data de nascimento do professor (dd / MM / yyyy): ");
                DateTime dataNascimento = Utils.ReadDateTime("");


                int materiaOpcao;
                string materia;

                Console.WriteLine("Escolha a matéria que o professor:");
                Console.WriteLine("1 - História");
                Console.WriteLine("2 - Português");
                Console.WriteLine("3 - Inglês");
                Console.Write("Digite a opção (1-3): ");
                materiaOpcao = Utils.ReadInt("");


                while (materiaOpcao < 1 || materiaOpcao > 3)
                {
                    Utils.WriteLineColored("Opção inválida. Digite numeros apenas entre (1 - 3).", ConsoleColor.Red);
                    materiaOpcao = Utils.ReadInt("");
                }

                switch (materiaOpcao)
                    {
                        case 1:
                            materia = "História";
                            break;
                        case 2:
                            materia = "Português";
                            break;
                        case 3:
                            materia = "Inglês";
                            break;
                        default:
                            materia = "";
                            break;
                    }

                string classe = string.Empty;
                int classeOpcao;

                Console.WriteLine("Escolha a série que o professor vai dar aulas:");
                Console.WriteLine("1 - 1ºA  |  4 - 2°A         ");
                Console.WriteLine("2 - 1ºB  |  5 - 2ºB         ");
                Console.WriteLine("3 - 1ºC  |  6 - 2ºC         ");
                Console.Write("Digite a opção (1 - 6):         ");
                classeOpcao = Utils.ReadInt("");

                while (classeOpcao < 1 || classeOpcao > 6)
                {
                    Utils.WriteLineColored("Opção inválida. Digite numeros apenas entre (1 - 6).", ConsoleColor.Red);
                    classeOpcao = Utils.ReadInt("");
                }

                switch (classeOpcao)
                    {
                        case 1:
                            classe = "1ºA";
                            break;
                        case 2:
                            classe = "1ºB";
                            break;
                        case 3:
                            classe = "1ºC";
                            break;
                        case 4:
                            classe = "2ºA";
                            break;
                        case 5:
                            classe = "2ºB";
                            break;
                        case 6:
                            classe = "2ºC";
                            break;
                    }

                


                Random random = new Random();
                int id = random.Next(10, 100);

                Listas.ListaProfessor.Add(new Professor(nome, dataNascimento, materia, classe, id));

                foreach (Professor obj in Listas.ListaProfessor)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}

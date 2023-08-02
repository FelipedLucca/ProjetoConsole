using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using System;
using System.Collections.Generic;
using System.Linq;

public class Menu
{





    private List<Aluno> alunos = new List<Aluno>();
    public void ExibirMenu()
    {

        
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("       MENU PRINCIPAL      ");
            Console.WriteLine("---------------------------");
            Console.WriteLine("   1 - ALUNOS"              );
            Console.WriteLine("   2 - PROFESSORES"         );
            Console.WriteLine("   3 - SAIR"                );
            Console.WriteLine("---------------------------");
            Console.Write("   Escolha uma opção (1-3): ");
            opcao = Utils.ReadInt("");

            switch (opcao)
            {
                case 1:
                    ExibirMenuAlunos();
                    break;
                case 2:
                    ExibirMenuProfessores();
                    break;
                case 3:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Utils.WriteLineColored("Opção inválida. Tente novamente.", ConsoleColor.Red);

                    break;
            }
        } while (opcao > 3 || opcao < 1);
    }

    private void ExibirMenuAlunos()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("      MENU ALUNOS      "    );
            Console.WriteLine("---------------------------");
            Console.WriteLine("   1 - CRIAR ALUNOS");
            Console.WriteLine("   2 - VER LISTA DE ALUNOS ");
            Console.WriteLine("   3 - VOLTAR"              );
            Console.WriteLine("---------------------------");
            Console.WriteLine("   Escolha uma opção (1-3):");
            Console.WriteLine("---------------------------");
            opcao = Utils.ReadInt("");
            switch (opcao)
            {
                case 1:
                    CriarAlunos();
                    break;
                case 2:
                    VerListaAlunos();
                    break;
                case 3:
                    ExibirMenu();
                    break;
                default:
                    Utils.WriteLineColored("Opção inválida. Tente novamente.", ConsoleColor.Red);
                    Console.ReadLine();
                    break;
            }
        } while (opcao > 3 || opcao < 1 || opcao !=3);
        Console.ReadLine();
    }
    



    private void CriarAlunos()
    {
        Console.Clear();
        Console.Write("Digite a quantidade de alunos que deseja criar: ");
        int quantidadeAlunos = Utils.ReadInt("");

        for (int i = 0; i < quantidadeAlunos; i++)
        {
            Console.Write("Digite o nome do aluno: ");
            string nome = (Console.ReadLine());

            bool digitouErrado = double.TryParse(nome, out double verificado);

            while (digitouErrado) 
            {
                Console.WriteLine("----------------------------------------------");
                Utils.WriteLineColored(" Digite apenas letras !", ConsoleColor.Red);
                Utils.WriteLineColored(" Digite novamente o nome do Aluno: !", ConsoleColor.Blue);
                Console.WriteLine("----------------------------------------------");
                nome = (Console.ReadLine());
                digitouErrado = double.TryParse(Console.ReadLine(), out verificado);

            }

            Console.Write("Digite a data de nascimento do aluno (ddMMyyyy): ");
            DateTime dataNascimento = Utils.ReadDateTime("");

            //try prse Exact.

            int serieOpcao;
            string serie;
           
                Console.WriteLine("Escolha a série do aluno:");
                Console.WriteLine("1 - 1ºA");
                Console.WriteLine("2 - 1ºB");
                Console.WriteLine("3 - 1ºC");
                Console.Write("Digite a opção (1-3): ");              
                serieOpcao = Utils.ReadInt("");


                do
                {
                    switch (serieOpcao)                                                            
                                                                                               
                {
                    case 1:
                        serie = "1ºA";
                        break;
                    case 2:
                        serie = "1ºB";
                        break;
                    case 3:
                        serie = "ºC";
                        break;
                    default:
                        Utils.WriteLineColored("Opção inválida. Digite novamente.", ConsoleColor.Red);
                        serieOpcao = Utils.ReadInt("");
                        serie = "";
                        break;
                }
                 } while (serieOpcao < 1 || serieOpcao > 3);

            // Gerar RA aleatório
            Random random = new Random();
            int ra = random.Next(1000, 10000);

            Aluno aluno = new Aluno(nome, dataNascimento, 'M', serie, ra);
            alunos.Add(aluno);
            Console.WriteLine($"Aluno criado: {aluno}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private void VerListaAlunos()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                         LISTA DE ALUNOS          ");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

        var alunosOrdenados = alunos.OrderBy(a => a.Nome).ToList();
        if (alunos.Count == 0)
        {
            Utils.WriteLineColored("                                    NENHUM ALUNO REGISTRADO                              ", ConsoleColor.Red);

            
        }
        else
        {
            var alunosArrumados = alunos.OrderBy(a => a.Nome).ToList();
            foreach (var aluno in alunosArrumados)
            {
                Console.WriteLine(aluno);
            }
        }


        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                               Pressione qualquer tecla para voltar...");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

        Console.ReadKey();
    }

    private void ExibirMenuProfessores()
    {


       
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("      MENU PROFESSORES     ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("  1 - CRIAR PROFESSOR");
            Console.WriteLine("  2 - CONSULTAR PROFESSOR");
            Console.WriteLine("  3 - BOLETIM, CONSULTAR NOTA");
            Console.WriteLine("  4 - ATRIBUIÇÃO DE NOTA");
            Console.WriteLine("  5 - VOLTAR");
            Console.WriteLine("------------------------------");
            Console.WriteLine("    Escolha uma opção (1-5):  " );
            Console.WriteLine("------------------------------");
            opcao = Utils.ReadInt("");

            switch (opcao)
            {
                case 1:
                    CriarProfessores();
                    break;
                case 2:
                    ConsultarProfessores();
                    break;
                case 3:
                    BoletimConsultarNota();
                    break;
                case 4:
                    AtribuicaoDeNota();
                    break;
                case 5:
                    ExibirMenu();
                    break;
                default:
                    Utils.WriteLineColored("Opção inválida. Tente novamente.", ConsoleColor.Red);
                    break;
            }
        } while (opcao != 5);
    }
    private void AtribuicaoDeNota()
    {
        Console.Clear();
        Console.WriteLine("------------------------------");
        Console.WriteLine("      ATRIBUIÇÃO DE NOTA      ");
        Console.WriteLine("------------------------------");

        int professorId;
        do
        {
            Console.Write("Digite o ID do professor para atribuir as notas (somente números, duas casas decimais): ");
        } while (!int.TryParse(Console.ReadLine(), out professorId));

        Professor professor = professores.Find(p => p.ID == professorId);

        if (professor == null)
        {
            Console.WriteLine("Professor não encontrado. Verifique o ID digitado.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Professores...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine     ("+-----------------------------------------------------------------------------------------------------+");
        Console.WriteLine(   $" | {professor.Nome} | ID: {professor.ID:D2} | Matéria: {professor.Materia} | Série {professor.Classe}  |");
        Console.WriteLine     ("+-----------------------------------------------------------------------------------------------------+");

        int ra;
        do
        {
            Console.Write("Digite o RA do aluno para atribuir as notas (somente números, quatro casas decimais): ");
        } while (!int.TryParse(Console.ReadLine(), out ra));

        Aluno aluno = alunos.Find(a => a.RA == ra);
        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado. Verifique o RA digitado.");
        }
        else if (aluno.Serie != professor.Classe)
        {
            Console.WriteLine("Este aluno não pertence à turma do professor. Não é possível atribuir notas.");
        }
        else
        {
            Console.WriteLine($"Atribuindo notas para o aluno - RA: {ra:D4} - Turma: {aluno.Serie}");

            double[] notas = new double[4];
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.Write($"Digite a nota {i + 1} (de 0 a 10): ");  //anotação
                } while (!double.TryParse(Console.ReadLine(), out notas[i]) || notas[i] < 0 || notas[i] > 10);
            }

            double media = notas.Average();
            string situacao = media >= 7 ? "APROVADO" : "REPROVADO";

            Console.WriteLine($"Notas atribuídas com sucesso! Média: {media:F2}, Situação: {situacao}, Matéria: {professor.Materia}");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Professores...");
        Console.ReadKey();
    }

    private void CriarProfessores()
    {

        

        Console.Clear();
        Console.Write("Digite a quantidade de professores que deseja criar: ");         
        int quantidadeProfessores = Utils.ReadInt("");




        for (int i = 0; i < quantidadeProfessores; i++)
        {
            Console.Write("Digite o nome do Professor: ");
            string nome = (Console.ReadLine());

            bool digitouErrado = double.TryParse(nome, out double verificado);

            while (digitouErrado)
            {

                Console.WriteLine("----------------------------------------------");
                Utils.WriteLineColored(" Digite apenas letras !", ConsoleColor.Red);
                Utils.WriteLineColored("Digite novamente o nome do Professor: !", ConsoleColor.Blue);
                Console.WriteLine("----------------------------------------------");
                nome = (Console.ReadLine());
                digitouErrado = double.TryParse(nome, out verificado);

               
                
            }
            
            Console.Write("Digite a data de nascimento do professor (ddMMyyyy): ");
            DateTime dataNascimento = Utils.ReadDateTime("");


            int materiaOpcao;
            string materia;
            
                Console.WriteLine("Escolha a matéria que o professor:");
                Console.WriteLine("1 - História");
                Console.WriteLine("2 - Português");
                Console.WriteLine("3 - Inglês");
                Console.Write("Digite a opção (1-3): ");
                 materiaOpcao = Utils.ReadInt("");
                do
                {
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
                        Utils.WriteLineColored("Opção inválida. Digite apenas numeros entre (1 - 3)", ConsoleColor.Red);
                        materiaOpcao = Utils.ReadInt("");
                        materia = "";
                        break;
                }
            }while(materiaOpcao > 3 || materiaOpcao <1);



        string classe;
            int classeOpcao;
            
                Console.WriteLine("Escolha a série que o professor vai dar aulas:");
                Console.WriteLine("1 - 1ºA");
                Console.WriteLine("2 - 1ºB");
                Console.WriteLine("3 - 1ºC");
                Console.Write("Digite a opção (1-3): ");
                 classeOpcao = Utils.ReadInt("");
            do
            {
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
                    default:
                        Utils.WriteLineColored("Opção inválida. Digite numeros entre (1 - 3).", ConsoleColor.Red);
                        classeOpcao = Utils.ReadInt("");
                        classe = "";
                        break;

                }

            } while (classeOpcao < 1 || classeOpcao > 2);


            Random random = new Random();
            int id = random.Next(10, 100);

            Professor professor = new Professor(nome, dataNascimento, 'M', materia, classe, id);
            professores.Add(professor);
            Console.WriteLine($"Professor criado: {professor}");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }


    private List<Professor> professores = new List<Professor>();
    private void ConsultarProfessores()
    {

        Console.Clear();
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                         LISTA DE PROFESSORES           ");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        var professoresOrdenados = professores.OrderBy(p => p.Nome).ToList();
        foreach (var professor in professoresOrdenados)
        {
            Console.WriteLine(professor);
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                               Pressione qualquer tecla para voltar...");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        Console.ReadKey();
    }

    private Boletim ConsultarBoletim(int ra)
    {
        foreach (var aluno in alunos)
        {
            if (aluno.RA == ra)
            {
                return aluno.Boletim;
            }
        }

        return null;
    }
    private void ExibirBoletimAlunos()
    {
        Console.Clear();
        Console.WriteLine(" ------------------------------");
        Console.WriteLine("      BOLETIM DOS ALUNOS       ");
        Console.WriteLine(" ------------------------------");

        if (alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno encontrado. Cadastre alunos antes de exibir o boletim.");
        }
        else
        {
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Aluno: {aluno.Nome} - RA: {aluno.RA:D4} - Turma: {aluno.Serie}");

                if (aluno.Boletim.NotasPorMateria.Count == 0)
                {
                    Console.WriteLine("A situação de aprovação ainda não foi divulgada.");
                }
                else
                {
                    foreach (var materia in aluno.Boletim.NotasPorMateria.Keys)
                    {
                        int[] notas = aluno.Boletim.NotasPorMateria[materia];
                        double media = notas.Average();
                        string situacao = media >= 7 ? "APROVADO" : "REPROVADO";

                        Console.WriteLine($"- Matéria: {materia}, Média: {media:F2}, Situação: {situacao}");
                    }
                }

                Console.WriteLine("----------------------------");
            }
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Alunos...");
        Console.ReadKey();
    }








    private void BoletimConsultarNota()
    {
        Console.Clear();
        Console.WriteLine("----- BOLETIM E CONSULTAR NOTA -----");

        Console.Write("Digite o RA do aluno para consultar o boletim (somente números, quatro casas decimais): ");
        int ra = Utils.ReadInt("");

        Aluno aluno = alunos.Find(a => a.RA == ra);
        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado. Verifique o RA digitado.");
        }
        else
        {
            Console.WriteLine($"Boletim do Aluno - RA: {ra:D4}");

            if (aluno.Boletim.NotasPorMateria.Count == 0)
            {
                Console.WriteLine("Nenhuma nota encontrada para este aluno.");
            }
            else
            {
                foreach (var materia in aluno.Boletim.NotasPorMateria.Keys)
                {
                    int[] notas = aluno.Boletim.NotasPorMateria[materia];
                    double media = notas.Average();
                    string situacao = media >= 7 ? "APROVADO" : "REPROVADO";

                    Professor professor = professores.FirstOrDefault(p => p.Materia == materia && p.Classe == aluno.Serie);
                    string nomeProfessor = professor != null ? professor.Nome : "Professor não encontrado";

                    Console.WriteLine($"- {materia}: Média: {media:F2}, Situação: {situacao}, Professor: {nomeProfessor}");
                    Console.WriteLine("  Notas: " + string.Join(", ", notas));
                }

                double mediaGeral = aluno.Boletim.NotasPorMateria.Values.SelectMany(n => n).Average();
                string situacaoGeral = mediaGeral >= 7 ? "APROVADO" : "REPROVADO";
                Console.WriteLine($"Média Geral: {mediaGeral:F2}, Situação Geral: {situacaoGeral}");
            }
        }

        Console.WriteLine("\n1 - Voltar ao Menu Principal");
        int opcaoVoltar = Utils.ReadInt("");

        if (opcaoVoltar == 1)
        {
            ExibirMenu();
        }
    }
}
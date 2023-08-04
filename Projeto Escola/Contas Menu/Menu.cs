using System;
using Projeto_Escola;
using Projeto_Escola.Diretoria;
using Projeto_Escola.Serviços;

public class Menu
{
    public void ExibirMenu()
    {


        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("       MENU PRINCIPAL      ");
            Console.WriteLine("---------------------------");
            Console.WriteLine("   1 - ALUNOS");
            Console.WriteLine("   2 - PROFESSORES");
            Console.WriteLine("   3 - SAIR");
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

    public void ExibirMenuAlunos()
    {
        CriarAluno cAluno = new CriarAluno();
        ListarAlunos listaAluno = new ListarAlunos();
        AtribuirNota boletimAluno = new AtribuirNota();
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("      MENU ALUNOS      ");
            Console.WriteLine("---------------------------");
            Console.WriteLine("   1 - CRIAR ALUNOS        ");
            Console.WriteLine("   2 - VER LISTA DE ALUNOS ");
            Console.WriteLine("   3 - BOLETIM             ");
            Console.WriteLine("   4 - VOLTAR");
            Console.WriteLine("---------------------------");
            Console.WriteLine("   Escolha uma opção (1-3):");
            Console.WriteLine("---------------------------");
            opcao = Utils.ReadInt("");
            switch (opcao)
            {
                case 1:
                    cAluno.CriarAlunos();
                    break;
                case 2:
                    listaAluno.VerListaAlunos();
                    break;
                case 3:
                    boletimAluno.ExibirBoletim();
                    break;
                case 4:
                    ExibirMenu();
                    break;
                default:

                    Utils.WriteLineColored("Opção inválida. Digite novamente numeros apenes entre (1 - 3).", ConsoleColor.Red);

                    Console.ReadLine();
                    break;
            }
        } while (opcao > 4 || opcao < 1 || opcao != 4);
        Console.ReadLine();
    }

    public void ExibirMenuProfessores()
    {
        CriarProfessor cProf = new CriarProfessor();
        ListarProfessor listarProfessor = new ListarProfessor();
        AtribuirNota atribuirNota = new AtribuirNota();

        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("      MENU PROFESSORES     ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("  1 - CRIAR PROFESSOR");
            Console.WriteLine("  2 - CONSULTAR PROFESSOR");
            Console.WriteLine("  3 - ATRIBUIÇÃO DE NOTA");
            Console.WriteLine("  4 - VOLTAR");
            Console.WriteLine("------------------------------");
            Console.WriteLine("    Escolha uma opção (1-4):  ");
            Console.WriteLine("------------------------------");
            opcao = Utils.ReadInt("");

            switch (opcao)
            {
                case 1:
                    cProf.CriarProfessores();
                    break;
                case 2:
                    listarProfessor.VerListaProfessores();
                    break;
                case 3:
                    atribuirNota.AtribuicaoDeNota();
                    break;
                case 4:
                    ExibirMenu();
                    break;
                default:
                    Utils.WriteLineColored("Opção inválida. Tente novamente.", ConsoleColor.Red);
                    break;
            }
        } while (opcao != 4);
    }

    //usar o linq
    public BoletimContas ConsultarBoletim(int ra)
    {
        foreach (Aluno aluno in Listas.ListaAluno)
        {
            if (aluno.RA == ra)
            {
                return aluno.Boletim;
            }
        }

        return null;
    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Escola.Serviços
{
    public class AtribuirNota
    {
        Menu m = new Menu();    
        public void AtribuicaoDeNota()
        
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

            Professor professor = Listas.ListaProfessor.Find(p => p.ID == professorId);

            if (professor == null)
            {
                Console.WriteLine("Professor não encontrado. Verifique o ID digitado.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Professores...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
            Console.WriteLine($" | {professor.Nome} | ID: {professor.ID:D2} | Matéria: {professor.Materia} | Série {professor.Classe}  |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");

            int ra;
            do
            {
                Console.Write("Digite o RA do aluno para atribuir as notas (somente números, quatro casas decimais): ");
            } while (!int.TryParse(Console.ReadLine(), out ra));

            Aluno aluno = Listas.ListaAluno.Find(a => a.RA == ra);

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
                Console.WriteLine($"Atribuindo notas para o aluno - Nome {aluno.Nome} RA: {ra:D4} - Turma: {aluno.Serie}");

                double[] notas = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        Console.Write($"Digite a nota {i + 1} (de 0 a 10): ");
                    } while (!double.TryParse(Console.ReadLine(), out notas[i]) || notas[i] < 0 || notas[i] > 10);
                }

                aluno.Media = notas.Average();
                string situacao = aluno.Media >= 7 ? "APROVADO" : "REPROVADO";
                //aluno.Media = media;


                Console.WriteLine($"Notas atribuídas com sucesso! | Nome: {aluno.Nome} RA: {ra:D4} | Turma: {aluno.Serie} | Média: {aluno.Media:F2} | Situação: {situacao} | Matéria: {professor.Materia} |");
                string resultadoAtribuicao = $" Nome {aluno.Nome} | Média: {aluno.Media:F2}, Situação: {situacao}, Matéria: {professor.Materia}";
                aluno.ResultadosAtribuicao.Add(resultadoAtribuicao);
                

            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu de Professores...");
            Console.ReadKey();
        }

        public void ExibirBoletim()
        {
            Console.Clear();
            Console.WriteLine(" -------------------------");
            Console.WriteLine("         BOLETIM          ");
            Console.WriteLine(" -------------------------");

            Console.Write("Digite o RA do aluno para consultar o boletim (somente números, quatro casas decimais): ");
            int ra = Utils.ReadInt("");

            Aluno aluno = Listas.ListaAluno.Find(a => a.RA == ra);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado. Verifique o RA digitado.");
            }


            Listar();


            Console.WriteLine("\n1 - Voltar ao Menu Principal");
            int opcaoVoltar = Utils.ReadInt("");

            if (opcaoVoltar == 1)
            {
                m.ExibirMenu();
            }
        }

        public void Listar()
        {

            var resultado =
            from aluno in Listas.ListaAluno
            join professor in Listas.ListaProfessor
            on aluno.Serie equals professor.Classe
            orderby aluno.Nome, professor.Nome
            select new { aluno.Nome, Nomeprof = professor.Nome, aluno.Serie, aluno.RA, professor.Materia, professor.Classe, aluno.Media, aluno.Status };

            foreach (var item in resultado)
            {
                Console.WriteLine($"RA: {item.RA} Nome do aluno: {item.Nome} Nome do professor: {item.Nomeprof} Matéria {item.Materia} Serie: {item.Classe} MEDIA: {item.Media} ");
            }

        }

        public class Boletim
        {


            public int RA { get; set; }
            public Dictionary<string, int[]> NotasPorMateria { get; }

            public Boletim(int ra)
            {
                RA = ra;
                NotasPorMateria = new Dictionary<string, int[]>();
            }

            public void AdicionarNota(string materia, int nota1, int nota2, int nota3, int nota4)
            {
                NotasPorMateria[materia] = new int[] { nota1, nota2, nota3, nota4 };
            }

            public double CalcularMedia(string materia)
            {
                if (NotasPorMateria.ContainsKey(materia))
                {
                    int[] notas = NotasPorMateria[materia];
                    return notas.Average();
                }
                return 0;



            }
            public bool PassouDeAno(string materia)
            {
                double media = CalcularMedia(materia);
                return media >= 7;
            }

            public override string ToString()
            {
                return $"RA: {RA:D4}, Boletim com {NotasPorMateria.Count} matérias.";
            }




        }
    }
}

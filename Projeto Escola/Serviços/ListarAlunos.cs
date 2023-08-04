using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Escola.Serviços
{
    public class ListarAlunos
    {
        public void VerListaAlunos()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         LISTA DE ALUNOS                                                   ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

            var alunosOrdenados = Listas.ListaAluno.OrderBy(a => a.Nome).ToList();
            if (Listas.ListaAluno.Count == 0)
            {
                Utils.WriteLineColored("                                    NENHUM ALUNO REGISTRADO                              ", ConsoleColor.Red);



            }
            else
            {
                var alunosArrumados = Listas.ListaAluno.OrderBy(a => a.Nome).ToList();
                foreach (Aluno obj in Listas.ListaAluno)
                {
                    Console.WriteLine(obj);
                }
            }


            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                               Pressione qualquer tecla para voltar...");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }
    }
}

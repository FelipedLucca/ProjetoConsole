using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Escola.Serviços
{
    public class ListarProfessor
    {
        public void VerListaProfessores()
        {

            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                         LISTA DE PROFESSORES           ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Listas.ListaProfessor.OrderBy(p => p.Nome).ToList();
            foreach (Professor professor in Listas.ListaProfessor)
            {
                Console.WriteLine(professor);
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                               Pressione qualquer tecla para voltar...");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
        }



    }
}

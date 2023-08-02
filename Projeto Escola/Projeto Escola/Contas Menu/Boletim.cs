using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        return -1; // Retorna -1 se a matéria não foi encontrada
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
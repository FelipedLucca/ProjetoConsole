using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

public class Aluno : Pessoa
{
    public string Serie { get; set; }
    public int RA { get; set; }
    public BoletimContas Boletim { get; private set; }
    public double Media { get; set; }
    public string Status { get; set; }

    public Aluno(string nome, DateTime dataNascimento, string serie, int ra)
        : base(nome, dataNascimento)
    {
        Serie = serie;
        RA = ra;
        Boletim = new BoletimContas(ra);
    }

    public List<string> ResultadosAtribuicao { get; } = new List<string>();

    public override string ToString()
    {
        return base.ToString() + $", Série: {Serie}, RA: {RA:D4}";
    }

}

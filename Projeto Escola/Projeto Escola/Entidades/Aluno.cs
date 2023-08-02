using System;

public class Aluno : Pessoa
{
    public string Serie { get; set; }
    public int RA { get; set; }
    public Boletim Boletim { get; private set; }

    public Aluno(string nome, DateTime dataNascimento, char genero, string serie, int ra)
        : base(nome, dataNascimento, genero)
    {
        Serie = serie;
        RA = ra;
        Boletim = new Boletim(ra);
    }

    public override string ToString()
    {
        return base.ToString() + $", Série: {Serie}, RA: {RA:D4}";
    }






















}

using System;

public class Professor : Pessoa
{
    public string Materia { get; set; }
    public string Classe { get; set; }
    public int ID { get; set; }

    public Professor(string nome, DateTime dataNascimento, string materia, string classe, int id)
        : base(nome, dataNascimento)
    {
        Materia = materia;
        Classe = classe;
        ID = id;
    }

    public override string ToString()
    {
        return base.ToString() + $", Matéria: {Materia}, Classe: {Classe}, ID: {ID:D2}";
    }
}

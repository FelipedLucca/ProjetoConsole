using System;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public char Genero { get; set; }

    public Pessoa(string nome, DateTime dataNascimento, char genero)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Genero = genero;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}, Gênero: {Genero}";
    }
}
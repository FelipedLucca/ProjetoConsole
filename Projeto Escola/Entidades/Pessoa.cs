using System;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public Pessoa(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}";
    }
}
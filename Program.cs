using System;
using System.Collections.Generic;

public class Pessoa
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }
}

public class Suite
{
    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }

    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
}

public class Reserva
{
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva(int diasReservados)
    {
        Hospedes = new List<Pessoa>();
        DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count <= Suite.Capacidade)
        {
            Hospedes = hospedes;
        }
        else
        {
            throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
        }
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        decimal valorTotal = DiasReservados * Suite.ValorDiaria;
        if (DiasReservados > 10)
        {
            valorTotal *= 0.9m; 
        }
        return valorTotal;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Suite suite = new Suite("Luxo", 4, 150.00m);
        Reserva reserva = new Reserva(12);
        
        reserva.CadastrarSuite(suite);

        List<Pessoa> hospedes = new List<Pessoa>
        {
            new Pessoa("João", "Silva"),
            new Pessoa("Maria", "Oliveira")
        };

        reserva.CadastrarHospedes(hospedes);

        Console.WriteLine("Quantidade de Hóspedes: " + reserva.ObterQuantidadeHospedes());
        Console.WriteLine("Valor Total da Diária: " + reserva.CalcularValorDiaria());
    }
}

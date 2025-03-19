
using Faturamento.Models;
using System;
using System.Diagnostics;
using System.Text.Json;


class Program
{
    static void Main(string[] args)
    {
        CalcularFaturamentoMedio();
    }

    public static void CalcularFaturamentoMedio()
    {
        string caminhoJson = "C:\\Users\\Higor\\source\\repos\\Faturamento\\Faturamento\\dados.json";
        string conteudoJson = File.ReadAllText(caminhoJson);


        List<Dados> dias  = JsonSerializer.Deserialize<List<Dados>>(conteudoJson);

        var menorFaturamento = dias.Where(d => d.valor > 0).Min(d => d.valor);
        var maiorFaturamento = dias.Where(d => d.valor > 0).Max(d => d.valor);
        var Media = dias.Where(d => d.valor > 0).ToList();

        double soma = 0;
        
        foreach(var num in Media)
        {
            soma += num.valor;
        }

        double media = soma / Media.Count(d => d.valor > 0);

        var diasComFaturamentoMaiorQueMedia = dias.Where(d => d.valor > media);

        foreach(var dia in diasComFaturamentoMaiorQueMedia)
        {
            Console.WriteLine($"Dias com faturamento maior que a media {dia.dia} valor {dia.valor}");
        }

        Console.WriteLine($"Menor Faturamento {menorFaturamento}");
        Console.WriteLine($"Maior Faturamento {maiorFaturamento}");
    }

    public class Dados
    {
        public int dia { get; set; }
        public double valor { get; set; }
    }
}


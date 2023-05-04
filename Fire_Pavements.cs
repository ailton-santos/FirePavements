using System;
using System.Collections.Generic;

namespace PrevisibilidadeFogo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Previsibilidade de Fogo em Edificação\n");

            // Criar o edifício
            Edificio edificio = new Edificio(2000, 5);

            // Criar os pavimentos do edifício
            edificio.CriarPavimentos(50);

            // Criar os ocupantes do edifício
            edificio.CriarOcupantes(1000);

            // Inicializar a simulação
            Simulacao simulacao = new Simulacao(edificio);

            // Executar a simulação
            simulacao.Executar(10);

            // Obter o tempo de evacuação ideal
            double tempoEvacuacaoIdeal = edificio.TempoEvacuacaoIdeal;

            // Obter a capacidade máxima de pessoas
            int capacidadeMaxima = edificio.CapacidadeMaxima;

            // Exibir resultado
            Console.WriteLine("\nTempo de Evacuação Ideal: " + tempoEvacuacaoIdeal.ToString("0.00") + " minutos");
            Console.WriteLine("Capacidade Máxima de Pessoas: " + capacidadeMaxima + " pessoas");

            Console.ReadKey();
        }
    }

    class Edificio
    {
        private double area;
        private int numPavimentos;
        private List<Pavimento> pavimentos;
        private List<Ocupante> ocupantes;
        private double tempoEvacuacaoIdeal;
        private int capacidadeMaxima;

        public Edificio(double area, int numPavimentos)
        {
            this.area = area;
            this.numPavimentos = numPavimentos;
            this.pavimentos = new List<Pavimento>();
            this.ocupantes = new List<Ocupante>();
        }

        public double Area { get { return area; } }
        public int NumPavimentos { get { return numPavimentos; } }
        public List<Pavimento> Pavimentos { get { return pavimentos; } }
        public List<Ocupante> Ocupantes { get { return ocupantes; } }
        public double TempoEvacuacaoIdeal { get { return tempoEvacuacaoIdeal; } }
        public int CapacidadeMaxima { get { return capacidadeMaxima; } }

        public void CriarPavimentos(int capacidadePavimento)
        {
            for (int i = 0; i < numPavimentos; i++)
            {
                pavimentos.Add(new Pavimento(i + 1, capacidadePavimento));
            }
        }

        public void CriarOcupantes(int numOcupantes)
        {
            for (int i = 0; i < numOcupantes; i++)
            {
                int pavimentoIndex = i % numPavimentos;
                pavimentos[pavimentoIndex].AdicionarOcupante(new Ocupante());
            }
        }

        public void CalcularTempoEvacuacaoIdeal(double tempoRespostaB);

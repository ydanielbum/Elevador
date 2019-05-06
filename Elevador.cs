using System.Collections.Generic;
using System;

namespace Elevador
{
    public class Elevador
    {
        public List<Passageiro> passageiros = new List<Passageiro>();
        private int _andarAtual;
        public int AndarAtual
        {
            get { return _andarAtual; }
            set { _andarAtual = value; }
        }

        public Elevador(int andarAtual)
        {
            this._andarAtual = andarAtual;
        }

        public void iniciaElevador()
        {
            Console.WriteLine("O elevador está no andar: " + this._andarAtual);
            verificaAndar();
            atualizaCaminho();

            mover();
        }

        /* 
        Ordena os passageiros de acordo com o esforço de movimento que o elevador precisa realizar para
        pegar ou levar o passageiro.
        */
        public void atualizaCaminho()
        {
            if (this.passageiros.Count > 0)
            {
                this.passageiros.Sort(delegate (Passageiro p1, Passageiro p2)
                {
                    if (calculaEsforcoMovimento(p1.source) > calculaEsforcoMovimento(p2.source))
                    {
                        return 1;
                    }
                    else if (calculaEsforcoMovimento(p1.source) < calculaEsforcoMovimento(p2.source))
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                });
            }
        }

        //Verifica se o andar atual é o destino ou a origem de algum passageiro
        private void verificaAndar()
        {
            foreach (Passageiro passageiroAndar in passageiros.FindAll(p => p.source == this._andarAtual))
            {
                if (passageiroAndar.embarcou)
                {
                    passageiroAndar.desembarcar(this);
                    Console.WriteLine("Um passageiro desembarcou!");
                }
                else
                {
                    passageiroAndar.embarcar(this);
                    Console.WriteLine("Um passageiro embarcou!");
                }
            }
        }

        //Move o elevador enquanto existir passageiro na lista
        private void mover()
        {
            while (passageiros.Count > 0)
            {

                if (passageiros[0].source > this._andarAtual)
                {
                    this._andarAtual++;
                }
                else
                {
                    this._andarAtual--;
                }

                Console.WriteLine("O elevador está no andar: " + this._andarAtual);

                verificaAndar();
                atualizaCaminho();
            }
        }

        //Calcula o esforço para realizar a movimentação do elevador
        private int calculaEsforcoMovimento(int destino)
        {
            return Math.Abs(destino - this._andarAtual);
        }

    }
}
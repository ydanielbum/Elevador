using System;
using System.Collections.Generic;


namespace Elevador
{
    class Program
    {

        static void Main(string[] args)
        {

            //Teste 1
            Console.WriteLine("TESTE 1:");
            Passageiro p1 = new Passageiro(8, 0);
            Passageiro p2 = new Passageiro(0, 7);

            Elevador elevador = new Elevador(5);
            
            p1.chamarElevador(elevador);
            p2.chamarElevador(elevador);

            elevador.iniciaElevador();

            //Teste 2
            Console.WriteLine("TESTE 2:");
            Passageiro p3 = new Passageiro(8, 0);
            Passageiro p4 = new Passageiro(0, 7);
            Passageiro p5 = new Passageiro(3, 15);

            Elevador elevador2 = new Elevador(3);
            
            p3.chamarElevador(elevador2);
            p4.chamarElevador(elevador2);
            p5.chamarElevador(elevador2);

            elevador2.iniciaElevador();

        }
    }
}

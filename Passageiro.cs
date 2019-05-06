namespace Elevador
{
    public class Passageiro
    {
        public int origem;
        public int destino;
        public bool embarcou = false;

        public int source
        {
            get { return embarcou ? destino : origem; }
        }

        public Passageiro(int origem, int destino)
        {
            this.origem = origem;
            this.destino = destino;
        }

        public void chamarElevador(Elevador elevador)
        {
            elevador.passageiros.Add(this);
            elevador.atualizaCaminho();
        }

        public void embarcar(Elevador elevador)
        {
            this.embarcou = true;
        }

        public void desembarcar(Elevador elevador)
        {
            elevador.passageiros.Remove(this);
        }

    }
}
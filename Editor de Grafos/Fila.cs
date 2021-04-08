
/*
 * CLASSE FILA - IMPLEMENTA O TIPO ABSTRATO DE DADOS FILA ESTÁTICA CIRCULAR
 * OPERAÇÕES: *
 *	vazia() -> retorna true se a fila está vazia.
 *	cheia() -> returna true se a fila  está cheia.
 *	enfileirar(x) -> coloca o elemento x no fim da fila.
 *	desenfileirar() -> retorna o elemento situado no inicio da fila.
 */

namespace Editor_de_Grafos
{
    public class Fila
    {
        private int[] vet;
        private int inicio;
        private int fim;

        public Fila(int tam)
        {
            vet = new int[tam];
            inicio = fim = 0;
        }

        public void enfileirar(int i)
        {
            vet[fim] = i;
            fim = (fim + 1) % vet.Length;
        }

        public int desenfileirar()
        {
            int item;
            item = vet[inicio];
            inicio = (inicio + 1) % vet.Length;
            return item;
        }

        public bool vazia()
        {
            return inicio == fim;
        }

        public bool cheia()
        {
            return ((fim + 1) % vet.Length) == inicio;
        }
    }
}

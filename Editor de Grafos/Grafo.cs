using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace Editor_de_Grafos
{
    class CustoMinimo 
    {
        int vertice; int antecessor; int estimativa; bool fechado;
        public CustoMinimo(int v, int a, int e, bool f)
        {
            vertice = v;
            Antecessor = a;
            Estimativa = e;
            Fechado = f;
        }

        public int Antecessor { get => antecessor; set => antecessor = value; }
        public int Estimativa { get => estimativa; set => estimativa = value; }
        public bool Fechado { get => fechado; set => fechado = value; }
        public int Vertice { get => vertice; set => vertice = value; }

        public string teste()
        {
            return "|Vertice: " + vertice + " Antecessor: " + antecessor + " Estimativa: " + estimativa + " Fechado: " + fechado + "| ";
        }
    }

    class AGM
    {
        Aresta aresta; int vertice; int peso;
        public AGM(Aresta a, int v, int p)
        {
            aresta = a;
            vertice = v;
            peso = p;
        }

        public Aresta GetAresta()
        {
            return aresta;
        }

        public int getVertice()
        {
            return vertice;
        }

        public int getPeso()
        {
            return peso;
        }
    }

    class NumCromatico
    {
        string nome; bool usado;
        public NumCromatico(string nome, bool usado)
        {
            this.Nome = nome;
            this.Usado = usado;
        }       
        
        public string Nome { get => nome; set => nome = value; }
        public bool Usado { get => usado; set => usado = value; }
    }

    public class Grafo : GrafoBase, iGrafo
    {
        // cor da aresta e do vertice destacados
        private Color vCor = Color.Red;
        private Color aCor = Color.Blue;

        /* TODOS
         * 
         * NADA
         * 
         */

        #region outras funções

        // Remove a formatação causada pelos algoritmos
        public void removeFormatacao()
        {
            for (int i = 0; i < matAdj.GetLength(0); i++)
                for (int j = 0; j < matAdj.GetLength(0); j++)
                    if (matAdj[i, j] != null)
                    {
                        getVertice(i).setCor(System.Drawing.Color.Chocolate);
                        matAdj[i, j].setCor(System.Drawing.Color.Black);
                    }
        }       

        #endregion

        public int AGM(int v)
        {
            int custo_total = 0;
            List<int> vertices = new List<int>(); // lista de vertices para serem verificados    
            bool[] visitado = new bool[getN()]; // lista de vertices visitados
            
            visitado[v] = true; // marca V como visitado
            vertices.Add(v); // adiciona v a lista dos vertices a serem checados

            getVertice(v).setCor(vCor); // muda a cor do vertice atual

            int cont = 0; // se cont for igual N, então já foi passado em todos os vertices
            while (cont != getN())
            {
                List<AGM> VerticeAresta = new List<AGM>();
                foreach (int x in vertices) // busca em todos os vertices q já foram visitados que tem peso e armazena eles em uma outra lista
                {                    
                    for (int i = 0; i < getN(); i++)
                    {
                        // se I é adjacente a V e I ainda não foi visitado
                        if (matAdj[x, i] != null && !visitado[i])
                        {
                            VerticeAresta.Add(new AGM(matAdj[x, i], i, matAdj[x, i].getPeso()));
                        }                        
                    }
                }                  
                
                int flag = 1;
                AGM menor = null;
                // verifica qual aresta tem o menor peso
                foreach(var item in VerticeAresta)
                {
                    if (flag == 1) // o primeiro valor da aresta é definido como menor
                    {
                        menor = item;
                        flag = 0; // trava esse if
                    }
                    
                    if (item.getPeso() < menor.getPeso()) // verifica se o peso é menor que o atual menor
                       menor = item;                    
                }

                vertices.Add(menor.getVertice()); // adiciona aos vertices visitados
                visitado[menor.getVertice()] = true; // marca como verdadeiro o vertice
                menor.GetAresta().setCor(aCor); // define uma cor a aresta
                Thread.Sleep(500);
                getVertice(menor.getVertice()).setCor(vCor); // define uma cor o vertice
                custo_total += menor.getPeso(); // adiciona o peso ao custo total
                VerticeAresta.Clear(); // Limpa a lista para o próx ciclo.

                // verifica se já passei por todos os vertices
                cont = 0;
                for (int i = 0; i < visitado.GetLength(0); i++)
                {
                    if (visitado[i])
                        cont++;                        
                }
            }

            return custo_total;

        }

        public void caminhoMinimo(int i, int j)
        {
            List<CustoMinimo> CM = new List<CustoMinimo>();
            bool[] visitado = new bool[getN()];
            int fechados = 0;

            // pega todos os vertices e coloca naquela tabela
            for (int x = 0; x < getN(); x++)
            {
                for (int z = 0; z < getN(); z++)
                {
                    if (matAdj[x, z] != null && visitado[x] != true)
                    {
                        visitado[x] = true;
                        CM.Add(new CustoMinimo(x, -1, Int32.MaxValue, false));
                    }
                }
            }

            // Pega o indice e define o antecessor igual a ele mesmo 
            foreach (var item in CM)
            {
                if (item.Vertice == i)
                {
                    item.Antecessor = i;
                    item.Estimativa = 0;
                    break;
                }
            }

            // conta quantos vertices estão fechados
            foreach (var item in CM)
            {
                if (item.Fechado == true)
                    fechados++;
            }

            // selecione o vertice com a menor estimativa ainda em aberto
            while (fechados != getN())
            {
                CustoMinimo menor = null;
                int flag = 1; 
                foreach (var item in CM)
                {
                    // pega o primeiro valor do foreach como menor
                    if (flag == 1 && item.Fechado != true) 
                    {
                        menor = item;
                        flag = 0;
                    } 
                    else if(flag == 0 && item.Estimativa < menor.Estimativa && item.Fechado != true)
                        menor = item;
                    // compara o item atual com o menor valor
                }

                // marca como true o menor valor
                foreach (var item in CM)
                {
                    if (item == menor)
                    {
                        item.Fechado = true;
                        break;
                    }
                }

                // pega a lista dos vertices adjacentes ao menor
                List<Vertice> lista = getAdjacentes(menor.Vertice);
                foreach (var item in lista)
                {
                    foreach (var cm in CM)
                    {
                        // verifica se o vertice do item é igual ao vertice dos vizinhos do menor
                        if(item == getVertice(cm.Vertice) && cm.Fechado != true)
                        {
                            int estimativa = 0;

                            // atualiza a estimativa com o peso da aresta
                            estimativa = getAresta(menor.Vertice, cm.Vertice).getPeso() + menor.Estimativa;

                            // compara se a estimativa somada com a estimativa do vizinho
                            // é menor que a estimativa atual
                            if (estimativa < cm.Estimativa)
                            {
                                cm.Estimativa = estimativa;

                                // define o antecessor do vizinho
                                cm.Antecessor = menor.Vertice;
                            }
                                
                            break;
                        }
                    }
                }

                fechados = 0;
                foreach (var item in CM)
                {
                    if (item.Fechado == true)
                        fechados++;
                }
            }

            int ant = 0;
            // colore o j e pega seu antecessor
            foreach (var item in CM)
            {                
                if(item.Vertice == j)
                {
                    getVertice(j).setCor(aCor);
                    Thread.Sleep(500);
                    getAresta(j, item.Antecessor).setCor(vCor);
                    
                    ant = item.Antecessor;
                    break;
                }
            }

            // colore todos os antecessores de J
            while (ant != i)
            {
                foreach (var item in CM)
                {
                    if(item.Vertice == ant)
                    {
                        getAresta(ant, item.Antecessor).setCor(vCor);
                        getVertice(ant).setCor(aCor);
                        Thread.Sleep(500);

                        ant = item.Antecessor;
                        break;
                    }
                }
            }

            // colore o vertice inicial
            getVertice(i).setCor(aCor);

        }

        public void completarGrafo()
        {
            for (int i = 0; i < getN(); i++)
                for (int j = 0; j < getN(); j++)
                {
                    if (i != j)
                        setAresta(i, j, 1);
                    
                    /*
                    if(i == j)
                        setAresta(i, j, 0);                    
                    else
                        setAresta(i, j, 1);  
                    */
                }            

            Refresh();

        }

        // ent se a gente tiver um cont_arestas para as coloridas 
        // e um aresta_total e cont_aresta == aresta_total ele é uma arvore
        // getNArestas() == cont_aresta

        private int cont;
        public bool isArvore(){
            bool[] visitado = new bool[getN()];
            cont = 0;

            cont = cont_aresta(0, visitado);
            if ((getNArestas() / 2) == cont)
                return true;
            else
                return false;
        }

        public int cont_aresta(int v, bool[] visitado)
        {
            visitado[v] = true; // marca V como visitado
            for (int i = 0; i < matAdj.GetLength(0); i++)
            {
                // se I é adjacente a V e I ainda não foi visitado
                if (matAdj[v, i] != null && !visitado[i])
                {
                    // chamada recursiva (vá para o vértice I)
                    matAdj[v, i].setCor(aCor);
                    cont++;
                    cont_aresta(i, visitado);
                }
            }

            return cont;
        }

        public bool isEuleriano()
        {
            int i;
            for (i = 0; i < getN(); i++)
            {
                if (grau(i) % 2 != 0)
                    return false;

            }
            if (getN() != 0)
                return true;
            else
                return false;
        }

        public bool isUnicursal()
        {
            int gImpar = 0;
            for (int i = 0; i < getN(); i++)
            {
                if (grau(i) % 2 != 0)
                    gImpar++;
            }
            return (gImpar == 2);
        }

        public void largura(int v)
        {
            Fila f = new Fila(matAdj.GetLength(0));
            bool[] visitado = new bool[getN()];

            f.enfileirar(v);
            visitado[v] = true; // marca V como visitado
            while (!f.vazia())
            {
                v = f.desenfileirar(); // retira o próximo vértice da fila
                getVertice(v).setCor(vCor);

                for (int i = 0; i < matAdj.GetLength(0); i++)
                {
                    // se I é adjacente a V e I ainda não foi visitado
                    if (matAdj[v, i] != null && !visitado[i])
                    {
                        visitado[i] = true; // marca i como visitado
                        matAdj[v, i].setCor(aCor);
                        f.enfileirar(i); // enfileira i
                        Thread.Sleep(500);
                    }
                }
            }
        }        

        public String paresOrdenados()
        {
            string msg = "";
            for (int i = 0; i < matAdj.GetLength(0); i++)
                for (int j = 0; j < matAdj.GetLength(0); j++)
                    if (matAdj[i, j] != null)
                        msg += $"({i},{j}) ";

            return msg.Trim();
        }            
        
        // OBS: Não deu pra colocar o bool[] visitado na classe Grafo, motivos:
        // 1 - não tinha como deixar um valor fixo para ele pois o getN() não aparece aqui
        // 2 - seus valores sempre ficam iguais a null
        public void profundidade(int v, bool[] visitado)
        {
            visitado[v] = true; // marca V como visitado
            getVertice(v).setCor(vCor); // muda a cor do vertice atual

            for (int i = 0; i < matAdj.GetLength(0); i++)
            {
                // se I é adjacente a V e I ainda não foi visitado
                if (matAdj[v, i] != null && !visitado[i])
                {
                    // chamada recursiva (vá para o vértice I)
                    matAdj[v, i].setCor(aCor);
                    Thread.Sleep(500);
                    profundidade(i, visitado);
                }
            }
        }

        public int numeroCromatico()
        {
            Fila f = new Fila(matAdj.GetLength(0));
            bool[] visitado = new bool[getN()]; // vetor de visitados
            int Vertice = 0, mNumVertices = 0;
            // Vertice - vertice com o maior número de vizinhos
            // mNumVertices - Maior número de Vertices

            // Pega o vertice com o maior número de vizinhos
            for (int i = 0; i < getN(); i++)
            {
                // se o número de vizinhos do vertice atual é maior que o mNumVertices
                if (getAdjacentes(i).Count > mNumVertices)
                {
                    mNumVertices = getAdjacentes(i).Count;
                    Vertice = i;
                }
            }

            List<Color> c = new List<Color>();
            c.Add(Color.Red);
            c.Add(Color.LightGreen);
            c.Add(Color.Green);
            c.Add(Color.Pink);
            c.Add(Color.Yellow);
            c.Add(Color.Magenta);
            c.Add(Color.Cyan);
            c.Add(Color.Gray);
            c.Add(Color.Brown);
            
            // NumCromatico(string nome, bool usado)
            // nome - nome da cor
            // usado - se ele já foi usado pelos vizinhos então true
            List<NumCromatico> lCores = new List<NumCromatico>();
            lCores.Add(new NumCromatico(Color.Blue.Name, false)); // adiciona a cor azul na lista

            getVertice(Vertice).setCor(Color.Blue); // define a cor do primeiro vertice
            f.enfileirar(Vertice); // enfilera o vertice com o maior número de vizinhos
            visitado[Vertice] = true; // marca Vertice com o maior número de vizinhos como visitado

            while (!f.vazia())
            {
                Vertice = f.desenfileirar(); // retira o próximo vértice da fila

                for (int i = 0; i < matAdj.GetLength(0); i++)
                {
                    // se I é adjacente a V e I ainda não foi visitado
                    if (matAdj[Vertice, i] != null && !visitado[i])
                    {
                        visitado[i] = true; // marca i como visitado
                        f.enfileirar(i); // enfileira i

                        // reseta o valor booleano da lista de cores
                        foreach (var cor in lCores)
                        {
                            cor.Usado = false;
                        }

                        // verifica se algum vizinho tem a cor que está na lista
                        foreach (var item in getAdjacentes(i))
                        {
                            foreach (var cor in lCores)
                            {
                                if (item.getCor().Name == cor.Nome)
                                {
                                    cor.Usado = true;
                                }
                            }
                        }
                        
                        bool existeCor = false;
                        // verifica se existe pelo menos uma cor que não é usada pelos vizinhos
                        foreach (var cor in lCores)
                        {
                            if (!cor.Usado)
                            {
                                getVertice(i).setCor(Color.FromName(cor.Nome));
                                existeCor = true;
                                break;
                            }
                        }

                        // se não existe uma cor que não é usada pelos vizinhos
                        // criemos uma nova
                        if (!existeCor)
                        {
                            Random r = new Random();
                            Color color = c[r.Next(c.Count - 1)]; // pega uma cor aleatória
                            lCores.Add(new NumCromatico(color.Name, false)); // adiciona a cor aleatoria para a lista
                            getVertice(i).setCor(color); // coloca a cor aleatória no vertice

                            c.Remove(color);
                        }
                    }
                }
            }

            return lCores.Count; // retorna o número de cores
        }
     
    }
}

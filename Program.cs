using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace MA
{
    class Program
    {
        public class GrafoLA
        {

            public static int[] selectionSort(int[] vetor)
            {
                int min, aux;


                for (int i = 0; i < vetor.Length - 1; i++)
                {
                    min = i;

                    for (int j = i + 1; j < vetor.Length; j++)
                        if (vetor[j] < vetor[min])
                            min = j;

                    if (min != i)
                    {
                        aux = vetor[min];
                        vetor[min] = vetor[i];
                        vetor[i] = aux;
                    }
                }

                return vetor;
            }

            int b = 0, qtdvertice,T,count;
            
            private Dictionary<int, List<int>> grafos;

            //Construtora recebe um vertice como parametro
            //e cria um grafo atulizando a estrutura de dados
            //dictionary
            public GrafoLA(int v)
            {
                grafos = new Dictionary<int, List<int>>();
                this.qtdvertice = v;
                for (int i = 1; i <= v; i++)
                {
                    grafos.Add(i, new List<int>());
                }
            }

            //esse metodo retorna a ordem do grafo
            public int Ordem()
            {
                return grafos.Count;

            }

            //esse metodo recebe um vertice como parametro
            //e retorna o grau desse vertice
            public int Grau(int vertice)
            {
                if (grafos.ContainsKey(vertice))
                    b = grafos[vertice].Count();
                return b;
            }

            //esse metodo recebe dois vertices como parametro
            //e verifica se contem os vertices no grafo
            //se contem ele insere a aresra entre os dois vertices
            public void InsereAresta(int v1, int v2)
            {
                if ((grafos.ContainsKey(v1)) && (grafos.ContainsKey(v2)))
                {
                    grafos[v1].Add(v2);
                    grafos[v2].Add(v1);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n Vertice" + v1 + " e o " + v2 + "Nao existe em Grafos");
                }
            }

            //esse metodo recebe dois vertices e verifica se
            //existe aresta entre os dois vertices
            public bool ExisteAresta(int v1, int v2)
            {
                if (grafos[v1].Contains(v2))
                    return true;
                return false;
            }

            //esse vertice recebe dois vertices como parametro e 
            //retira a aresta entre os dois se existir aresta
            public void RetiraAresta(int v1, int v2)
            {
                if (ExisteAresta(v1, v2))
                {
                    grafos[v1].Remove(v2);
                    grafos[v2].Remove(v1);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n Nao existe a aresta informada");
                }

            }

            //esse metodo recebe um vertice como parametro
            //e oncere o mesmo no grafo
            public void IncereVertice(int v)
            {
                if (grafos.ContainsKey(v))
                {
                    Console.Clear();
                    Console.WriteLine("\n Vertice ja existe em grafos");
                }
                else
                    grafos.Add(v, new List<int>());
            }

            //esse metodo recebe um vertice como parametro
            //e faz a remocao do vertice percorrendo todo 
            //o dictionary removendo o vertice se ele existir
            public void RetiraVertice(int v)
            {
                if (grafos.ContainsKey(v))
                {
                    foreach (KeyValuePair<int, List<int>> origem in grafos)
                    {

                        for (int i = 0; i < origem.Value.Count; i++)
                            if (origem.Value[i] == v)
                                grafos[origem.Key].Remove(v);
                    }

                    grafos.Remove(v);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n Vertice nao existe");
                }
            }

            //esse metodo imprimi a lista de adjacencia
            public void ImprimiLA()
            {
                Console.Clear();
                foreach (int v in grafos.Keys)
                {

                    Console.Write("\n" + v + ": ");
                    foreach (int num in grafos[v])
                        Console.Write(num + " ");
                }

                Console.WriteLine();
            }

            //esse metodo imprimi uma matriz adjacente
            public void ImprimiiMA()
            {
                T = 0;
                for (T = 1; T <=qtdvertice; T++)
                    Console.Write(" "+T );
                Console.WriteLine();
                foreach (int origem in grafos.Keys)
                {
                    Console.Write(origem + "\t");
                    foreach (int num in grafos[origem])
                        Console.Write(num + "\t");
                    Console.WriteLine();
                }
            }

            //esse metodo recebe um vertice e
            //mostra na tela os vertices adjacentes desse vertice
            //passado como parametro
            public void ListaDeAdjacente(int v)
            {
                Console.Clear();
                foreach (int eu in grafos[v])
                    Console.WriteLine(" " + eu);
            }

            //esse metodo verifica se o o grafo eh completo
            //se for ele retorna verdadeiro e impime no 
            //programa principal que ele e completo
            //se nao ele retorna falso e exibe que ele nao
            //eh completo
            public bool Completo()
            {
                int x = (qtdvertice * (qtdvertice - 1)) / 2;
                count = 0;
                foreach(int i in grafos.Keys)
                    count = count+grafos[i].Count;
                count = count / 2;
                if (count == x)
                    return true;
                else
                    return false;
            }


            //esse metodo verifica se os graus de cada chave do dictionary
            //sao iguais, se todos os graus forem iguais o grafo e regular
            //e o metodo retorna verdadeiro, se nao for retorna falso
            public bool Regular()
            {
                int grauVertice1 = 0;
                int grauVertice2 = 0;
                bool regular = true;

                grauVertice1 = grafos[1].Count;

                for (int i = 2; i <= qtdvertice; i++)
                {
                    grauVertice2 = 0;

                    grauVertice2 = grafos[i].Count;

                    if (grauVertice1 != grauVertice2)
                        regular = false;
                }
                return regular;
            }

            public void SequenciaGraus()
            {
                int AUX = 0, o;
                int[]vet;
                vet= new int[qtdvertice+1];
               // for(o=1;o<=qtdvertice;o++)
                 //   Console.WriteLine(vet[o]);

               foreach (int i in grafos.Keys)
                {
                    AUX = grafos[i].Count;
                    vet[i] = AUX;
                }

                selectionSort(vet);

                for (int i = 1; i <= qtdvertice; i++)
                    Console.Write(vet[i] + "\t");
                }
            public bool Impar(int v1)
            {
                bool impar = false;

                if (grafos[v1].Count % 2 != 0)
                {
                    impar = true;
                }

                return impar;
            }

            public bool Par(int v)
            {
                bool par = false;

                if (grafos[v].Count % 2 == 0)
                {
                    par = true;
                }

                return par;
            }

            public bool Isolado (int vertice)
            {
                bool isolado = false;
                if (grafos[vertice].Count == 0)
                {
                    isolado = true;
                }
                else
                {
                    isolado = false;
                }
                return isolado;
            }

            public bool Adjacentes (int v1, int v2)
            {
                bool adjacente = true;

                if (grafos[v1].Contains(v2)  && grafos[v2].Contains(v1))
                {
                    adjacente = true;
                }

                return adjacente;
            }

            //Programa principal de GrafoLA
            public static void GrafoLAProgram()
            {
                int opc, v, v2;
                GrafoLA grafo;
                Console.Clear();
                Console.Write("Digite o número inical de vertices: ");
                v = int.Parse(Console.ReadLine());
                grafo = new GrafoLA(v);


                do
                {


                    Console.WriteLine("\n-------- GRAFOS ----------");
                    Console.WriteLine("1 - Inserir aresta");
                    Console.WriteLine("2 - Existe aresta ?");
                    Console.WriteLine("3 - Retira aresta");
                    Console.WriteLine("4 - Insere vertice ?");
                    Console.WriteLine("5 - Retira vertice");
                    Console.WriteLine("6 - ShowLA");
                    Console.WriteLine("7 - Imprimir Adjacentes");
                    Console.WriteLine("8 - Ordem");
                    Console.WriteLine("9 - grau");
                    Console.WriteLine("10 - ShowMA");
                    Console.WriteLine("11 - Grafo eh Completo ?");
                    Console.WriteLine("12 - Grafo eh Regular?");
                    Console.WriteLine("13 - Sequencia de Grau");
                    Console.WriteLine("14 - Impar");
                    Console.WriteLine("15 - Par");
                    Console.WriteLine("16 - Isolado");
                    Console.WriteLine("17 - Adjacentes");
                    Console.WriteLine("==> ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:

                            Console.Write("Digite as duas vertices para ligação: ");
                            v = int.Parse(Console.ReadLine());
                            v2 = int.Parse(Console.ReadLine());
                            Console.Clear();
                            grafo.InsereAresta(v, v2);
                            break;

                        case 2:

                            Console.Write("Digite as duas vertices: ");
                            v = int.Parse(Console.ReadLine());
                            v2 = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if (grafo.ExisteAresta(v, v2))
                                Console.WriteLine("Existe a aresta");
                            else
                                Console.WriteLine("Não existe a aresta");
                            break;

                        case 3:

                            Console.Write("Digite os dois vertices: ");
                            v = int.Parse(Console.ReadLine());
                            v2 = int.Parse(Console.ReadLine());
                            Console.Clear();
                            grafo.RetiraAresta(v, v2);
                            break;

                        case 4:

                            Console.Write("Digite o vertices: ");
                            v = int.Parse(Console.ReadLine());
                            Console.Clear();
                            grafo.IncereVertice(v);
                            break;

                        case 5:

                            Console.Write("Digite o vertices: ");
                            v = int.Parse(Console.ReadLine());
                            Console.Clear();
                            grafo.RetiraVertice(v);
                            break;

                        case 6:
                            Console.Clear();
                            grafo.ImprimiLA();
                            break;

                        case 7:
                            Console.Write("Digite o vertices: ");
                            v = int.Parse(Console.ReadLine());
                            Console.Clear();
                            grafo.ListaDeAdjacente(v);
                            break;
                        case 8:
                            int a;
                            a = grafo.Ordem();
                            Console.Clear();
                            Console.WriteLine("\nOrdem eh: " + a);
                            break;

                        case 9:
                            int c;
                            Console.Clear();
                            Console.Write("Digite o vertices: ");
                            v = int.Parse(Console.ReadLine());
                            c = grafo.Grau(v);
                            Console.Clear();
                            Console.WriteLine("\nO grau eh: " + c);
                            break;

                        case 10:

                            Console.Clear();
                            grafo.ImprimiiMA();
                            
                            break;

                        case 11:
                            Console.Clear();
                           if( grafo.Completo())
                                Console.WriteLine("O grafo eh Completo");
                           else
                                Console.WriteLine("O grafo nao eh Completo");
                            break;

                        case 12:
                            Console.Clear();
                            if(grafo.Regular())
                                Console.WriteLine("O grafo eh Regular");
                            else
                                Console.WriteLine("O grafo nao eh Regular");

                            break;

                        case 13:
                            Console.Clear();
                            grafo.SequenciaGraus();
                            break;

                        case 14:
                            Console.Clear();
                            Console.Write("Digite o vértice que deseja verificar: ");
                            v = int.Parse(Console.ReadLine());
                            if (grafo.Impar(v))
                            {
                                Console.Write("O vértice é ímpar");
                            }
                            else
                            {
                                Console.Write("O vértice não é ímpar");
                            }
                          
                            break;

                        case 15:
                            Console.Clear();
                            Console.Write("Digite o vértice que será verificado: ");
                            v = int.Parse(Console.ReadLine());
                            if (grafo.Par(v))
                            {
                                Console.WriteLine("O vertice é par!");
                            }
                            else
                            {
                                Console.WriteLine("O vertice não é par!");
                            }

                            break;

                        case 16:
                            Console.Clear();
                            Console.Write("Qual vertice será verificado? ");
                            v = int.Parse(Console.ReadLine());
                            if (grafo.Isolado(v))
                            {
                                Console.WriteLine("O vertice é Isolado!");
                            }
                            else
                            {
                                Console.WriteLine("O vértice não é isolado");
                            }

                            break;

                        case 17:
                            Console.Clear();
                            Console.Write("Digite o 1º vértice: ");
                            v = int.Parse(Console.ReadLine());
                            Console.Write("Digite o 2º vértice: ");
                            v2 = int.Parse(Console.ReadLine());
                            if (grafo.Adjacentes(v, v2))
                            {
                                Console.Write("Os vértices são adjacentes");
                            }
                            else
                            {
                                Console.Write("Os vértices não são adjacentes");
                            }

                            break;
                    }
                } while (opc != 10);

            }
        }
    




        public class GrafoMA
        {
            public static int[] selectionSort(int[] vetor)
            {
                int min, aux;


                for (int i = 0; i < vetor.Length - 1; i++)
                {
                    min = i;

                    for (int j = i + 1; j < vetor.Length; j++)
                        if (vetor[j] < vetor[min])
                            min = j;

                    if (min != i)
                    {
                        aux = vetor[min];
                        vetor[min] = vetor[i];
                        vetor[i] = aux;
                    }
                }

                return vetor;
            }

            public int cout;
            public int[,] MA;
            public int qtVertices;


            // metodo construtor do grafo
            //recebe a quantidade de vertice como parametro e 
            //constroi uma matriz inicializando todos os seus
            //elementos com 0;
            public GrafoMA(int qtdVertice)
            {
                this.qtVertices = qtdVertice;

                MA = new int[qtVertices, qtVertices];

                for (int i = 0; i < qtVertices; i++)
                {
                    for (int j = 0; j < qtVertices; j++)
                        MA[i, j] = 0;
                }
            }

            //metodo que exibi a matriz;
            public void showMA()
            {
                Console.Write("\t");

                for (int i = 0; i < qtVertices; i++)
                    Console.Write(i + "\t");

                Console.WriteLine();

                for (int i = 0; i < qtVertices; i++)
                {
                    Console.Write(i + "\t");
                    for (int j = 0; j < qtVertices; j++)
                        Console.Write(MA[i, j] + "\t");

                    Console.WriteLine();
                }

            }

            //metodo que recebe como parametro o vertice desejado
            //a verificar o grau, e retorna o grau do vertice
            public int Grau(int vertice)
            {
                cout = 0;

                for (int g = 0; g < qtVertices; g++)
                {
                    if (g == vertice)
                    {
                        for (int j = 0; j < qtVertices; j++)
                        {
                            if (g != j)
                            {
                                if (MA[g, j] == 1)
                                    cout++;
                            }
                        }

                    }
                }
                return cout;
            }

            //metodo que retorna a ordem do grafo ou seja
            //a quantidade de vertice que existe no grafo.
            public int Ordem()
            {
                return qtVertices;
            }

            //esse metodo recebe como parametro dois vertice
            //e retorna verdadeiro alem de incerir a aresta na matriz de adjacencia
            public bool InserirAresta(int v1, int v2)
            {
                MA[v1, v2] = 1;
                MA[v2, v1] = 1;

                return true;
            }

            //esse metodo recebe dois vertice como parametro
            //e retorna verdadeiro alem de remover as arestas da matriz de adjacencia
            public bool RemoverAresta(int v1, int v2)
            {
                MA[v1, v2] = 0;
                MA[v2, v1] = 0;
                return true;
            }

            //esse metodo verifica se o grafo é completo ao seja
            //se o grafo tem todas as arestas
            //retornando verdadeiro se for completo e falso se nao for
            public bool Completo()
            {
                int x = (qtVertices * (qtVertices - 1)) / 2;
                int y = 0;
                cout = 0;

                for (int g = 0; g < qtVertices; g++)
                {
                    for (int j = 0; j < qtVertices; j++)
                    {
                        if (g != j)
                        {
                            if (MA[g, j] == 1)
                                cout++;
                        }
                    }
                }
                y = cout / 2;
                if (x == y)
                    return true;
                else
                    return false;
            }

            //esse metodo verifica se o grau de todos os vertices 
            //sao igual, se for retona verdadeiro, se nao 
            //retorna falso.
            public bool Regular()
            {
                int grauVertice1 = 0;
                int grauVertice2 = 0;
                bool regular = true;

                for (int i = 0; i < qtVertices; i++)
                {
                    if (MA[0, i] == 1)
                        grauVertice1++;
                }
                for (int i = 1; i < qtVertices; i++)
                {
                    grauVertice2 = 0;
                    for (int j = 0; j < qtVertices; j++)
                    {
                        if (MA[i, j] == 1)
                            grauVertice2++;
                    }

                    if (grauVertice1 != grauVertice2)
                        regular = false;

                }
                return regular;

            }

            //esse metodo exibi a matriz
            public void ShowLA()
            {
                showMA();
                Console.WriteLine();
                for (int i = 0; i < qtVertices; i++)
                {
                    Console.Write(i + ":" + "\t");

                    for (int j = 0; j < qtVertices; j++)
                    {
                        if (MA[i, j] == 1)
                            Console.Write(j + "\t");
                    }
                    Console.WriteLine();
                }

            }

            //esse metodo exibe a sequencia em ordem crescente dos graus do grafo
            //otiliza o metodo de ordenacao sort
            public void SequenciaGraus()
            {
                int grauu;

                int[] list = new int[qtVertices];

                for (int i = 0; i < qtVertices; i++)
                {
                    grauu = 0;
                    for (int j = 0; j < qtVertices; j++)
                    {
                        if (MA[i, j] == 1)
                            grauu++;
                    }

                    list[i] = grauu;
                }

                selectionSort(list);

                Console.Write(" A sequencia de grau eh: ");
                for (int l = 0; l < list.Length; l++)
                    Console.Write(" " + list[l] + " ");


            }


            //esse metodo recebe um vertice passado por parametro
            //e imprime os vertices adjacentes a ele, ou seja
            //os vertices que tem ligacao com o vertice passado
            //por parametro
            public void VerticesAdjacentes(int vertice)
            {
                Console.Clear();
                Console.Write("OS vertices adjacente sao: ");
                for (int i = 0; i < qtVertices; i++)
                {
                    if (i == vertice)
                    {
                        for (int j = 0; j < qtVertices; j++)
                        {
                            if (MA[i, j] == 1)
                                Console.Write(j + "\t");
                        }
                    }
                }
            }

            //esse metodo recebe um vertice passado por parametro
            //e verifica se ele eh isolado ou seja se ele possui
            //alguma aresta ou nao, se for isolado retorna verdadeiro
            //se nao retorna falso
            public bool Isolado(int vertice)
            {
                bool isolado = true;

                for (int g = 0; g < qtVertices; g++)
                {
                    if (MA[vertice, g] == 1)
                    {
                        isolado = false;
                        return isolado;
                    }
                }
                return isolado;
            }

            //esse metodo recebe um vertice por parametro 
            //e verifica se o grau dele é impar, se for impar 
            //retorna verdadeiro se nao for impar retorna falso
            public bool Impar(int vertice)
            {
                cout = 0;
                for (int i = 0; i < qtVertices; i++)
                {
                    if (MA[vertice, i] == 1)
                        cout++;
                }
                if (cout % 2 == 0)
                    return false;
                else
                    return true;
            }

            //esse metodo recebe um vertice por parametro 
            //e verifica se o grau dele é par, se for par 
            //retorna verdadeiro se nao for par retorna falso
            public bool Par(int vertice)
            {
                cout = 0;
                for (int i = 0; i < qtVertices; i++)
                {
                    if (MA[vertice, i] == 1)
                        cout++;
                }
                if (cout % 2 == 0)
                    return true;
                else
                    return false;
            }

            //esse metodo recebe dois vertices
            //e indica se eles sao adjacentes ou nao
            //retornando verdadeiro se for e falso se
            //nao for
            public bool Adjacentes(int v1, int v2)
            {
                bool adjacente = false;

                if (MA[v1, v2] == 1 && MA[v2, v1] == 1)
                    adjacente = true;

                return adjacente;
            }

            public static void GrafoMAs()
            {
                int x, v1, v2, v;

                Console.WriteLine("\nDigite a quantidade de vertice");
                v = int.Parse(Console.ReadLine());

                //cria o grafo atraves de uma matriz
                //onde a quantidade de vertice acima pedido 
                //determina o tamanho da martriz 
                GrafoMA grafo = new GrafoMA(v);

                grafo.showMA();

                Console.ReadKey(true);
                Console.Clear();
                do
                {

                    //menu de opcoes
                    Console.WriteLine("\n-------- GRAFOS ----------");
                    Console.WriteLine("1 - Ordem");
                    Console.WriteLine("2 - Inserir Aresta");
                    Console.WriteLine("3 - Remover aresta");
                    Console.WriteLine("4 - Grau do grafo");
                    Console.WriteLine("5 - Grafo eh completo ?");
                    Console.WriteLine("6 - Imprimir grafo");
                    Console.WriteLine("7 - Grafo eh Regular ?");
                    Console.WriteLine("8 - Show MA");
                    Console.WriteLine("9 - Show LA");
                    Console.WriteLine("10 - Sequncia Grau");
                    Console.WriteLine("11 - Lista de adjacencia");
                    Console.WriteLine("12 - vertice isolado");
                    Console.WriteLine("13 - Vertice eh Impar ?");
                    Console.WriteLine("14 - Vertice eh Par ?");
                    Console.WriteLine("15 - Adjacentes");
                    Console.WriteLine("16 - Classe GrafosLA");
                    Console.WriteLine("0 - SAIR ");

                    Console.WriteLine("==> ");
                    x = int.Parse(Console.ReadLine());

                    switch (x)
                    {
                        case 0:
                            Environment.Exit(x);
                            break;

                        case 1:

                            int a;
                            a = grafo.Ordem();
                            Console.Clear();
                            Console.WriteLine("\nOrdem eh: " + a);

                            break;

                        case 2:

                            Console.Write("Digite os dois vertices para ligação: ");
                            v1 = int.Parse(Console.ReadLine());
                            v2 = int.Parse(Console.ReadLine());
                            grafo.InserirAresta(v1, v2);
                            Console.Clear();

                            break;

                        case 3:

                            Console.Write("Digite os dois vertices: ");
                            v1 = int.Parse(Console.ReadLine());
                            v2 = int.Parse(Console.ReadLine());
                            grafo.RemoverAresta(v1, v2);
                            Console.Clear();

                            break;

                        case 4:

                            int c;
                            Console.Write("Digite o vertices: ");
                            v = int.Parse(Console.ReadLine());
                            c = grafo.Grau(v);
                            Console.Clear();
                            Console.WriteLine("\nO grau eh: " + c);

                            break;
                        case 5:

                            Console.Clear();
                            if (grafo.Completo())
                                Console.WriteLine("\n Grafo eh Completo");
                            else
                                Console.WriteLine("\n Grafo nao eh Completo");

                            break;

                        case 6:
                            Console.Clear();
                            grafo.showMA();
                            break;
                        case 7:
                            Console.Clear();
                            if (grafo.Regular())
                                Console.WriteLine("\n Grafo eh Regular");
                            else
                                Console.WriteLine("\n Grafo nao eh Regular");

                            break;

                        case 8:

                            Console.Clear();
                            grafo.showMA();

                            break;

                        case 9:

                            Console.Clear();
                            grafo.ShowLA();

                            break;

                        case 10:

                            Console.Clear();
                            grafo.SequenciaGraus();
                            break;

                        case 11:

                            Console.Clear();
                            Console.WriteLine("\nDigite o vertice a saber os adjacentes");
                            v = int.Parse(Console.ReadLine());
                            grafo.VerticesAdjacentes(v);

                            break;

                        case 12:

                            Console.Clear();
                            Console.WriteLine("\nDigite o vertice a saber se e isolado");
                            v = int.Parse(Console.ReadLine());

                            if (grafo.Isolado(v))
                                Console.WriteLine("O vertice eh isolado");
                            else
                                Console.WriteLine("O vertice nao eh isolado");

                            break;

                        case 13:

                            Console.Clear();
                            Console.WriteLine("\nDigite o vertice a saber se eh impar");
                            v = int.Parse(Console.ReadLine());
                            if (grafo.Impar(v) == true)
                                Console.WriteLine("Vertice eh Impar");
                            else
                                Console.WriteLine("Vertice nao eh impar");
                            break;

                        case 14:

                            Console.Clear();
                            Console.WriteLine("\nDigite o vertice a saber se eh par");
                            v = int.Parse(Console.ReadLine());
                            if (grafo.Par(v))
                                Console.WriteLine("Vertice eh Par");
                            else
                                Console.WriteLine("Vertice nao eh Par");

                            break;

                        case 15:

                            Console.Clear();

                            Console.Write("Digite os dois vertices p/ verificar adjacentes: ");
                            v1 = int.Parse(Console.ReadLine());
                            v2 = int.Parse(Console.ReadLine());

                            if (grafo.Adjacentes(v1, v2))
                                Console.WriteLine("sao Adjacentes");
                            else
                                Console.WriteLine("Nao sao Adjacentes");

                            break;

                        case 16:

                            Console.Clear();
                            GrafoLA.GrafoLAProgram();



                            break;


                    }
                } while (x != 99);


                Console.ReadKey(true);
            }
            

            static void Main(string[] args)
            {

                GrafoMAs();



            }
        }
    }
}
    


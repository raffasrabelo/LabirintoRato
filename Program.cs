using LabirintoRato;
using System;
using System.Collections.Generic;
using System.Xml;

namespace LabirintoCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] labirinto = new char[limit, limit];
            criaLabirinto(labirinto);
            mostrarLabirinto(labirinto, limit, limit);
            buscarQueijo(labirinto, 1, 1);
            Console.ReadKey();
        }
        private const int limit = 15;


        static void mostrarLabirinto(char[,] array, int l, int c)
        {
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < c; j++)
                {
                    Console.Write($" {array[i, j]} ");
                }
            }
            Console.WriteLine();
        }


        static void criaLabirinto(char[,] meuLab)
        {
            Random random = new Random();
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit; j++)
                {
                    meuLab[i, j] = random.Next(4) == 1 ? '|' : '.';
                }
            }


            for (int i = 0; i < limit; i++)
            {
                meuLab[0, i] = '*';
                meuLab[limit - 1, i] = '*';
                meuLab[i, 0] = '*';
                meuLab[i, limit - 1] = '*';
            }


            int x = random.Next(limit);
            int y = random.Next(limit);
            meuLab[x, y] = 'Q';
        }



        static void buscarQueijo(char[,] meuLab, int i, int j)
        {
            Stack<int> minhaPilha = new Stack<int>();
            do
            {
                meuLab[i, j] = 'v';
                
                if (meuLab[i-1, j] == 'Q') 
                    i--;
                
                else if (meuLab[i + 1, j] == 'Q')
                    i++;

                else if (meuLab[i, j - 1] == 'Q')
                    j--;
                

                else if (meuLab[i, j + 1] == 'Q')
                    j++;

                else if (meuLab[i, j + 1] == '.' || meuLab[i, j + 1] == 'Q')
                {
                    minhaPilha.Push(i);
                    minhaPilha.Push(j);// empilhar posicao atual // minhaPilha.Push();// i e j
                    j++;
                }
                //else if baixo i+1
                else if (meuLab[i+1, j] == '.' || meuLab[i+1, j ] == 'Q')
                {
                    minhaPilha.Push(i);// empilhar posicao atual // minhaPilha.Push();// i e j
                    minhaPilha.Push(j);
                    i++;
                }
                // else if esquerda j-1
                else if (meuLab[i, j - 1] == '.' || meuLab[i, j - 1] == 'Q')
                {
                    minhaPilha.Push(i);// empilhar posicao atual // minhaPilha.Push();// i e j
                    minhaPilha.Push(j);
                    j--;
                }
                // else if cima i-1
                else if (meuLab[i - 1, j] == '.' || meuLab[i- 1, j] == 'Q')
                {
                    minhaPilha.Push(i);// empilhar posicao atual // minhaPilha.Push();// i e j
                    minhaPilha.Push(j);
                    i--;
                }
                // if nao tiver vazio minhaPilha.Count()>0
                else if (minhaPilha.Count() > 0)
                {
                    // i, j = pop
                    j = minhaPilha.Pop();
                    i = minhaPilha.Pop();
                }
                else// se tiver vazio
                    break;
                    
                                
                System.Threading.Thread.Sleep(100);
                Console.Clear();
                mostrarLabirinto(meuLab, limit, limit);
            } while (meuLab[i, j] != 'Q' );
            // encontrou
            if (meuLab[i,j] == 'Q')
            System.Console.WriteLine("Queijo encontrado na posicao i="+i+" j="+j+".");
            else
                System.Console.WriteLine("Não há como encontrar o Queijo!");
        }



       

    }
}

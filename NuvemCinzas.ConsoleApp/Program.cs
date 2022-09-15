using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemCinzas.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o número de linhas e colunas: ");
            string ColunaLinha = Console.ReadLine();

            int numeroLinha = Convert.ToInt32(ColunaLinha.Substring(0,1));
            int numeroColuna = Convert.ToInt32(ColunaLinha.Substring(1, 2));

            string[] arrayDeLinhas = new string[numeroLinha];

            Console.WriteLine("");

            Console.WriteLine("Digite as linhas: ");

            Console.WriteLine("");


            for (int i = 0; i < numeroLinha; i++)
            {
                string input = Console.ReadLine();
                char[] inputEmChar = input.ToCharArray();

                if (inputEmChar.Length > numeroColuna || inputEmChar.Length < numeroColuna)
                {
                    Console.WriteLine("A linha digitada tem mais caracteres do que colunas definidas.");
                    break;
                }

                arrayDeLinhas[i] = input;

            }

            string mapa = "";

            for(int i = 0; i < arrayDeLinhas.Length; i++)
            {
                mapa += arrayDeLinhas[i];
            }


            int[] resultado = Calcular(mapa, numeroColuna);

            Console.WriteLine("Resultado:");
            Console.WriteLine("");
            Console.WriteLine("Dias pro primeiro aeroporto: {0}", resultado[0]);
            Console.WriteLine("Dias para todos os aeroportos: {0}", resultado[1]);
            Console.ReadLine();
        }

        static int[] Calcular(String mapa, int numeroDeColunas)
        {
            char[] mapaArray = mapa.ToCharArray();
            int contador = 0;
            int primeiroDia = 0;
            bool temAeroportos = true;


         
            while (temAeroportos == true)
            {
               

                contador++;

                for (int i = 0; i < mapa.Length; i++)
                {
                    

                    if (mapaArray[i] == '#')
                    {

                        if (i + 1 < mapaArray.Length)
                        {
                            if (mapaArray[i + 1] == '.' || mapaArray[i + 1] == '#')
                            {
                                mapaArray[i + 1] = '#';
                            }
                            else if (mapaArray[i + 1] == 'A')
                            {
                                if (primeiroDia == 0)
                                {
                                    primeiroDia = contador;
                                    mapaArray[i + 1] = '#';
                                }
                            }

                        }

                        if (i - 1 < mapaArray.Length && i > 0)
                        {
                            if (mapaArray[i - 1] == '.' || mapaArray[i - 1] == '#')
                            {
                                mapaArray[i - 1] = '#';
                            }
                            else if (mapaArray[i - 1] == 'A')
                            {
                                if (primeiroDia == 0)
                                {
                                    primeiroDia = contador;
                                    mapaArray[i - 1] = '#';
                                }
                            }
                        }

                        if (i + numeroDeColunas < mapaArray.Length)
                        {
                            if (mapaArray[i + numeroDeColunas] == '.' || mapaArray[i + numeroDeColunas] == '#')
                            {
                                mapaArray[i + numeroDeColunas] = '#';
                            }
                            else if (mapaArray[i + numeroDeColunas] == 'A')
                            {
                                if (primeiroDia == 0)
                                {
                                    primeiroDia = contador;
                                    mapaArray[i + numeroDeColunas] = '#';
                                }
                            }
                        }

                        if (i - numeroDeColunas > mapaArray.Length)
                        {
                            if (mapaArray[i - numeroDeColunas] == '.' || mapaArray[i - numeroDeColunas] == '#')
                            {
                                mapaArray[i - numeroDeColunas] = '#';
                            }
                            else if (mapaArray[i - numeroDeColunas] == 'A')
                            {
                                if (primeiroDia == 0)
                                {
                                    primeiroDia = contador;
                                    mapaArray[i - numeroDeColunas] = '#';
                                }
                            }
                        }
                        if (mapaArray.Contains('A'))
                        {
                            //não tem nada pra colocar aqui e isso é apenas uma gambiarra.
                        }
                        else
                        {
                            temAeroportos = false;
                        }
                    }
                }
            }

            int[] resultado = new int[2];

            resultado[0] = primeiroDia;
            resultado[1] = contador;
            
            return resultado;
        }  
    }
}

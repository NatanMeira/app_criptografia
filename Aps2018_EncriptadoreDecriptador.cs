using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aps2018_EncriptadoreDecriptador
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto, encriptado, encriptado1, decriptado, escolha, again, sepa, c, decriptado1, d, decriptado2;
            int contador, letra, chave, i, vezes, cont;
            

            
            do
            {
                again = "";
                escolha = "";
                texto = "";
                encriptado = "";
                encriptado1 = "";
                sepa = "";
                c = "";
                decriptado = "";
                decriptado1 = "";
                decriptado2 = "";
                d = "";
                contador = 0;
                letra = 0;
                chave = 0;
                i = 0;
                cont = 0;

                //////////////////////////////////////////////
                //Escolha do usuario: Encriptar ou Decriptar//
                //////////////////////////////////////////////
                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("//                                            //");
                Console.WriteLine("//             ESCOLHA UMA OPÇÃO              //");
                Console.WriteLine("//                                            //");
                Console.WriteLine("//        ENCRIPTAR - 1  DECRIPTAR - 2        //");
                Console.WriteLine("//                                            //");
                Console.WriteLine("////////////////////////////////////////////////");
                escolha = Console.ReadLine();
                Console.Clear();
                switch (escolha)
                {
                    //////////////////////////////////////////////////////////////
                    // Case que seleciona o algoritmo que vai encriptar a mensagem
                    case "1":
                        Console.WriteLine("////////////////////////////////////////////////");
                        Console.WriteLine("//                                            //");
                        Console.WriteLine("//               ENCRIPTADOR                  //");
                        Console.WriteLine("//                                            //");
                        Console.WriteLine("////////////////////////////////////////////////");

                        //Pede para o usuario digitar o numero que vai ser a chave da criptografia
                        Console.WriteLine("DIGITE UM NUMERO PARA SER A CHAVE DA SUA MENSAGEM");
                        chave = int.Parse(Console.ReadLine());
                        //Pede para o usuario digitar a mensagem que vai ser encriptada
                        Console.WriteLine("DIGITE O TEXTO A SER ENCRIPTADO");
                        texto = Console.ReadLine().ToLower();

                        ////////////////////////////////////////////////////////////
                        //Encriptador parte 1 - Criptografia cifra de substituição//
                        ////////////////////////////////////////////////////////////

                        //Laço que separa, aplica a chave e a cifra letra a letra
                        for (contador = 0; contador < texto.Length; contador++)
                        {
                            //Converte as letras da String para Int via tabela ASCII
                            letra = Convert.ToInt32(texto[contador]);
                            //Separa os simbolos (!,+,/,-,....) da criptografia 
                            if (letra < 32 || letra > 63)
                            {
                                letra = letra + chave;
                            }
                            //Laço para caso o valor da letra passe a letra Z
                            while (letra > 122)
                            {
                                if (letra < 60) { }
                                else { letra = letra - 26; }
                            }

                            //Converte em letras os numeros via Tabela ASCII 
                            //Letra a letra é adiciona a variavel (encriptado)
                            encriptado += Convert.ToChar(letra);
                        }
                        //Zeras as variaveis para serem reutilizadas
                        contador = 0;
                        letra = 0;

                        /////////////////////////////////////////////
                        //Encriptador parte 2 - Criptografia Base64//
                        /////////////////////////////////////////////

                        //Laço que caso seja necessario adiciona "#" no final do texto para poder separa=lo em blocos de 22 letras
                        while (encriptado.Length % 22 != 0)
                        {
                            encriptado += "#";
                        }

                        //Descobre a quantidade de vezes que o algoritmo vai ter que repetir o laço que criptografa os blocos
                        vezes = encriptado.Length / 22;

                        //Laço para repetir o processo de encriptar até o final do texto 
                        while (i != vezes)
                        {
                            //Laço que separa as 22 de letras
                            while (contador < 22)
                            {
                                letra = Convert.ToInt32(encriptado[cont]);
                                sepa += Convert.ToChar(letra);
                                //adiciona + 1 a variavel(cont)
                                //para que no proximo ciclo seja separada outra letra
                                cont++;
                                //adiciona + 1 a variavel(contador)
                                //para parar o laço quando atingir o valor 22
                                contador++;
                            }
                            //Zera o contador para poder repetir o processo acima em todo o texto
                            contador = 0;

                            
                            //Cria um vetor de bytes para valor da variavel (sepa) codificada em UTF8
                            byte[] BytesUTF8 = System.Text.Encoding.UTF8.GetBytes(sepa);
                            //Converte os bytes para o alfabeto Base64
                            //e adiciona o texto a variavel (encriptado1)
                            encriptado1 += System.Convert.ToBase64String(BytesUTF8);

                            //Zera a variavel(sepa) para que possa ser reutilizada no proximo ciclo
                            sepa = "";

                            //junta todos os blocos em uma só variavel
                            c += encriptado1;

                            //Zera a variavel (encriptado1) para que possar pegar outro bloco no proximo ciclo
                            encriptado1 = "";

                            //adiciona um a +1 em (i) para parar o laço quando acabar o texto
                            i++;
                        }

                        //Informará ao usuario a chave para decriptar a mensagem
                        Console.WriteLine("");
                        Console.WriteLine("Chave = {0}", chave);
                        //Mostra a mensagem encriptada
                        Console.WriteLine("A MENSAGEM ENCRIPTADA É:");
                        Console.WriteLine(c);
                        Console.ReadKey();
                        break;
                    
                    ///////////////////////////////////////////////////////////////
                    // Case que seleciona o algoritmo que vai decriptar a mensagem
                    case "2":
                        Console.WriteLine("////////////////////////////////////////////////");
                        Console.WriteLine("//                                            //");
                        Console.WriteLine("//               DECRIPTADOR                  //");
                        Console.WriteLine("//                                            //");
                        Console.WriteLine("////////////////////////////////////////////////");

                        //Pede para que o usuario digite o texto a ser decriptado e guarda na string
                        Console.WriteLine("DIGITE O TEXTO ENCRIPTADO");
                        decriptado = Console.ReadLine();

                        //Pede para que o usuario digite a chave
                        Console.WriteLine("DIGITE A CHAVE DA SUA MENSAGEM");
                        chave = int.Parse(Console.ReadLine());

                        ////////////////////////////////////////////////
                        //Decriptador Parte 1 - Descriptografia Base64//
                        ////////////////////////////////////////////////


                        //Descobre a quantidade de vezes que o algoritmo vai ter que repetir o laço que criptografa os blocos
                        vezes = decriptado.Length / 32;

                        //Laço para repetir o processo de decriptar até o final do texto encriptado
                        while (i != vezes)
                        {
                            //Laço que separa as 32 de letras
                            while (contador < 32)
                            {
                                letra = Convert.ToInt32(decriptado[cont]);
                                sepa += Convert.ToChar(letra);
                                //adiciona + 1 a variavel(cont)
                                //para que no proximo ciclo seja separada outra letra
                                cont++;
                                //adiciona + 1 a variavel(contador)
                                //para parar o laço quando atingir o valor 32
                                contador++;
                            }
                            //Zera o contador para poder repetir o processo acima em todo o texto
                            contador = 0;

                            
                            //Converte o texto na variavel(sepa) da base64 e guarda os bytes na variavel
                            byte[] bytes = System.Convert.FromBase64String(sepa);
                            //Decodifica os bytes em UTF8 e adiciona dentro da variavel (decriptado1) 
                            decriptado1 = System.Text.Encoding.UTF8.GetString(bytes);


                            //Zera a variavel(sepa) para que possa ser reutilizada no proximo ciclo
                            sepa = "";
                            //junta todos os blocos em uma só variavel
                            d += decriptado1;

                            //adiciona um a +1 em (i) para parar o laço quando acabar o texto
                            i++;
                        }

                        ///////////////////////////////////////////////////////////////
                        //Decriptador parte 2 - Decriptografia cifra de substituição //
                        ///////////////////////////////////////////////////////////////

                        //Laço que separa, aplica a chave e decifra letra a letra
                        for (contador = 0; contador < d.Length; contador++)
                        {
                            //Converte as letras da String para Int via tabela ASCII
                            letra = Convert.ToInt32(d[contador]);
                            //Remove a parte que foi adicionada só para completar no primeiro texto
                            if (letra == '#')
                            {
                                letra = ' ';
                            }
                            else
                            {
                                //Separa os simbolos (!,+,/,-,....) da decriptação 
                                if (letra < 32 || letra > 63)
                                {
                                    letra = letra - chave;
                                    //Laço para caso o valor da letra passe a letra A
                                    while (letra < 'a')
                                    {
                                        letra = letra + 26;
                                    }
                                }
                            }
                            //Converte em letras os numeros via Tabela ASCII 
                            //Letra a letra é adiciona a variavel (decriptado2)
                            decriptado2 += Convert.ToChar(letra);


                        }

                        //Mostra a mensagem decriptada
                        Console.WriteLine("TEXTO DECRIPTADO :");
                        Console.WriteLine(decriptado2);
                        Console.ReadKey();
                        break;
                }
                //Pergunta se o usuario deseja criptografar outra mensagem ou sair do programa
                Console.WriteLine("////////////////////////////////////////////////");
                Console.WriteLine("//                                            //");
                Console.WriteLine("//          DESEJA VOLTAR AO INICIO?          //");
                Console.WriteLine("//                                            //");
                Console.WriteLine("//           SIM - 1      NÃO - 2             //");
                Console.WriteLine("//                                            //");
                Console.WriteLine("////////////////////////////////////////////////");                
                again = Console.ReadLine();
                Console.Clear();
            }
            while (again == "1");
            Console.ReadKey();
        }
    }
}

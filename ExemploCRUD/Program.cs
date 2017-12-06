using System;
using System.Collections.Generic;

namespace ExemploCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            BancoDados banco = new BancoDados();
            Categoria cat = new Categoria();

            string op="";
            do
            {
                Console.WriteLine("\nCategorias");
                Console.WriteLine("\n1-Cadastrar");
                Console.WriteLine("2-Atualizar");
                Console.WriteLine("3-Apagar");
                Console.WriteLine("4-Consultar");
                Console.WriteLine("9-Sair");
                
                Console.Write("Escolha uma das opções acima: ");
                op = Console.ReadLine();

                switch(op)
                {
                    case "1":
                    Console.Write("Título: ");
                    cat.Titulo = Console.ReadLine();
                    banco.Add(cat);
                    break;

                    case "2":
                    Console.Write("\nID a ser atualizado: ");
                    cat.idCategoria = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Título a ser atualizado: ");
                    cat.Titulo = Console.ReadLine();
                    banco.Update(cat);
                    break;

                    case "3":
                    Console.WriteLine("");
                    string apa = Console.ReadLine();
                    break;

                    case "4":
                    string op2 = "";
                    do
                    {
                        Console.WriteLine("\n1-Consultar pelo ID");
                        Console.WriteLine("2-Consultar pelo Título");
                        Console.WriteLine("9-Voltar");

                        Console.Write("Escolha uma das opções acima: ");
                        op2=Console.ReadLine();

                        switch(op2)
                        {
                            case "1":
                                Console.WriteLine("ID a ser consultado: ");
                                cat.idCategoria = Convert.ToInt32(Console.ReadLine());
                                List<Categoria> listaPeloId = banco.ListarCategorias(cat.idCategoria);

                                foreach(Categoria item in listaPeloId)
                                {
                                    Console.WriteLine("Resultado da busca: "+item.idCategoria+" ; "+item.Titulo);
                                }
                                break;

                            case "2":
                                Console.WriteLine("Título a ser consultado: ");
                                cat.Titulo = Console.ReadLine();
                                List<Categoria> listaPeloTitulo = banco.ListarCategorias(cat.Titulo);

                                foreach(Categoria item in listaPeloTitulo)
                                {
                                    Console.WriteLine("Resultado da busca: "+item.idCategoria+" ; "+item.Titulo);
                                }
                                break;
                        }
                    
                    }while(op2!="9");
                    break;
              
                }

            }while(op!="9");
   
        }
    }
}

using MySeries.Controller;
using System;

namespace MySeries
{
    class Program
    {
        static SerieController Controller = new SerieController();
        static void Main(string[] args)
        {


            var opcaoUsua = ObterOpcaoUsuario();
            while (opcaoUsua.ToUpper() != "X")
            {
                switch (opcaoUsua)
                {
                    case "1":
                        MinhasSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        MarcarComoAssistido();
                        break;
                    case "5":
                        DesmarcarComoAssistido();
                        break;
                    case "6":
                        PesquisarSerie();
                        break;
                    case "7":
                        ExcluirSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        string acaoUsua = "escolher uma opcão";
                        Exception e = new Exception();
                        TrataException(acaoUsua, e);

                        Console.WriteLine("Por favor selecione uma das opções disponíveis");
                        break;
                }
                opcaoUsua = ObterOpcaoUsuario();
            }

            Console.WriteLine("Até logo");
            Console.WriteLine();
        }


        static void MinhasSeries()
        {
            var minhasSeries = Controller.Listar();


            if (minhasSeries.Count == 0)
            {
                Console.WriteLine("Você não possui séries cadastradas, recomendo Vikings");
            }
            else
            {
                foreach (var serie in minhasSeries)
                {
                    var assistido = serie.Assistido;
                    var excluido = serie.FoiExcluido();
                    Console.WriteLine("*ID {0}: {1} {2} {3}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "-*#Excluido#*" : ""), (assistido ? "-$Assistido$" : ""));
                }

            }

        }

        static void InserirSerie()
        {
            try
            {
                foreach (int item in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));

                }

                Console.WriteLine("Selecione um dos gêneros acima:  ");
                var genero = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o título da Série: ");
                var Titulo = Console.ReadLine();
                Console.WriteLine("Digite a descricao da série: ");
                var descricao = Console.ReadLine();
                Console.WriteLine("Digite o ano de lançamento: ");
                var anoLanc = int.Parse(Console.ReadLine());

                Serie serie = new Serie(id: Controller.ProximoId(),
                                        genero: (Genero)genero,
                                        nome: Titulo,
                                        descricao: descricao,
                                        AnoLanc: anoLanc);
                Controller.Inserir(serie);

                Console.WriteLine("Série inserida com sucesso");


            }
            catch (Exception e)
            {

                string acaoUsua = "inserir";
                TrataException(acaoUsua, e);
            }


        }

        static void AtualizarSerie()
        {
            try
            {
                Console.WriteLine("Digite o ID da série que deseja atualizar: ");
                var Id = int.Parse(Console.ReadLine());
                var serieID = Controller.RetornaPorId(Id);

                foreach (int item in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));

                }

                Console.WriteLine("Selecione um dos gêneros acima:  ");
                var genero = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o título da série: ");
                var titulo = Console.ReadLine();
                Console.WriteLine("Digite a descricao da série: ");
                var descricao = Console.ReadLine();
                Console.WriteLine("Digite o ano de lançamento: ");
                var anoLanc = int.Parse(Console.ReadLine());

                Serie serie = new Serie(id: Id, genero: (Genero)genero, nome: titulo, descricao: descricao, AnoLanc: anoLanc);
                Controller.Atualizar(Id, serie);

                Console.WriteLine("Série atualizada com sucesso: {0}", serie);

            }
            catch (Exception e)
            {
                string acaoUsua = "atualizar";
                TrataException(acaoUsua, e);
            }
        }

        static void MarcarComoAssistido()
        {
            try
            {
                Console.WriteLine("Digite o ID da série que deseja marcar como assistida: ");
                var Id = int.Parse(Console.ReadLine());
                Controller.MarcarAssistido(Id);
                var serie = Controller.RetornaPorId(Id);

                System.Console.WriteLine("Série {0} marcada como assistida", serie.RetornaTitulo());

            }
            catch (Exception e)
            {
                string acaoUsua = "marcar como assistido";
                TrataException(acaoUsua, e);

            }
        }

        static void DesmarcarComoAssistido()
        {
            try
            {
                Console.WriteLine("Digite o ID da série que deseja desmarcar como assistida: ");
                var Id = int.Parse(Console.ReadLine());
                Controller.DesmarcarAssistido(Id);
                var serie = Controller.RetornaPorId(Id);

                System.Console.WriteLine("Série {0} desmarcada como assistida", serie.RetornaTitulo());

            }
            catch (Exception e)
            {
                string acaoUsua = "desmarcar como assistido";
                TrataException(acaoUsua, e);
            }
        }

        static void PesquisarSerie()
        {
            try
            {
                Console.WriteLine("Digite o ID da série que deseja pesquisar: ");
                var Id = int.Parse(Console.ReadLine());

                Serie serie = Controller.RetornaPorId(Id);

                Console.WriteLine(serie);

            }
            catch (Exception e)
            {
                string acaoUsua = "pesquisar série";
                TrataException(acaoUsua, e);

            }

        }
        static void ExcluirSerie()
        {
            try
            {
                Console.WriteLine("Digite o ID da série que deseja excluir: ");
                var Id = int.Parse(Console.ReadLine());

                Controller.Excluir(Id);

                Console.WriteLine("Série excluída como sucesso");

            }
            catch (Exception e)
            {
                string acaoUsua = "excluir serie";
                TrataException(acaoUsua, e);
            }

        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("/* Bem vindo ao MySeries */ ");
            Console.WriteLine("Organize suas séries");
            Console.WriteLine();
            Console.WriteLine("O que deseja?");
            Console.WriteLine("1 -> Minhas séries");
            Console.WriteLine("2 -> Inserir nova série");
            Console.WriteLine("3 -> Atualizar uma série");
            Console.WriteLine("4 -> Marcar como assistido");
            Console.WriteLine("5 -> Desmarcar como assistido");
            Console.WriteLine("6 -> Pesquisar série");
            Console.WriteLine("7 -> Excluir série");
            Console.WriteLine("C -> Limpar Tela");
            Console.WriteLine("X -> Sair");
            Console.WriteLine();

            string opcaoUsua = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsua;
        }

        static void TrataException(string acaoUsua, Exception e)
        {
            Console.WriteLine("Erro ao tentar {0}: {1}", acaoUsua, e);
        }


    }
}


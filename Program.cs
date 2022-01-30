using System;

namespace DIO.Series
{
    public class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static AnimeRepositorio repositorioAnime = new AnimeRepositorio();

        #region MENU
        private static string DIOSeries()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string DIOAnimes()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Animes!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Animes");
            Console.WriteLine("2 - Inserir novo anime");
            Console.WriteLine("3 - Atualizar anime");
            Console.WriteLine("4 - Excluir anime");
            Console.WriteLine("5 - Visualizar anime");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        #endregion
        static void Main(string[] args)
        {
            System.Console.WriteLine("Escolha: /n 1 - SÉRIES /n 2 - ANIMES");
            var op = Console.ReadLine();

            if (op == "1")
            {              
                string opcaoUsuario = DIOSeries();

                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    opcaoUsuario = DIOSeries();
                }
            }
            else
            {
                Animes animes = new Animes();
                string opcaoUsuario = DIOAnimes();

                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            animes.Excluir();
                            break;
                        case "2":
                            InserirAnime();
                            break;
                        case "3":
                            AtualizarAnime();
                            break;
                        case "4":
                            ExcluirAnime();
                            break;
                        case "5":
                            VisualizarAnime();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    opcaoUsuario = DIOAnimes();
                }
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
        }

        #region CRUD Séries
        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorioSerie.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorioSerie.RetornaPorId(indiceSerie);
            System.Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digte o ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorioSerie.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluido*" : "");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digte o ano de início da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorioSerie.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorioSerie.Insere(novaSerie);
        }
        #endregion
        
        #region CRUD Animes  
        /*private static void ExcluirAnime()
        {
            System.Console.WriteLine("Digite o id da Anime:");
            int indiceAnime = int.Parse(Console.ReadLine());
            repositorioAnime.Exclui(indiceAnime);
        }

        private static void VisualizarAnime()
        {
            System.Console.WriteLine("Digite o id da Anime:");
            int indiceAnime = int.Parse(Console.ReadLine());
            var Anime = repositorioAnime.RetornaPorId(indiceAnime);
            System.Console.WriteLine(Anime);
        }*/

        private static void AtualizarAnime()
        {
            System.Console.WriteLine("Digite o id da Anime:");
            int indiceAnime = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da Anime:");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digte o ano de início da Anime:");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da Anime:");
            string entradaDescricao = Console.ReadLine();

            Animes atualizaAnime = new Animes(id: indiceAnime,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorioAnime.Atualiza(indiceAnime, atualizaAnime);
        }

        /*private static void ListarAnimes()
        {
            Console.WriteLine("Listar Animes");
            var lista = repositorioAnime.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Anime cadastrada");
                return;
            }

            foreach (var Anime in lista)
            {
                var excluido = Anime.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", Anime.retornaId(), Anime.retornaTitulo(), excluido ? "*Excluido*" : "");
            }
        }*/

        private static void InserirAnime()
        {
            Console.WriteLine("Inserir nova Anime");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da Anime:");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digte o ano de início da Anime:");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da Anime:");
            string entradaDescricao = Console.ReadLine();

            Animes novaAnime = new Animes(id: repositorioAnime.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorioAnime.Insere(novaAnime);
        }
        #endregion
    }
}
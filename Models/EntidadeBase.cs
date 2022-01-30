namespace DIO.Series
{
    public abstract class EntidadeBase
    {
    static SerieRepositorio repositorio = new SerieRepositorio();
        public int Id { get; protected set; }
        public void Excluir()
        {
            System.Console.WriteLine("Digite o id:");
            int indice = int.Parse(Console.ReadLine());
            repositorio.Exclui(indice);
        }

        public void Visualizar()
        {
            System.Console.WriteLine("Digite o id:");
            int indice = int.Parse(Console.ReadLine());
            var midia = repositorio.RetornaPorId(indice);
            System.Console.WriteLine();
        }

        /*public void Atualizar<()
        {
            System.Console.WriteLine("Digite o id:");
            int indice = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título:");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digte o ano de início:");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição:");
            string entradaDescricao = Console.ReadLine();

            T atualiza = new T(id: indice,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorio.Atualiza(indice, atualiza);
        }*/

        public void Listar()
        {
            Console.WriteLine("Listar s");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma  cadastrada");
                return;
            }

            foreach (var midia in lista)
            {
                var excluido = midia.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", midia.retornaId(), midia.retornaTitulo(), excluido ? "*Excluido*" : "");
            }
        }

        /*public void Inserir()
        {
            Console.WriteLine("Inserir nova ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título:");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digte o ano de início:");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição:");
            string entradaDescricao = Console.ReadLine();

            s nova = new s(id: repositorio.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);
            repositorio.Insere(nova);
        }*/
    }
}
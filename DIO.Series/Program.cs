using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio Repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
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

                OpcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Seja sempre bem vindo.");
            Console.ReadLine();

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = Repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornoId(), serie.retornoTitulo(), (excluido ? "*Excluido*" : ""));
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int EntradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string EntradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int EntradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string EntradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie
            (
                id: Repositorio.ProximoId(),
                genero: (Genero)EntradaGenero,
                titulo: EntradaTitulo,
                ano: EntradaAno,
                descricao: EntradaDescricao
            );

            Repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int IndiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int EntradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string EntradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int EntradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string EntradaDescricao = Console.ReadLine();

            Serie AtualizaSerie = new Serie
            (
                id: IndiceSerie,
                genero: (Genero)EntradaGenero,
                titulo: EntradaTitulo,
                ano: EntradaAno,
                descricao: EntradaDescricao
            );

            Repositorio.Atualiza(IndiceSerie, AtualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int IndiceSerie = int.Parse(Console.ReadLine());

            Repositorio.Exclui(IndiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int IndiceSerie = int.Parse(Console.ReadLine());

            var Serie = Repositorio.RetornaPorId(IndiceSerie);

            Console.WriteLine(Serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Projeto APP Cadastro de Séries em .NET");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return OpcaoUsuario;
        }
    }
}

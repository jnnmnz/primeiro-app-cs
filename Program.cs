using System;

namespace DIO.Cadastro
{
    class Program
    {
        static DoramaRepositorio repositorio = new DoramaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUser = ReceberOpcaoUser();

            while (opcaoUser.ToUpper() != "X") {
                switch (opcaoUser) {
                    case "1":
						ListarDoramas();
						break;
					case "2":
						InserirDorama();
						break;
					case "3":
						AtualizarDorama();
						break;
					case "4":
						ExcluirDorama();
						break;
					case "5":
						VisualizarDorama();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
                }
                opcaoUser = ReceberOpcaoUser();
            }
        }

        private static void ListarDoramas(){
            Console.WriteLine("-----LISTAR DORAMAS-----");

			var lista = repositorio.Lista();

			if (lista.Count == 0){
				Console.WriteLine("NENHUM DORAMA CADASTRADO!");
				return;
			}

			foreach (var dorama in lista) {   
				var indisponivel = dorama.retornaExluido();
				//if(!indisponivel){

				//}
				Console.WriteLine("#ID {0}: {1} {2}", dorama.retornaId(), dorama.retornaTitulo(), (indisponivel ? "[INDISPONÍVEL]" : ""));
			}
        }

        private static void InserirDorama() {
			Console.WriteLine("-----INSERIR NOVO DORAMA-----");

			foreach (int i in Enum.GetValues(typeof(Genero))) {
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("INFORME O CÓDIGO DO GÊNERO: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("INFORME O TÍTULO: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("INFORME O ANO DE LANÇAMENTO: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("INFORME A SINOPSE: ");
			string entradaSinopse = Console.ReadLine();

			Dorama novoDorama = new Dorama(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse);

			repositorio.Insere(novoDorama);
		}

		private static void AtualizarDorama() {
			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero))){
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("INFORME O CÓDIGO DO GÊNERO: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("INFORME O TÍTULO: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("INFORME O ANO DE LANÇAMENTO: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("INFORME A SINOPSE: ");
			string entradaSinopse = Console.ReadLine();

			Dorama atualizaDorama = new Dorama(id: idDorama,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse);

			repositorio.Atualiza(idDorama, atualizaDorama);
		}

		private static void ExcluirDorama() {
			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			repositorio.Exclui(idDorama);
		}

		private static void VisualizarDorama() {
			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			var dorama = repositorio.RetornaPorId(idDorama);

			Console.WriteLine(dorama);
		}

        private static string ReceberOpcaoUser() {
            Console.WriteLine();
			Console.WriteLine(" ________________________________");
			Console.WriteLine("|                                |");
			Console.WriteLine("|       --- MENU INICIAL ---     |");
			Console.WriteLine("|                                |");
			Console.WriteLine("| SELECIONE UMA OPÇÃO:           |");
			Console.WriteLine("|                                |");
			Console.WriteLine("| 1 - LISTAR DORAMAS             |");
			Console.WriteLine("| 2 - INSERIR NOVO DORAMA        |");
			Console.WriteLine("| 3 - ATUALIZAR DORAMA           |");
			Console.WriteLine("| 4 - EXCLUIR DORAMA             |");
			Console.WriteLine("| 5 - VISUALIZAR DORAMA          |");
			Console.WriteLine("| C - LIMPAR A TELA              |");
			Console.WriteLine("| X - SAIR                       |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|________________________________|");
			Console.WriteLine();

			string opcaoUser = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUser;
        }
    }
}

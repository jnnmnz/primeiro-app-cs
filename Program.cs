using System;

namespace DIO.Cadastro
{
    class Program
    {
        static DoramaRepositorio repositorioD = new DoramaRepositorio();
		static FilmeRepositorio repositorioF = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUserMain = ReceberOpcaoUserMain();

            while (opcaoUserMain.ToUpper() != "X") {
                switch (opcaoUserMain) {
					case "1":
						ReceberOpcaoDorama();
						break;
					case "2":
						ReceberOpcaoFilme();
						break;
					case "3":
						//AtualizarFilme();
						break;
					case "9":
						//ExcluirFilme();
						break;
					case "10":
						//VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
                }
                opcaoUserMain = ReceberOpcaoUserMain();
            }
        }


		// INICIO -- PARA DORAMAS
        private static void ListarDoramas(){
            Console.WriteLine("-----LISTAR DORAMAS-----");

			var lista = repositorioD.Lista();

			if (lista.Count == 0){
				Console.WriteLine("NENHUM DORAMA CADASTRADO!");
				return;
			}
			foreach (var dorama in lista) {   
				var indisponivel = dorama.retornaExluido();
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

			Console.Write("INFORME A EMISSORA: ");
			string entradaEmissora = Console.ReadLine();

			Console.Write("INFORME O TOTAL DE EPISÓDIOS: ");
			int entradaEpisodios = int.Parse(Console.ReadLine());

			Console.Write("COMPLETO? (S / N): ");
			bool entradaCompleto;
			if (Console.ReadLine() == "S"){
				entradaCompleto = true;
			}
			else {
				entradaCompleto = false;
			}

			Dorama novoDorama = new Dorama(id: repositorioD.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse,
										emissora: entradaEmissora,
										episodios: entradaEpisodios,
										completo: entradaCompleto);

			repositorioD.Insere(novoDorama);
		}

		private static void AtualizarDorama() {
			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero))){
				Console.WriteLine("[{0}] {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("INFORME O CÓDIGO DO GÊNERO: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("INFORME O TÍTULO: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("INFORME O ANO DE LANÇAMENTO: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("INFORME A SINOPSE: ");
			string entradaSinopse = Console.ReadLine();

			Console.Write("INFORME A EMISSORA: ");
			string entradaEmissora = Console.ReadLine();

			Console.Write("INFORME O TOTAL DE EPISÓDIOS: ");
			int entradaEpisodios = int.Parse(Console.ReadLine());

			Console.Write("COMPLETO? (S / N): ");
			bool entradaCompleto;
			if (Console.ReadLine() == "S"){
				entradaCompleto = true;
			}
			else {
				entradaCompleto = false;
			}

			Dorama atualizaDorama = new Dorama(id: idDorama,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse,
										emissora: entradaEmissora,
										episodios: entradaEpisodios,
										completo: entradaCompleto);

			repositorioD.Atualiza(idDorama, atualizaDorama);
		}

		private static void ExcluirDorama() {
			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			repositorioD.Exclui(idDorama);
		}

		private static void VisualizarDorama() {
			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			var dorama = repositorioD.RetornaPorId(idDorama);

			Console.WriteLine(dorama);
		}

		// FIM -- PARA DORAMAS


		// INICIO -- PARA FILMES
		 private static void ListarFilmes(){
            Console.WriteLine("-----LISTAR FILMES-----");

			var lista = repositorioF.Lista();

			if (lista.Count == 0){
				Console.WriteLine("NENHUM FILME CADASTRADO!");
				return;
			}

			foreach (var filme in lista) {   
				var indisponivel = filme.retornaExluido();
				//if(!indisponivel){}
				Console.WriteLine(" #ID {0}: {1} {2}", filme.retornaId(), filme.retornaTitulo(), (indisponivel ? "[INDISPONÍVEL]" : ""));
			}
        }

        private static void InserirFilme() {
			Console.WriteLine("-----INSERIR NOVO FILME-----");

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

			Console.Write("INFORME A DURAÇÃO EM MINUTOS: ");
			int entradaDuracao = int.Parse(Console.ReadLine());

			Filme novoFilme = new Filme(id: repositorioF.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse,
										duracao: entradaDuracao);

			repositorioF.Insere(novoFilme);
		}

		private static void AtualizarFilme() {
			Console.Write("INFORME O ID DO FILME: ");
			int idFilme = int.Parse(Console.ReadLine());

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

			Console.Write("INFORME A DURAÇÃO EM MINUTOS: ");
			int entradaDuracao = int.Parse(Console.ReadLine());

			Filme atualizaFilme = new Filme(id: idFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse,
										duracao: entradaDuracao);

			repositorioF.Atualiza(idFilme, atualizaFilme);
		}

		private static void ExcluirFilme() {
			Console.Write("INFORME O ID DO FILME: ");
			int idFilme = int.Parse(Console.ReadLine());

			repositorioF.Exclui(idFilme);
		}

		private static void VisualizarFilme() {
			Console.Write("INFORME O ID DO FILME: ");
			int idFilme = int.Parse(Console.ReadLine());

			var dorama = repositorioF.RetornaPorId(idFilme);

			Console.WriteLine(dorama);
		}

        private static string ReceberOpcaoUserMain() {
			Console.Clear();
            Console.WriteLine();
			Console.WriteLine(" ________________________________");
			Console.WriteLine("|                                |");
			Console.WriteLine("|       --- MENU INICIAL ---     |");
			Console.WriteLine("|                                |");
			Console.WriteLine("| SELECIONE UMA OPÇÃO:           |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|  1 - DORAMAS                   |");
			Console.WriteLine("|  2 - FILMES                    |");
			Console.WriteLine("|  3 - LISTAR TUDO               |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|  X - SAIR                      |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|________________________________|");
			Console.WriteLine();
			
			Console.Write(">> ");
			string opcaoUserMain = Console.ReadLine().ToUpper();

			return opcaoUserMain;
        }

		private static string ReceberOpcaoDorama() {
			Console.Clear();
            Console.WriteLine();
			Console.WriteLine(" ________________________________");
			Console.WriteLine("|                                |");
			Console.WriteLine("|         --- DORAMAS ---        |");
			Console.WriteLine("|                                |");
			Console.WriteLine("| SELECIONE UMA OPÇÃO:           |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|  1 - LISTAR DORAMAS            |");
			Console.WriteLine("|  2 - INSERIR NOVO DORAMA       |");
			Console.WriteLine("|  3 - ATUALIZAR DORAMA          |");
			Console.WriteLine("|  4 - EXCLUIR DORAMA            |");
			Console.WriteLine("|  5 - VISUALIZAR DORAMA         |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|  V - VOLTAR                    |");
			Console.WriteLine("|  X - SAIR                      |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|________________________________|");
			Console.WriteLine();

			Console.Write(">> ");
			string opcaoUserD = Console.ReadLine().ToUpper();

			while (opcaoUserD!="V"){
				switch(opcaoUserD) {
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
					case "V":
						opcaoUserD="0";
						ReceberOpcaoUserMain();
						break;		
					case "X":
						Environment.Exit(-1);
						break;
				}
			}
			return opcaoUserD;
        }
		private static string ReceberOpcaoFilme() {
            Console.Clear();
			Console.WriteLine();
			Console.WriteLine(" ________________________________");
			Console.WriteLine("|                                |");
			Console.WriteLine("|         --- FILMES ---         |");
			Console.WriteLine("|                                |");
			Console.WriteLine("| SELECIONE UMA OPÇÃO:           |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|  1 - LISTAR FILMES             |");
			Console.WriteLine("|  2 - INSERIR NOVO FILME        |");
			Console.WriteLine("|  3 - ATUALIZAR FILME           |");
			Console.WriteLine("|  4 - EXCLUIR FILME             |");
			Console.WriteLine("|  5 - VISUALIZAR FILME          |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|  V - VOLTAR                    |");
			Console.WriteLine("|  X - SAIR                      |");
			Console.WriteLine("|                                |");
			Console.WriteLine("|________________________________|");
			Console.WriteLine();

			string opcaoUserF = Console.ReadLine().ToUpper();
			Console.WriteLine();

			while (opcaoUserF!="X"){
				if (opcaoUserF=="1") {
					ListarFilmes();
				}
				else if (opcaoUserF=="2"){
					InserirFilme();
				}
				else if (opcaoUserF=="3"){
					AtualizarFilme();
				}					
				else if(opcaoUserF=="4"){
					ExcluirFilme();
				}
				else if(opcaoUserF=="5"){
					VisualizarFilme();
				}
				else if(opcaoUserF=="V"){
					ReceberOpcaoUserMain();
				}			
			}

			return opcaoUserF;
        }
    }
}

using System;
using System.Collections.Generic;

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
					case "A":
						string opcaoUserD = ReceberOpcaoDorama();
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
								case "X":
									Environment.Exit(-1);
									break;
								default:
									Console.WriteLine();
									Console.WriteLine("!! SELECIONE UMA OPÇÃO VÁLIDA !!");
									Console.WriteLine();
									Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
									Console.ReadKey();
									break;
							}
							opcaoUserD=ReceberOpcaoDorama();
						} break;
					case "B":
						string opcaoUserF=ReceberOpcaoFilme();
						while (opcaoUserF!="V"){
							switch(opcaoUserF) {
								case "1":
									ListarFilmes();
									break;
								case "2":
									InserirFilme();
									break;
								case "3":
									AtualizarFilme();
									break;		
								case "4":
									ExcluirFilme();
									break;
				 				case "5":
									VisualizarFilme();
									break;
								case "X":
									Environment.Exit(-1);
									break;
								default:
									Console.WriteLine();
									Console.WriteLine("!! SELECIONE UMA OPÇÃO VÁLIDA !!");
									Console.WriteLine();
									Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
									Console.ReadKey();
									break;								
							}
							opcaoUserF=ReceberOpcaoFilme();
						} break;
					default:
						Console.WriteLine("!! SELECIONE UMA OPÇÃO VÁLIDA !!");
						Console.WriteLine();
						Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
						Console.ReadKey();
						break;
                }
                opcaoUserMain=ReceberOpcaoUserMain();
        	}

			Console.WriteLine();
			Console.WriteLine("!! OBRIGADO POR UTILIZAR NOSSOS SERVIÇOS !!");
			return;
        }


		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		// PARA DORAMAS --
		// INICIO --
		// --

		private static void Vazio(){
			Console.WriteLine();
			Console.WriteLine("!!  NENHUM TÍTULO CADASTRADO  !! ");
			Console.WriteLine();
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
			return;
		}
        private static void ListarDoramas(){
			var lista = repositorioD.Lista();
			if (lista.Count == 0){Vazio();return;}

			Console.WriteLine("    -----    LISTA DE DORAMAS    -----   ");
			Console.WriteLine();
			foreach (var dorama in lista) {   
				var indisponivel = dorama.retornaExluido();
				Console.WriteLine(" #{0} - {1} {2}", dorama.retornaId(), dorama.retornaTitulo(), (indisponivel ? "[INDISPONÍVEL]" : ""));
			}
			Console.WriteLine();
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
        }

        private static void InserirDorama() {
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("    -----    INSERIR NOVO DORAMA    -----    ");
			Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(Genero))) {
				Console.WriteLine("  [{0}] {1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.WriteLine();

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
			if (Console.ReadLine().ToUpper()=="S"){entradaCompleto = true;}
			else {entradaCompleto = false;}

			Dorama novoDorama = new Dorama(id: repositorioD.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse,
										emissora: entradaEmissora,
										episodios: entradaEpisodios,
										completo: entradaCompleto);

			repositorioD.Insere(novoDorama);

			Console.WriteLine();
			Console.WriteLine("!!  DORAMA '{0}' CADASTRADO  !! ", entradaTitulo);
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
		}

		private static void AtualizarDorama() {
			var lista = repositorioD.Lista();
			if (lista.Count == 0){Vazio();return;}

			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("     -----    ATUALIZAR DORAMA    -----    ");
			Console.WriteLine();
			
			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			var dorama = repositorioD.RetornaPorId(idDorama);
			string entradaTitulo, entradaSinopse, entradaEmissora, modifica;
			int entradaGenero, entradaAno, entradaEpisodios, conta=0;
			bool entradaCompleto;

			Console.WriteLine();
			Console.Write("O TÍTULO ATUAL É '{0}'. DESEJA MODIFICAR? (S / N): ", dorama.retornaTitulo());
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME O NOVO TÍTULO: ");
				entradaTitulo = Console.ReadLine();
				conta++;
				Console.WriteLine();
			} else{entradaTitulo = dorama.retornaTitulo();}

			Console.Write("O GÊNERO ATUAL É '{0}'. DESEJA MODIFICAR? (S / N): ", Enum.GetName(typeof(Genero), dorama.retornaGenero()));
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if (modifica=="S") {
				Console.WriteLine();
				foreach (int i in Enum.GetValues(typeof(Genero))) {
					Console.WriteLine("[{0}] {1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.WriteLine();
				Console.Write("INFORME O CÓDIGO DO NOVO GÊNERO: ");
				entradaGenero = int.Parse(Console.ReadLine());
				conta++;
				Console.WriteLine();
			} else {entradaGenero = dorama.retornaGenero();}
			
			Console.Write("O ANO ATUAL DE LANÇAMENTO É '{0}'. DESEJA MODIFICAR? (S / N): ", dorama.retornaAno());
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME O NOVO ANO DE LANÇAMENTO: ");
				entradaAno = int.Parse(Console.ReadLine());
				conta++;
				Console.WriteLine();
			} else{entradaAno = dorama.retornaAno();}

			Console.WriteLine("A SINOPSE ATUAL É '{0}'.", dorama.retornaSinopse());
			Console.Write("DESEJA MODIFICAR? (S / N): ");
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME A NOVA SINOPSE: ");
				entradaSinopse = Console.ReadLine();
				Console.WriteLine();
				conta++;
			} else{entradaSinopse = dorama.retornaSinopse();}

			Console.Write("A EMISSORA ATUAL É '{0}'. DESEJA MODIFICAR? (S / N): ", dorama.retornaEmissora());
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME A NOVA EMISSORA: ");
				entradaEmissora = Console.ReadLine();
				conta++;
				Console.WriteLine();
			} else{entradaEmissora = dorama.retornaEmissora();}

			Console.Write("O NÚMERO ATUAL DE EPISÓDIOS É '{0}'. DESEJA MODIFICAR? (S / N): ", dorama.retornaEpisodio());
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME O NOVO NÚMERO DE EPISÓDIOS: ");
				entradaEpisodios = int.Parse(Console.ReadLine());
				conta++;
				Console.WriteLine();
			} else{entradaEpisodios = dorama.retornaEpisodio();}

			Console.WriteLine("O ESTADO ATUAL É '{0}'.", dorama.retornaStatus() ? "COMPLETO" : "INCOMPLETO");
			Console.Write("DESEJA MODIFICAR? (S / N): ");
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){Console.WriteLine();entradaCompleto=dorama.status(); conta++; Console.WriteLine();}
			else{entradaCompleto = dorama.retornaStatus();}

			Dorama atualizaDorama = new Dorama(id: idDorama,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse,
										emissora: entradaEmissora,
										episodios: entradaEpisodios,
										completo: entradaCompleto);

			repositorioD.Atualiza(idDorama, atualizaDorama);

			Console.WriteLine();
			if(conta>0){Console.WriteLine("!!  {0} CAMPOS ATUALIZADOS  !! ", conta);}
			else if(conta==0){Console.WriteLine("!!  NADA FOI ALTERADO !! ");}
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
		}

		private static void ExcluirDorama() {
			var lista = repositorioD.Lista();
			if (lista.Count == 0){Vazio();return;}

			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			var dorama = repositorioD.RetornaPorId(idDorama);
			
			Console.WriteLine();
			Console.WriteLine("!!  O DORAMA '{0}' SERÁ REMOVIDO  !!", dorama.retornaTitulo());
			Console.Write("DESEJA CONTINUAR? (S / N): ");
			string confirma = Console.ReadLine();

			while (confirma.ToUpper()!="N" && confirma.ToUpper()!="S"){
				Console.Write("INFORME S OU N: ");
				confirma = Console.ReadLine();
			}
			if (confirma.ToUpper()=="S"){
				repositorioD.Exclui(idDorama);
				Console.WriteLine();
				Console.WriteLine("!!  DORAMA REMOVIDO  !! ", dorama.retornaTitulo());
			}
			else if(confirma.ToUpper()=="N"){
				Console.WriteLine();
				Console.WriteLine("!!  OPERAÇÃO CANCELADA  !! ");
			}

			Console.WriteLine();
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
		}

		private static void VisualizarDorama() {
			var lista = repositorioD.Lista();
			if (lista.Count == 0){Vazio();return;}

			Console.Write("INFORME O ID DO DORAMA: ");
			int idDorama = int.Parse(Console.ReadLine());

			var dorama = repositorioD.RetornaPorId(idDorama);
			
			Console.WriteLine();
			Console.WriteLine(dorama);
			Console.WriteLine();
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
		}

		// --
		// FIM --
		// PARA DORAMAS --
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////




		//////////////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////////////////////////
		// PARA FILMES --
		// INICIO --
		// --


		 private static void ListarFilmes(){
            var lista = repositorioF.Lista();
			if (lista.Count == 0){Vazio();return;}

			Console.WriteLine("    -----    LISTA DE FILMES    -----   ");
			Console.WriteLine();
			foreach (var filme in lista) {   
				var indisponivel = filme.retornaExluido();
				//if(!indisponivel){}
				Console.WriteLine(" #{0} - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (indisponivel ? "[INDISPONÍVEL]" : ""));
			}
			Console.WriteLine();
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
        }

        private static void InserirFilme() {
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("    -----    INSERIR NOVO FILME    -----    ");
			Console.WriteLine();

			foreach (int i in Enum.GetValues(typeof(Genero))) {
				Console.WriteLine("  [{0}] {1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.WriteLine();

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

			Console.WriteLine();
			Console.WriteLine("!!  FILME '{0}' CADASTRADO  !! ", entradaTitulo);
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
		}

		private static void AtualizarFilme() {
			var lista = repositorioF.Lista();
			if (lista.Count == 0){Vazio();return;}

			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("     -----    ATUALIZAR FILME    -----    ");
			Console.WriteLine();

			Console.Write("INFORME O ID DO FILME: ");
			int idFilme = int.Parse(Console.ReadLine());

			var filme = repositorioF.RetornaPorId(idFilme);
			string entradaTitulo, entradaSinopse, modifica;
			int entradaGenero, entradaAno, entradaDuracao, conta=0;

			Console.WriteLine();
			Console.Write("O TÍTULO ATUAL É '{0}'. DESEJA MODIFICAR? (S / N): ", filme.retornaTitulo());
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME O NOVO TÍTULO: ");
				entradaTitulo = Console.ReadLine();
				conta++;
				Console.WriteLine();
			} else{entradaTitulo = filme.retornaTitulo();}

			Console.Write("O GÊNERO ATUAL É '{0}'. DESEJA MODIFICAR? (S / N): ", Enum.GetName(typeof(Genero), filme.retornaGenero()));
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if (modifica=="S") {
				Console.WriteLine();
				foreach (int i in Enum.GetValues(typeof(Genero))) {
					Console.WriteLine("[{0}] {1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.WriteLine();
				Console.Write("INFORME O CÓDIGO DO NOVO GÊNERO: ");
				entradaGenero = int.Parse(Console.ReadLine());
				conta++;
				Console.WriteLine();
			} else {entradaGenero = filme.retornaGenero();}

			Console.Write("O ANO ATUAL DE LANÇAMENTO É '{0}'. DESEJA MODIFICAR? (S / N): ", filme.retornaAno());
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME O NOVO ANO DE LANÇAMENTO: ");
				entradaAno = int.Parse(Console.ReadLine());
				conta++;
				Console.WriteLine();
			} else{entradaAno = filme.retornaAno();}

			Console.WriteLine("A SINOPSE ATUAL É '{0}'.", filme.retornaSinopse());
			Console.Write("DESEJA MODIFICAR? (S / N): ");
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME A NOVA SINOPSE: ");
				entradaSinopse = Console.ReadLine();
				Console.WriteLine();
				conta++;
			} else{entradaSinopse = filme.retornaSinopse();}

			Console.Write("A DURAÇÃO ATUAL É DE {0} MINUTOS. DESEJA MODIFICAR? (S / N): ", filme.retornaDuracao());
			modifica = Console.ReadLine().ToUpper();
			while (modifica!="N" && modifica!="S"){
				Console.Write("INFORME S OU N: ");
				modifica = Console.ReadLine().ToUpper();
			}
			if(modifica=="S"){
				Console.WriteLine();
				Console.Write("INFORME A NOVA DURAÇÃO EM MINUTOS: ");
				entradaDuracao = int.Parse(Console.ReadLine());
				conta++;
				Console.WriteLine();
			} else{entradaDuracao = filme.retornaDuracao();}

			Filme atualizaFilme = new Filme(id: idFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										sinopse: entradaSinopse,
										duracao: entradaDuracao);

			repositorioF.Atualiza(idFilme, atualizaFilme);

			Console.WriteLine();
			if(conta>0){Console.WriteLine("!!  {0} CAMPOS ATUALIZADOS  !! ", conta);}
			else if(conta==0){Console.WriteLine("!!  NADA FOI ALTERADO !! ");}
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
		}

		private static void ExcluirFilme() {
			var lista = repositorioF.Lista();
			if (lista.Count == 0){Vazio();return;}

			Console.Write("INFORME O ID DO FILME: ");
			int idFilme = int.Parse(Console.ReadLine());

			var filme = repositorioF.RetornaPorId(idFilme);
			
			Console.WriteLine();
			Console.WriteLine("!!  O FILME '{0}' SERÁ REMOVIDO  !!", filme.retornaTitulo());
			Console.Write("DESEJA CONTINUAR? (S / N): ");
			string confirma = Console.ReadLine().ToUpper();

			while (confirma!="N" && confirma!="S"){
				Console.Write("INFORME S OU N: ");
				confirma = Console.ReadLine();
			}
			if (confirma=="S"){
				repositorioF.Exclui(idFilme);
				Console.WriteLine();
				Console.WriteLine("!!  FILME REMOVIDO  !! ", filme.retornaTitulo());
			}
			else {
				Console.WriteLine();
				Console.WriteLine("!!  OPERAÇÃO CANCELADA  !! ");
			}

			Console.WriteLine();
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
		}

		private static void VisualizarFilme() {
			var lista = repositorioF.Lista();
			if (lista.Count == 0){Vazio();return;}

			Console.Write("INFORME O ID DO FILME: ");
			int idFilme = int.Parse(Console.ReadLine());

			var filme = repositorioF.RetornaPorId(idFilme);

			Console.WriteLine();
			Console.WriteLine(filme);
			Console.WriteLine();
			Console.Write("> PRESSIONE ENTER PARA RETORNAR AO MENU <");
			Console.ReadKey();
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
			Console.WriteLine("|  A - DORAMAS                   |");
			Console.WriteLine("|  B - FILMES                    |");
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

			Console.Write(">> ");
			string opcaoUserF = Console.ReadLine().ToUpper();
			return opcaoUserF;
        }
    }
}
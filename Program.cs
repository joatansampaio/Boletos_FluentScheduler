using FluentScheduler;
using GeradorDeBoletos_FluentScheduler.Boletos;

class Program {
	static void Main() {
		Console.WriteLine("Iniciando o gerador de boletos...");

		// Inicializa o FluentScheduler com os jobs
		JobManager.Initialize(new BoletoRegistry());

		Console.WriteLine("Agendador iniciado. Pressione qualquer tecla para encerrar...");
		Console.ReadKey();

		// Limpa os jobs quando o programa for encerrado
		JobManager.StopAndBlock();
	}
}
using FluentScheduler;

namespace GeradorDeBoletos_FluentScheduler.Boletos;
public class GenerateBoletoJob : IAsyncJob {

	public async Task ExecuteAsync() {
		try {
			using var boletoGenerator = new FakeBoletoGenerator();
			await boletoGenerator.GenerateBoletoAsync();
		} catch (Exception ex) {
			Console.WriteLine($"[ERRO] Ocorreu um erro ao gerar boletos: {ex.Message}");
		}
	}
}
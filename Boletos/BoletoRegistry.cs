using FluentScheduler;

namespace GeradorDeBoletos_FluentScheduler.Boletos;
public class BoletoRegistry : Registry {
	public BoletoRegistry() {

		// Configura o job para ser executado a cada 10 segundos
		Schedule<GenerateBoletoJob>()
			.NonReentrant()
			.ToRunNow()
			.AndEvery(5).Seconds();
	}
}

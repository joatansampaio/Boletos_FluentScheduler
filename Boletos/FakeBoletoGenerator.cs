namespace GeradorDeBoletos_FluentScheduler.Boletos; 
public class FakeBoletoGenerator: IDisposable {

	private static readonly Random _random = new ();
	private List<byte[]>? _memoryConsumingData = []; // Simula objetos que consomem memória (SQL Session, Loggers, etc.)

	private readonly List<string> _firstName = [
		"João", "Maria", "José", "Ana", "Pedro", "Mariana", "Carlos", "Juliana", "Lucas", "Fernanda",
		"Rafael", "Camila", "Gustavo", "Aline", "Rodrigo", "Patrícia", "Felipe", "Tatiana", "Vinícius", "Larissa"
	];

	private readonly List<string> _lastName = [
		"Silva", "Santos", "Oliveira", "Souza", "Pereira", "Ferreira", "Almeida", "Costa", "Carvalho", "Rodrigues",
		"Martins", "Rocha", "Alves", "Lima", "Gomes", "Barbosa", "Ribeiro", "Freitas", "Araújo", "Melo"
	];

	public string GetRandomName () {
		return $"{_firstName[_random.Next(0, _firstName.Count)]} {_lastName[_random.Next(0, _lastName.Count)]}";
	}

	public async Task<bool> GenerateBoletoAsync() {

		// Simula grande consumo de memória ao gerar um boleto
		await SimulateHighMemoryUsage();

		// Gerar dados falsos de um boleto
		var fakeBoleto = new FakeBoleto {
			Id = Guid.NewGuid(),
			CustomerName = GetRandomName(),
			Amount = RandomAmount(),
			DueDate = DateTime.Now.AddDays(_random.Next(5, 20)),
			BarCode = GenerateFakeBarCode()
		};

		if (_random.Next(0, 100) < 10) {
			// Simula um erro aleatório
			throw new Exception("Erro ao gerar boleto. Tentando novamente...");
		}

		// Exibir os detalhes do boleto no console
		Console.WriteLine($"[GERADO] Boleto ID: {fakeBoleto.Id}");
		Console.WriteLine($"          Cliente: {fakeBoleto.CustomerName}");
		Console.WriteLine($"          Valor: R${fakeBoleto.Amount:F2}");
		Console.WriteLine($"          Vencimento: {fakeBoleto.DueDate:dd/MM/yyyy}");
		Console.WriteLine($"          Código de Barras: {fakeBoleto.BarCode}");
		Console.WriteLine(new string('-', 50));

		return true;
	}

	private static string GenerateFakeBarCode() {
		// Gerar um código de barras falso (44 dígitos, por exemplo)
		string barCode = "";
		for (int i = 0; i < 44; i++) {
			barCode += _random.Next(0, 10);
		}
		return barCode;
	}

	private static decimal RandomAmount() {
		// Gerar um valor aleatório entre R$100,00 e R$1000,00
		return (decimal)(_random.Next(10000, 100000) / 100.0);
	}

	private async Task SimulateHighMemoryUsage() {
		Console.WriteLine("[INFO] Simulando uso intenso de memória...");

		_memoryConsumingData ??= [];
		// Adiciona blocos grandes de dados na memória para simular alto consumo
		for (int i = 0; i < 10; i++) {
			// Simulando um pequeno atraso de processamento só pra usarmos o async/await
			await Task.Delay(20);
			_memoryConsumingData.Add(new byte[10 * 1024 * 2048]); // 20MB de dados por bloco
		}

		Console.WriteLine("[INFO] Uso de memória simulado com sucesso.");
	}

	void IDisposable.Dispose() {
		Console.WriteLine("[INFO] Liberando recursos de memória...");

		// Libera os objetos pesados da memória
		_memoryConsumingData?.Clear();
		_memoryConsumingData = null;

		// Atenção: Não é recomendado chamar o GC manualmente em produção
		// Só coloquei aqui pra caso você inspecione o consumo de memória com os Diagnostic Tools do VS
		// Vai ficar mais fácil ver a memória sendo liberada
		GC.SuppressFinalize(this);
		GC.Collect();
		GC.WaitForPendingFinalizers();

		Console.WriteLine("[INFO] Recursos liberados com sucesso.");
	}
}

public class FakeBoleto {
	public required Guid Id { get; set; }
	public required string CustomerName { get; set; }
	public required decimal Amount { get; set; }
	public required DateTime DueDate { get; set; }
	public required string BarCode { get; set; }
}

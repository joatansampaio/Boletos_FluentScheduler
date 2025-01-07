# Gerador de Boletos com Fluent Scheduler

Este projeto foi criado para ajudar um amigo com uma dúvida sobre o uso do [FluentScheduler](https://github.com/fluentscheduler/FluentScheduler), uma biblioteca de agendamento de tarefas em .NET. O objetivo foi identificar e resolver problemas de consumo elevado de memória em um projeto que simula a geração de boletos.

## 📚 Sobre o Projeto

O projeto utiliza o FluentScheduler para agendar tarefas que simulam a geração de boletos fictícios. Durante a execução, o sistema consome memória para representar operações mais complexas, como manipulação de grandes blocos de dados (exemplo fictício de uso pesado).

### Principais Aspectos Abordados:
- **Uso do FluentScheduler**: Configuração e execução de tarefas recorrentes.
- **Simulação de Consumo de Memória**: Implementação de um gerador fictício de boletos com alto consumo de memória para fins de simulação e diagnóstico.
- **Gerenciamento de Recursos**: Uso correto do padrão `IDisposable` para liberar memória e recursos de forma eficaz.
- **Integração de Código Assíncrono**: Soluções para lidar com métodos `async` em um ambiente síncrono como o FluentScheduler.

## 🚀 Funcionalidades

- Agendamento periódico de tarefas que simulam a geração de boletos.
- Geração de boletos com informações aleatórias, incluindo nome, valor, e código de barras.
- Logs no console para acompanhar a execução e detectar possíveis problemas.

## 🛠️ Tecnologias Utilizadas

- **C#** (Linguagem principal)
- **.NET** (Framework de desenvolvimento)
- **FluentScheduler** (Biblioteca de agendamento)

## 📂 Estrutura do Projeto

```plaintext
GeradorDeBoletos_FluentScheduler/
├── Boletos/
│   ├── BoletoRegistry.cs      // Configuração do FluentScheduler
│   ├── FakeBoletoGenerator.cs // Simulação de gerador de boletos
│   ├── GenerateBoletoJob.cs   // Definição do job de geração de boletos
├── Program.cs                 // Inicialização do FluentScheduler
└── README.md                  // Este arquivo



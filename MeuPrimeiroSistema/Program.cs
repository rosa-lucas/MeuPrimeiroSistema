    Console.WriteLine(@"
====================================================================
    ██████╗ ███████╗██████╗ 
    ██╔══██╗██╔════╝██╔══██╗  PRONTUÁRIO ELETRÔNICO DO PACIENTE
    ██████╔╝█████╗  ██████╔╝  Módulo de Atendimento Clínico
    ██╔═══╝ ██╔══╝  ██╔═══╝   Versão 1.0
    ██║     ███████╗██║     
    ╚═╝     ╚══════╝╚═╝     
====================================================================
");

    Console.Write("Digite o nome do paciente: ");
    var nome = Console.ReadLine();
    while (string.IsNullOrEmpty(nome)) {
        Console.Write("Nome inválido. Digite novamente: ");
        nome = Console.ReadLine();
    }

    DateTime dataNascimento;
    int idade;
    Console.Write("Digite a data de nascimento do paciente (DD/MM/AAAA): ");
    while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento) || dataNascimento >= DateTime.Today)
        Console.Write("Data inválida. Digite novamente (DD/MM/AAAA): ");

    char sexo;
    Console.Write("Digite o sexo biológico do paciente (M/F): ");
    while (!char.TryParse(Console.ReadLine(), out sexo) || (sexo != 'F' && sexo != 'f' && sexo != 'M' && sexo != 'm'))
        Console.Write("Sexo inválido. Digite novamente (M/F): ");

    Console.Write("Digite o peso do paciente (ex.: 70,5): ");
    double peso;
    while (!double.TryParse(Console.ReadLine(), out peso) || peso <= 0)
        Console.Write("Peso inválido. Digite novamente (ex.: 70,5): ");

    Console.Write("Digite a altura do paciente (ex.: 1,75): ");
    double altura;
    while (!double.TryParse(Console.ReadLine(), out altura) || altura <= 0 || altura >= 4)
        Console.Write("Altura inválida. Digite novamente (ex.: 1,75): ");
        
    bool temPlanoDeSaude;
    Console.Write("Possui plano de saúde (sim/não)?: ");
    var leitura = Console.ReadLine();
    while (leitura != "sim" && leitura != "s" && leitura != "não" && leitura != "nao" && leitura != "n") {
        Console.Write("Entrada inválida. Digite novamente (sim/não): ");
        leitura = Console.ReadLine();
    }
    temPlanoDeSaude = leitura == "s" || leitura == "sim";

    Console.Write("Digite o valor base da consulta (R$ ex.: 199,99): ");
    decimal valorBaseConsulta;
    while (!decimal.TryParse(Console.ReadLine(), out valorBaseConsulta) || valorBaseConsulta <= 0)
        Console.Write("Valor inválido. Digite novamente (ex.: 199,99): ");
    
    idade = DateTime.Today.Year - dataNascimento.Year;
    double imc = peso / (altura * altura);
    var valorTotal = temPlanoDeSaude ? valorBaseConsulta * 0.85m : valorBaseConsulta;
    

    Console.WriteLine();
    Console.WriteLine("                     RESUMO DO ATENDIMENTO CLÍNICO                  ");
    Console.WriteLine("====================================================================");
    Console.WriteLine();

    Console.WriteLine("DADOS DO PACIENTE");
    Console.WriteLine("--------------------------------------------------------------------");
    Console.WriteLine($"Nome do Paciente............: {nome}");
    Console.WriteLine($"Data de Nascimento..........: {dataNascimento:dd/MM/yyyy}");
    Console.WriteLine($"Idade Calculada.............: {idade} anos");
    Console.WriteLine($"Sexo Biológico..............: {sexo}");
    Console.WriteLine($"Possui Plano de Saúde.......: {(temPlanoDeSaude ? "Sim" : "Não")}");
    Console.WriteLine();

    Console.WriteLine("MEDIÇÕES E INDICADORES DE SAÚDE");
    Console.WriteLine("--------------------------------------------------------------------");
    Console.WriteLine($"Peso Corporal...............: {peso:F2} kg");
    Console.WriteLine($"Altura......................: {altura:F2} m");
    Console.WriteLine($"Índice de Massa Corporal....: {imc:F2}");
    Console.WriteLine();

    Console.WriteLine("DETALHES FINANCEIROS DA CONSULTA");
    Console.WriteLine("--------------------------------------------------------------------");
    Console.WriteLine($"Valor Base da Consulta......: {valorBaseConsulta:C2}");
    Console.WriteLine($"Valor Final a Pagar.........: {valorTotal:C2}");
    Console.WriteLine();

    Console.WriteLine("--------------------------------------------------------------------");
    Console.WriteLine($"Registro Efetuado em........: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
    Console.WriteLine($"Status do Cadastro..........: Concluído com Sucesso");
    Console.WriteLine("====================================================================");
using System;

using System.Threading;

 

class Program

{

    static void Main(string[] args)

    {

        Console.WriteLine("Iniciando Simulador!");

        Thread.Sleep(2000);

 

        // Inicializando Computador A

        var computadorA = new Computador("Computador A", "aa:aa:aa:aa:aa", "192.168.0.100");

 

        // Inicializando Computador B

        var computadorB = new Computador("Computador B", "bb:bb:bb:bb:bb", "192.168.0.200");

 

        // Inicializando Computador C

        var computadorC = new Computador("Computador C", "cc:cc:cc:cc:cc", "192.168.0.300");

 

        while (true)

        {

            Console.WriteLine("Selecione uma opção:");

            Console.WriteLine("1. Enviar mensagem do Computador A");

            Console.WriteLine("2. Enviar mensagem do Computador B");

            Console.WriteLine("3. Enviar mensagem do Computador C");

            Console.WriteLine("0. Sair");

            Console.Write("Opção selecionada: ");

 

            int opcao;

            if (int.TryParse(Console.ReadLine(), out opcao))

            {

                Console.WriteLine();

 

                switch (opcao)

                {

                    case 0:

                        Console.WriteLine("Encerrando o programa...");

                        return;

 

                    case 1:

                        Console.WriteLine("Computador A");

                        Thread.Sleep(2000);

                        Console.Write("Entre com a Mensagem: ");

                        string mensagemA = Console.ReadLine();

                        Console.WriteLine();

                        Console.WriteLine("Selecione o Meio de Transmissão:");

                        Console.WriteLine("1. Meio de Transmissão Cabo Ethernet");

                        Console.WriteLine("2. Meio de Transmissão Wi-Fi");

                        Console.Write("Opção selecionada: ");

                        int meioA = int.Parse(Console.ReadLine());

                        Console.WriteLine();

 

                        if (meioA == 1)

                        {

                            Console.WriteLine("Computador A (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.Write("Aplicação -> ");

                            computadorA.EnviarMensagem(mensagemA, computadorB, MeioTransmissao.CaboEthernet);

                            Console.WriteLine();

                            Console.WriteLine("Computador B (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.WriteLine("Mensagem Recebida: " + computadorB.MensagemRecebida);

                        }

                        else if (meioA == 2)

                        {

                            Console.WriteLine("Computador A (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.Write("Aplicação -> ");

                            computadorA.EnviarMensagem(mensagemA, computadorB, MeioTransmissao.WiFi);

                            Console.WriteLine();

                            Console.WriteLine("Computador B (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.WriteLine("Mensagem Recebida: " + computadorB.MensagemRecebida);

                        }

                        else

                        {

                            Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");

                        }

 

                        Console.WriteLine();

                        break;

 

                    case 2:

                        Console.WriteLine("Computador B");

                        Thread.Sleep(2000);

                        Console.Write("Entre com a Mensagem: ");

                        string mensagemB = Console.ReadLine();

                        Console.WriteLine();

                        Console.WriteLine("Selecione o Meio de Transmissão:");

                        Console.WriteLine("1. Meio de Transmissão Cabo Ethernet");

                        Console.WriteLine("2. Meio de Transmissão Wi-Fi");

                        Console.Write("Opção selecionada: ");

                        int meioB = int.Parse(Console.ReadLine());

                        Console.WriteLine();

 

                        if (meioB == 1)

                        {

                            Console.WriteLine("Computador B (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.Write("Aplicação -> ");

                            computadorB.EnviarMensagem(mensagemB, computadorA, MeioTransmissao.CaboEthernet);

                            Console.WriteLine();

                            Console.WriteLine("Computador A (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.WriteLine("Mensagem Recebida: " + computadorA.MensagemRecebida);

                        }

                        else if (meioB == 2)

                        {

                            Console.WriteLine("Computador B (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.Write("Aplicação -> ");

                            computadorB.EnviarMensagem(mensagemB, computadorA, MeioTransmissao.WiFi);

                            Console.WriteLine();

                            Console.WriteLine("Computador A (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.WriteLine("Mensagem Recebida: " + computadorA.MensagemRecebida);

                        }

                        else

                        {

                            Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");

                        }

 

                        Console.WriteLine();

                        break;

 

                    case 3:

                        Console.WriteLine("Computador C");

                        Thread.Sleep(2000);

                        Console.Write("Entre com a Mensagem: ");

                        string mensagemC = Console.ReadLine();

                        Console.WriteLine();

                        Console.WriteLine("Selecione o Meio de Transmissão:");

                        Console.WriteLine("1. Meio de Transmissão Cabo Ethernet");

                        Console.WriteLine("2. Meio de Transmissão Wi-Fi");

                        Console.Write("Opção selecionada: ");

                        int meioC = int.Parse(Console.ReadLine());

                        Console.WriteLine();

 

                        if (meioC == 1)

                        {

                            Console.WriteLine("Computador C (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.Write("Aplicação -> ");

                            computadorC.EnviarMensagem(mensagemC, computadorA, MeioTransmissao.CaboEthernet);

                            Console.WriteLine();

                            Console.WriteLine("Computador A (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.WriteLine("Mensagem Recebida: " + computadorA.MensagemRecebida);

                        }

                        else if (meioC == 2)

                        {

                            Console.WriteLine("Computador C (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.Write("Aplicação -> ");

                            computadorC.EnviarMensagem(mensagemC, computadorA, MeioTransmissao.WiFi);

                            Console.WriteLine();

                            Console.WriteLine("Computador A (Camada de Aplicação)");

                            Thread.Sleep(2000);

                            Console.WriteLine("Mensagem Recebida: " + computadorA.MensagemRecebida);

                        }

                        else

                        {

                            Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");

                        }

 

                        Console.WriteLine();

                        break;

 

                    default:

                        Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");

                        Console.WriteLine();

                        break;

                }

            }

            else

            {

                Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");

                Console.WriteLine();

            }

        }

    }

}

 

class Computador

{

    public string Nome { get; }

    public string EndMAC { get; }

    public string EndIP { get; }

    public string MensagemRecebida { get; private set; }

 

    public Computador(string nome, string endMAC, string endIP)

    {

        Nome = nome;

        EndMAC = endMAC;

        EndIP = endIP;

    }

 

    public void EnviarMensagem(string mensagem, Computador destino, MeioTransmissao meioTransmissao)

    {

        Console.WriteLine("Camada de Aplicação -> Camada de Transporte -> Camada de Rede -> Camada de Enlace");

        Thread.Sleep(2000);

 

        Console.WriteLine("Enviando mensagem de {0} para {1}: {2}", Nome, destino.Nome, mensagem);

        Thread.Sleep(2000);

 

        // Simulando os meios físicos

        if (meioTransmissao == MeioTransmissao.CaboEthernet)

        {

            Console.WriteLine("Transmissão através de Cabo Ethernet");

            Thread.Sleep(2000);

        }

        else if (meioTransmissao == MeioTransmissao.WiFi)

        {

            Console.WriteLine("Transmissão através de Wi-Fi");

            Thread.Sleep(2000);

        }

 

        Console.WriteLine("Destino -> Camada de Enlace -> Camada de Rede -> Camada de Transporte -> Camada de Aplicação");

        destino.ReceberMensagem(mensagem);

    }

 

    private void ReceberMensagem(string mensagem)

    {

        Console.WriteLine("Recebendo mensagem em {0}: {1}", Nome, mensagem);

        Thread.Sleep(2000);

 

        MensagemRecebida = mensagem;

    }

}

 

enum MeioTransmissao

{

    CaboEthernet,

    WiFi

}
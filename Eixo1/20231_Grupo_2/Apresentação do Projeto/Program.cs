﻿using System;
using System.Threading;


namespace Classes
{

    static class MeioFisico
    {
        public static Computador Comp1 = new Computador();
        public static Computador Comp2 = new Computador();
        public static Computador Comp3 = new Computador();
        public static Computador Comp4 = new Computador();
    
        public static void Send(Computador.Enlace pdu_enlace) {
            Thread.Sleep(1000);
            Console.WriteLine("Meio Fisico");
            
            if (pdu_enlace.MACdest == Comp1.EndMAC) {
                Console.WriteLine("Computador " + Comp1.nome);
                Comp1.enlace.Receive(pdu_enlace);
            }
            else if (pdu_enlace.MACdest == Comp2.EndMAC) {
                Console.WriteLine("Computador " + Comp2.nome);
                Comp2.enlace.Receive(pdu_enlace);
            }
            else if (pdu_enlace.MACdest == Comp3.EndMAC) {
                Console.WriteLine("Computador " + Comp3.nome);
                Comp3.enlace.Receive(pdu_enlace);
            }
            else if (pdu_enlace.MACdest == Comp4.EndMAC) {
                Console.WriteLine("Computador " + Comp4.nome);
                Comp4.enlace.Receive(pdu_enlace);
            }
        }

        public static string GetMacAddress(string IPDest) {
            if (IPDest == "192.168.0.100")
              return "aa:aa:aa:aa:aa:aa";
            if (IPDest == "192.168.0.200")
              return "bb:bb:bb:bb:bb:bb";
            if (IPDest == "192.168.0.300")
              return "cc:cc:cc:cc:cc:cc";
            if (IPDest == "192.168.0.400")
              return "dd:dd:dd:dd:dd:dd";  
            else return "00:00:00:00:00:00";  
        }

        public static string GetIPAddress(string Name) {
            if (Name == "A")
              return "192.168.0.100";
            if (Name == "B")
              return "192.168.0.200";
            if (Name == "C")
              return "192.168.0.300";
            if (Name == "D")
              return "192.168.0.400";
            else return "000.000.000.000";  
        }
    }

    class Computador 
    {
        public string nome = "sem nome";
        public string EndMAC = "00:00:00:00:00:00";
        public string EndIP = "000.000.000";
        public string IPDest = "000.000.000";
  
        public Aplicacao aplicacao = new Aplicacao();
        public Transporte transporte = new Transporte();
        public Rede rede = new Rede();
        public Enlace enlace = new Enlace();

        public void Executa() {
            
            Console.WriteLine("De Computador " + EndIP + " para Computador " + IPDest);

            Console.WriteLine("Entre com  a mensagem: ");
            Aplicacao aplicacao = new Aplicacao();
            aplicacao.dado = Console.ReadLine() + "";
            Thread.Sleep(1000);
            Console.WriteLine("Computador " + nome);
            aplicacao.Send(IPDest);
        }
        public class Enlace
        {   
            // cabeçalho
            public string MACdest = "";
            public string MACorig = "";
            // dado
            public Rede dado = new Rede();
            public void Send()
            {
               
                this.MACdest = MeioFisico.GetMacAddress(this.dado.IPdest);
                Thread.Sleep(1000);
                Console.Write("Send-Enlace -> ");
                MeioFisico.Send(this);
            }
            public void Receive(Enlace pdu_enlace) 
            {               
                Thread.Sleep(1000);            
                Console.Write("Receive-Enlace -> ");
                var servico_rede = new Rede();
                servico_rede.Receive(pdu_enlace.dado);	            
            }                
        }
        public class Rede
        {
            public string ProtocoloIP = "";
            public string IPdest = "";
            public string IPorig = "";
            public Transporte dado = new Transporte();
            public void Send() 
            {            
                Thread.Sleep(1000);
                this.ProtocoloIP = "IPV4";
                Console.Write("Send-Rede -> ");
                var pdu_enlace = new Enlace();
                pdu_enlace.dado = this;
                pdu_enlace.Send();        
            }            
            public void Receive(Rede pdu_rede) 
            {               
                Thread.Sleep(1000);
                Console.Write("Receive-Rede -> ");
                var servico_transporte = new Transporte();
                servico_transporte.Receive(pdu_rede.dado);	            		        
            } 
        }
        public class Transporte
        {
            public static readonly int TCP = 1;
            public static readonly int UDP = 2;
            public int Protocolo;
            public int porta_origem;
            public int porta_destino;
            public string dado="";
            
            public void Send(string IPdest) 
            {
                Thread.Sleep(1000);
                this.Protocolo = Transporte.UDP;
                this.porta_origem = 8080;
                this.porta_destino = 100;  // porta de serviço 
                Console.Write("Send-Transporte -> ");
                var pdu_rede = new Rede();
                pdu_rede.IPdest = IPdest;
                pdu_rede.dado = this;
                pdu_rede.Send();
            }
            public void Receive(Transporte pdu_transporte) 
            {     
                Thread.Sleep(1000);
                Console.Write("Receive-Transporte -> ");
                var servico_aplicacao = new Aplicacao();
                servico_aplicacao.Receive(pdu_transporte.dado);          
            }
        }
        public class Aplicacao
        {
            public string dado="";       
            public void Send(string IPDest) 
            {
                Thread.Sleep(1000);
                Console.Write(dado + " -> " + "Send-Aplicação -> ");
                var transporte = new Transporte();
                transporte.dado = dado;
                transporte.Send(IPDest);	
                
            }
            public void Receive(string dado) 
            {     
                Console.Write("Receive-Aplicação -> ");
                Console.WriteLine(dado);
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // Inicializando Computador 1
            var computador1 = new Computador();
            computador1.nome = "A";
            computador1.EndMAC = "aa:aa:aa:aa:aa:aa";
            computador1.EndIP = "192.168.0.100";

            // Inicializando Computador 2
            var computador2 = new Computador();
            computador2.nome = "B";
            computador2.EndMAC = "bb:bb:bb:bb:bb:bb";
            computador2.EndIP = "192.168.0.200";

            // Inicializando Computador 3
            var computador3 = new Computador();
            computador3.nome = "C";
            computador3.EndMAC = "cc:cc:cc:cc:cc:cc";
            computador3.EndIP = "192.168.0.300";

            // Inicializando Computador 4
            var computador4 = new Computador();
            computador4.nome = "D";
            computador4.EndMAC = "dd:dd:dd:dd:dd:dd";
            computador4.EndIP = "192.168.0.400";

            // Estabelecendo conexão física entre as máquinas
            MeioFisico.Comp1 = computador1;
            MeioFisico.Comp2 = computador2;
            MeioFisico.Comp3 = computador3;
            MeioFisico.Comp4 = computador4;


            // Inicializando Simulação
            Console.WriteLine("Iniciando Simulador!!");
            Thread.Sleep(1000);

            string Origem = "A";
            string Destino = "C";
 
            Console.WriteLine("Computador "+ Origem + " para Computador " + Destino);
            
            if (Origem == "A") {
              computador1.IPDest = MeioFisico.GetIPAddress(Destino);  
              computador1.Executa();
            }  
            else if (Origem == "B") {
              computador2.IPDest = MeioFisico.GetIPAddress(Destino);  
              computador2.Executa();
            }  
            else if (Origem == "C") {
              computador3.IPDest = MeioFisico.GetIPAddress(Destino);  
              computador3.Executa();
            }  
            else if (Origem == "D") {
              computador4.IPDest = MeioFisico.GetIPAddress(Destino);  
              computador4.Executa();
            }  

            Console.WriteLine("Transmissão do dado bem-sucedida. Aperte enter para sair.");
            Console.ReadLine();

        }    
    }    
}
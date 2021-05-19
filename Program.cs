using System;
using System.Collections.Generic;

namespace GameConsoleBalanceado
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Personagens personagem1 = new Personagens();
            personagem1.nome = "Thanos";
            personagem1.idade = 1009;
            personagem1.destreza = 20;
            personagem1.forca = 100;
            personagem1.poder = 80;
            personagem1.defesa = 80;
            personagem1.vida = 1000;

            Personagens personagem2 = new Personagens();
            personagem2.nome = "Tony Stark";
            personagem2.idade = 53;
            personagem2.destreza = 60;
            personagem2.forca = 68;
            personagem2.poder = 80;
            personagem2.defesa = 75;
            personagem2.vida = 800;

            Personagens personagem3 = new Personagens();
            personagem3.nome = "Barry Allen";
            personagem3.idade = 23;
            personagem3.destreza = 100;
            personagem3.forca = 60;
            personagem3.poder = 100;
            personagem3.defesa = 65;
            personagem3.vida = 850;

            List<Personagens> pLista = new List<Personagens>();
            pLista.Add(personagem1);
            pLista.Add(personagem2);
            pLista.Add(personagem3);

            string continuar;
            do
            {
                Console.WriteLine("Escolha seu personagem");
                int c = 1;
                foreach (var personagem in pLista)
                {
                    Console.WriteLine($"{c}º {personagem.nome} [{c}]");
                    c++;
                }
                Console.Write("-> ");
                int pEsc = int.Parse(Console.ReadLine());
                pEsc = pEsc-1;
                int pMaq = pEsc;
                do
                {
                    pMaq = random.Next(3);
                } while (pMaq == pEsc);

                //LUTA

                string seuNome = pLista[pEsc].nome;
                string maqNome = pLista[pMaq].nome;

                Console.WriteLine($"A batalha será: {seuNome} VS {maqNome}");

                int atacar = 1;
                int defender = 2;
                int esquivar = 3;

                int suaVida = pLista[pEsc].vida;
                int seuAtaque = pLista[pEsc].Atacar();
                int suaDefesa = pLista[pEsc].Defender();
                int suaDestreza = pLista[pEsc].Esquivar();
                
                int maqVida = pLista[pMaq].vida;
                int maqAtaque = pLista[pMaq].Atacar();
                int maqDefesa = pLista[pMaq].Defender();
                int maqDestreza = pLista[pMaq].Esquivar();
                bool vida = true;

                do
                {
                    Console.Write("Escolha sua opção\nAtacar [1]\nDefender [2]\nEsquivar[3]\n-> ");
                    int opcao = int.Parse(Console.ReadLine());
                    int opcaoMaquina = random.Next(1,4);

                    //atacar
                    if (opcao == atacar && opcaoMaquina == atacar) {
                        suaVida = suaVida - maqAtaque; //Personagem escolhido toma dano de ataque
                        maqVida = maqVida - seuAtaque; //Personagem da maquina toma dano de ataque

                        Console.WriteLine($"\nVocê atacou {maqNome} e deu {seuAtaque} de dano");
                        Console.WriteLine($"{maqNome} te atacou e deu {maqAtaque} de dano\n");
                    }
                    else if (opcao == atacar && opcaoMaquina == defender) {
                        int dano = seuAtaque - maqDefesa; //Dano se torma o ataque do p1 menos a defesa do p2
                        maqVida = maqVida - dano; // Personagem da maquina toma dano

                        Console.WriteLine($"\nVocê atacou {maqNome} e {maqNome} defendeu");
                        Console.WriteLine($"Seu ataque foi mais forte e deu {dano} de dano\n");
                    }
                    else if (opcao == atacar && opcaoMaquina == esquivar) {
                        suaVida = suaVida - maqDestreza;

                        Console.WriteLine($"\n{maqNome} esquivou do seu ataque e te deu {maqDestreza} de dano\n");
                    }

                    //defender
                    else if (opcao == defender && opcaoMaquina == atacar) {
                        int dano = maqAtaque - suaDefesa;
                        suaVida = suaVida - dano;

                        Console.WriteLine($"\n{maqNome} atacou e você defendeu");
                        Console.WriteLine($"O ataque de {maqNome} foi mais forte e deu {dano} de dano\n");
                    }
                    else if (opcao == defender && opcaoMaquina == defender) {
                        Console.WriteLine("Os dois defenderam... Vocês estão com MEDO?");
                    }
                    else if (opcao == defender && opcaoMaquina == esquivar) {
                        int dano = seuAtaque - maqDefesa;
                        maqVida = maqVida - dano;
                        Console.WriteLine($"\n{maqNome} esquivou do nada e levou {dano} de dano\n");
                    }
                    //esquivar
                    else if (opcao == esquivar && opcaoMaquina == atacar) {
                        maqVida = maqVida - suaDestreza;
                        Console.WriteLine($"\nVocê esquivou do ataque de {maqNome}\nE deu {suaDestreza} de dano\n");
                    }
                    else if (opcao == esquivar && opcaoMaquina == defender) {
                        int dano = maqAtaque - suaDefesa;
                        suaVida = suaVida - dano;
                        Console.WriteLine($"{maqNome} não te atacou e você esquivou... Acho que tem alguem em shock");
                        Console.WriteLine($"Você levou {dano} de dano");
                    }
                    else if (opcao == esquivar && opcaoMaquina == esquivar) {
                        Console.WriteLine("Os dois esquivaram... Estão esquivando do que? Sinto o cheiro de MEDO!");
                    }
                    if (suaVida <= 0) {
                        Console.WriteLine($"\nVocê perdeu para {maqNome}\n");
                        vida = false;
                    } else {
                        Console.WriteLine($"Vida {seuNome}: {suaVida}");
                    }
                    if (maqVida <= 0) {
                        Console.WriteLine($"\nVocê derrotou {maqNome}\n");
                        vida = false;
                    } else {
                        Console.WriteLine($"Vida {maqNome}: {maqVida}\n\n");
                    }

                } while (vida);
                Console.WriteLine("Deseja jogar novamente? (S/N)");
                continuar = Console.ReadLine().ToLower().Substring(0,1);
            } while (continuar == "s");
            Console.WriteLine("Obrigado por jogar.");
        }
    }
}
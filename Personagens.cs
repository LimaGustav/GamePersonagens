namespace GameConsoleBalanceado
{
    public class Personagens
    {
        public string nome;
        public int idade;
        public int destreza; //0 A 100
        public int forca; //0 A 100
        public int poder; //0 A 100
        public int defesa;//0 A 100
        public int vida;//0 A 1000

        public int Atacar(){
            return forca + poder;
        }

        public int Defender(){
            return defesa;
        }

        public int Esquivar(){
            return destreza;
        }
    }
}
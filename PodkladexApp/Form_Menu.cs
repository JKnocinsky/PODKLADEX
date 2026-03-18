namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        Pokemon pokemon1;
        Pokemon pokemon2;
        Pokemon pokemon10;

        Pokemon pokemon5;
        public Form_Menu()
        {
            InitializeComponent();
            pokemon1 = new Pokemon();
            pokemon5 = new Pokemon("Charmander", "Ogieñ");

            pokemon5.WydajDzwiek("Aaaaaaaaaa!");
            pokemon5.Atak_pokemona("P³omieñ");
            pokemon1.WydajDzwiek("Pika Pika!");
            pokemon1.Atak_pokemona("Piorun");

            pokemon2 = new Pokemon("Scizor","Stalowy/Robak");
            pokemon2.Atak_pokemona("X-no¿yce");
            pokemon2.WydajDzwiek("Siiizor");

            pokemon10 = new Pokemon("Krabby", "Woda");
            pokemon10.WydajDzwiek("Ploom Ploom");
            pokemon10.Atak_pokemona("Water Gun");



        }
    }
}

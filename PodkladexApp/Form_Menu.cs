namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        Pokemon pokemon1;
        Pokemon pokemon2;
        Pokemon pokemon3;
        Pokemon pokemon10;

        public Form_Menu()
        {
            InitializeComponent();
            pokemon1 = new Pokemon();
            pokemon3 = new Pokemon("Blastoise","Wodny");

            pokemon1.WydajDzwiek("Pika Pika!");

            pokemon3.WydajDzwiek("Plum Plum");
            pokemon3.Atak_pokemona("Mega Wyrzutnia");
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

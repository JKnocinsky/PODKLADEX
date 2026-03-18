namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        Pokemon pokemon1;
        Pokemon pokemon2;
        Pokemon pokemon3;
        Pokemon pokemon10;
        Pokemon pokemon4;
        Pokemon pokemon5;
        Pokemon pokemon6;
        Pokemon pokemon7;

        public Form_Menu()
        {
            InitializeComponent();
            pokemon1 = new Pokemon();
            pokemon3 = new Pokemon("Blastoise","Wodny");
            pokemon5 = new Pokemon("Charmander", "Ogieñ");

            pokemon5.WydajDzwiek("Aaaaaaaaaa!");
            pokemon5.Atak_pokemona("P³omieñ");
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



            pokemon7 = new Pokemon("Bulbasaur", "Trawiasty", "Heteroseksualny", "Ateista", "Centrolewicowy");
            pokemon4 = new Pokemon("Magikarp", "Wodny", "Biseksualny", "Ateista", "Centroprawicowy");
            pokemon5 = new Pokemon("Charizard", "Ognisty/Lataj¹cy", "Heteroseksualny", "Ateista", "Centroprawicowy");
            pokemon6 = new Pokemon( "Squirtle", "Wodny", "Heteroseksualny", "Ateista", "Centrolewicowy");

            List<Pokemon> pokemony = new List<Pokemon> { pokemon1, pokemon2, pokemon3, pokemon4, pokemon5, pokemon6, pokemon7, pokemon10 };

            comboBox1.DataSource = pokemony;
        }
    }
}

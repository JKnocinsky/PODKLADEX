namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        Pokemon pokemon1;
        Pokemon pokemon2;
        Pokemon pokemon3;
        Pokemon pokemon4;
        Pokemon pokemon5;
        Pokemon pokemon6;

        public Form_Menu()
        {
            InitializeComponent();
            pokemon1 = new Pokemon();

            pokemon1.WydajDzwiek("Pika Pika!");
            pokemon1.Atak_pokemona("Piorun");

            pokemon3 = new Pokemon("Bulbasaur", "Trawiasty", "Heteroseksualny", "Ateista", "Centrolewicowy");
            pokemon4 = new Pokemon("Magikarp", "Wodny", "Biseksualny", "Ateista", "Centroprawicowy");
            pokemon5 = new Pokemon("Charizard", "Ognisty/Lataj¹cy", "Heteroseksualny", "Ateista", "Centroprawicowy");
            pokemon6 = new Pokemon( "Squirtle", "Wodny", "Heteroseksualny", "Ateista", "Centrolewicowy");

        }
    }
}

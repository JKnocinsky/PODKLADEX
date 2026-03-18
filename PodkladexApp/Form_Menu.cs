namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        Pokemon pokemon1;
        Pokemon pokemon2;
        public Form_Menu()
        {
            InitializeComponent();
            pokemon1 = new Pokemon();
            pokemon2 = new Pokemon("Blastoise","Wodny");

            pokemon1.WydajDzwiek("Pika Pika!");

            pokemon2.WydajDzwiek("Plum Plum");

            pokemon1.Atak_pokemona("Piorun");

            pokemon2.Atak_pokemona("Mega Wyrzutnia");

        }
    }
}

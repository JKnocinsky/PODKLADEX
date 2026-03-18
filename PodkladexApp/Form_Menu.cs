namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        Pokemon pokemon1;
        Pokemon pokemon10;

        public Form_Menu()
        {
            InitializeComponent();
            pokemon1 = new Pokemon();

            pokemon1.WydajDzwiek("Pika Pika!");
            pokemon1.Atak_pokemona("Piorun");

            pokemon10 = new Pokemon("Krabby", "Woda");
            pokemon10.WydajDzwiek("ploom ploom");
            pokemon10.Atak_pokemona("*");



        }
    }
}

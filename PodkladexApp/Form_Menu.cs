namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        Pokemon pokemon1;
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

        }
    }
}

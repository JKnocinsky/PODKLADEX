namespace PodkladexApp
{
    public partial class Form_Menu : Form
    {
        Pokemon pokemon1;

        public Form_Menu()
        {
            InitializeComponent();
            pokemon1 = new Pokemon();

            pokemon1.WydajDzwiek("Pika Pika!");
            pokemon1.Atak_pokemona("Piorun");
        }
    }
}

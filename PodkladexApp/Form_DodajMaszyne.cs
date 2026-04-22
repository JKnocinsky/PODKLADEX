using PodkladexApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodkladexApp
{
    public partial class Form_DodajMaszyne : Form
    {
        PodkladexContext context;
        int btn;

        //public Form_DodajMaszyne()
        //{
        //    InitializeComponent();
        //}

        public Form_DodajMaszyne(PodkladexContext context, string Nazwa, Maszyna maszyna)
        {
            InitializeComponent();
            Maszyna nowaMaszyna = new Maszyna();
        }

        public Form_DodajMaszyne(PodkladexContext context, string buttonName)
        {
            InitializeComponent();
        }

        private void btn_funkcja_Click(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.WinForms;

namespace PodkladexApp
{
    public partial class Form_Wykres : Form
    {
        public Form_Wykres()
        {
            InitializeComponent();

            var plt = new FormsPlot();
            plt.Dock = DockStyle.Fill;
            Controls.Add(plt);

            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 10, 25, 18, 30 };
            plt.Plot.Add.Scatter(xs, ys);
            plt.Plot.Title("Przykładowy wykres");
            plt.Refresh();
        }
    }
}

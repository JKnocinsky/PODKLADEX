using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace PodkladexApp
{
    public partial class Form_Wykres : Form
    {
        public Form_Wykres()
        {
            InitializeComponent();
            Chart chart = CreateBasicChart();
            this.Controls.Add(chart);
            
        }


    private Chart CreateBasicChart()
    {
        // Utworzenie kontrolki
        Chart chart = new Chart();

        // 📐 Wymiary i pozycja
        chart.Width = 600;
        chart.Height = 400;
        chart.Left = 10;
        chart.Top = 10;

        // (opcjonalnie zamiast powyższego)
        // chart.Dock = DockStyle.Fill;

        // 🎨 Wygląd ogólny
        chart.BackColor = Color.WhiteSmoke;
        chart.BorderlineDashStyle = ChartDashStyle.Solid;
        chart.BorderlineColor = Color.Gray;
        chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

        // 📍 Obszar wykresu
        ChartArea area = new ChartArea("MainArea");

        // Osie
        area.AxisX.Title = "X";
        area.AxisY.Title = "Y";

        area.AxisX.MajorGrid.LineColor = Color.LightGray;
        area.AxisY.MajorGrid.LineColor = Color.LightGray;

        area.AxisX.Interval = 1;

        chart.ChartAreas.Add(area);

        // 📈 Seria danych
        Series series = new Series("Dane");

        series.ChartType = SeriesChartType.Line;
        series.Color = Color.Blue;
        series.BorderWidth = 2;

        // Punkty przykładowe
        series.Points.AddXY(1, 10);
        series.Points.AddXY(2, 25);
        series.Points.AddXY(3, 18);
        series.Points.AddXY(4, 30);

        chart.Series.Add(series);

        // 🏷️ Legenda
        Legend legend = new Legend();
        legend.Docking = Docking.Bottom;
        chart.Legends.Add(legend);

        // 📝 Tytuł
        Title title = new Title();
        title.Text = "Przykładowy wykres";
        title.Font = new Font("Segoe UI", 12, FontStyle.Bold);

        chart.Titles.Add(title);

        return chart;
    }
}
}

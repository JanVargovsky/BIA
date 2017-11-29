using System;
using System.Drawing;
using System.Windows.Forms;

namespace BIA.Lesson10
{
    public partial class MainForm : Form
    {
        TSP tsp = new TSP();
        Tour tour;

        public MainForm()
        {
            InitializeComponent();
            tour = tsp.Solve();

            btnRunTSP.Click += (o, e) =>
            {
                tour = tsp.Solve();
                Text = tour.Distance.ToString();
                renderContainer.Refresh();
            };

            renderContainer.Paint += (o, e) =>
            {
                var g = e.Graphics;
                var cities = tour.Cities;
                foreach (var c in cities)
                    g.FillRectangle(Brushes.Black, c.X, c.Y, 5, 5);

                void DrawLine(City a, City b) => g.DrawLine(Pens.Black, a.X, a.Y, b.X, b.Y);

                for (int i = 0; i < cities.Length - 1; i++)
                    DrawLine(cities[i], cities[i + 1]);
                DrawLine(cities[0], cities[cities.Length - 1]);
            };
        }
    }
}

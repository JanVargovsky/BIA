using BIA.Shared.TestFunctions;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BIA.Lesson3
{
    public partial class MainForm : Form
    {
        readonly Dictionary<string, TestFunctionBase> functionsDictionary; // <func name, renderFunc>

        readonly ILGroup plotCube;
        ILSurface surface;

        public MainForm()
        {
            InitializeComponent();
            functionsDictionary = new Dictionary<string, TestFunctionBase>();

            InitFunctions();

            plotCube = new ILPlotCube(twoDMode: false);
            var scene = new ILScene {
               plotCube,
            };

            var panel = new ILPanel
            {
                Scene = scene,
            };
            renderContainer.Controls.Add(panel);

            colorMapCB.Items.AddRange(Enum.GetValues(typeof(Colormaps)).Cast<object>().ToArray());
            colorMapCB.SelectedItem = Colormaps.Jet;
            colorMapCB.SelectedIndexChanged += RefreshFunction;

            functionsCB.SelectedValueChanged += RefreshFunction;
            functionsCB.SelectedIndex = 0;
        }

        void InitFunctions()
        {
            void RegisterFunction(string name, TestFunctionBase func)
            {
                functionsCB.Items.Add(name);
                functionsDictionary[name] = func;
            }

            RegisterFunction("Lesson3 F=0.5", new Lesson3Function(0.5f));
            RegisterFunction("Lesson3 F=1", new Lesson3Function(1f));
            RegisterFunction("Lesson3 F=2", new Lesson3Function(2f));
        }

        void RefreshFunction(object sender, EventArgs e)
        {
            var selectedFunctionValue = (string)functionsCB.SelectedItem;
            var testFunction = functionsDictionary[selectedFunctionValue];

            var surface = new ILSurface((x, y) => testFunction.Calculate(x, y),
                xmin: testFunction.MinX, xmax: testFunction.MaxX, xlen: 100,
                ymin: testFunction.MinY, ymax: testFunction.MaxY, ylen: 100)
            {
                Wireframe = { Color = Color.FromArgb(50, Color.LightGray) },
                Colormap = (Colormaps)colorMapCB.SelectedItem,
            };

            if (this.surface != null)
            {
                plotCube.Remove(this.surface);
                this.surface.Dispose();
            }
            plotCube.Add(surface);
            this.surface = surface;

            renderContainer.Refresh();
        }
    }
}

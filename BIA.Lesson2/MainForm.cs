using BIA.Shared.TestFunctions;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BIA.Lesson2
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

            RegisterFunction("Rastrigin function", new RastriginFunction(10));
            RegisterFunction("Ackley's function", new AckleyFunction());
            RegisterFunction("Sphere function", new SphereFunction());
            RegisterFunction("Bukin function N.6", new BukinFunctionN6());
            RegisterFunction("Matyas function", new MatyasFunction());
            RegisterFunction("Three-hump camel function", new ThreeHumpCamelFunction());
            RegisterFunction("Easom function", new EasomFunction());
            RegisterFunction("Cross-in-tray function", new CrossInTrayFunction());
            RegisterFunction("Hölder table function", new HolderTableFunction());
            RegisterFunction("McCormick function", new McCormickfunction());
            RegisterFunction("Schaffer function N. 2", new SchafferFunctionN2());
            RegisterFunction("Schaffer function N. 4", new SchafferFunctionN4());
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

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
        readonly Dictionary<string, TestFunction> functionsDictionary; // <func name, renderFunc>
        readonly TestFunctions testFunctions;

        readonly ILGroup plotCube;
        ILSurface surface;

        public MainForm()
        {
            InitializeComponent();
            functionsDictionary = new Dictionary<string, TestFunction>();
            testFunctions = new TestFunctions();

            InitFunctions();

            plotCube = new ILPlotCube(twoDMode: false);
            var scene = new ILScene {
               plotCube,
            };
            scene.Camera.Add(new ILCamera());

            renderContainer.Controls.Add(new ILPanel
            {
                Scene = scene,
            });

            colorMapCB.Items.AddRange(Enum.GetValues(typeof(Colormaps)).Cast<object>().ToArray());
            colorMapCB.SelectedItem = Colormaps.Jet;
            colorMapCB.SelectedIndexChanged += FunctionsCB_SelectedValueChanged;

            functionsCB.SelectedValueChanged += FunctionsCB_SelectedValueChanged;
            functionsCB.SelectedIndex = 0;
        }

        void InitFunctions()
        {
            void RegisterFunction(string name, TestFunction func)
            {
                functionsCB.Items.Add(name);
                functionsDictionary[name] = func;
            }

            RegisterFunction("Rastrigin function", new TestFunction((x, y) => testFunctions.RastriginFunction(10, x, y), -5.12f, 5.12f));
            RegisterFunction("Ackley's function", new TestFunction(testFunctions.AckleyFunction, -5f, 5f));
            RegisterFunction("Sphere function", new TestFunction((x,y) => testFunctions.SphereFunction(x, y), -100, 100));
            RegisterFunction("Easom function", new TestFunction(testFunctions.EasomFunction, -100, 100));
            RegisterFunction("Three-hump camel function", new TestFunction(testFunctions.ThreeHumpCamelFunction, -5f, 5f));
            RegisterFunction("Cross-in-tray function", new TestFunction(testFunctions.CrossInTrayFunction, -10f, 10f));
            RegisterFunction("Hölder table function", new TestFunction(testFunctions.HolderTableFunction, -10f, 10f));
            RegisterFunction("McCormick function", new TestFunction(testFunctions.McCormickfunction, -1.5f, 4f, -3f, 4f));
            RegisterFunction("Schaffer function N. 2", new TestFunction(testFunctions.SchafferFunctionN2, -100f, 100f));
            RegisterFunction("Schaffer function N. 4", new TestFunction(testFunctions.SchafferFunctionN4, -100f, 100f));
            RegisterFunction("Matyas function", new TestFunction(testFunctions.MatyasFunction, -10f, 10f));
            RegisterFunction("Bukin function N.6", new TestFunction(testFunctions.BukinFunctionN6, -15f, -5f, -3f, 3f));
        }

        void FunctionsCB_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedFunctionValue = (string)functionsCB.SelectedItem;
            var testFunction = functionsDictionary[selectedFunctionValue];

            var surface = new ILSurface(testFunction.Function, 
                xmin: testFunction.MinX, xmax: testFunction.MaxX, xlen: 100,
                ymin: testFunction.MinY, ymax: testFunction.MaxY, ylen: 100)
            {
                Wireframe = { Color = Color.FromArgb(50, Color.LightGray) },
                Colormap = (Colormaps)colorMapCB.SelectedItem,
        };

            if (this.surface != null)
                plotCube.Remove(this.surface);
            plotCube.Add(surface);
            this.surface = surface;
            renderContainer.Refresh();
        }
    }
}

using BIA.Shared.TestFunctions;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BIA.Lesson4
{
    public partial class MainForm : Form
    {
        readonly Dictionary<string, TestFunctionBase> functionsDictionary; // <func name, renderFunc>
        readonly ParameterRestriction parameterRestriction;

        readonly ILGroup plotCube;
        ILSurface surface;
        ILPoints points;

        public MainForm()
        {
            InitializeComponent();
            functionsDictionary = new Dictionary<string, TestFunctionBase>();
            parameterRestriction = new ParameterRestriction();
            tbPopulationCount.Text = "10";

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

            btnGeneratePopulation.Click += (o, e) => GenerateFirstPopulation();
        }

        void InitFunctions()
        {
            void RegisterFunction(string name, TestFunctionBase func)
            {
                functionsCB.Items.Add(name);
                functionsDictionary[name] = func;
            }

            RegisterFunction("Sphere function", new SphereFunction());
            RegisterFunction("Rastrigin function", new RastriginFunction(10));
            RegisterFunction("Ackley's function", new AckleyFunction());
            RegisterFunction("Bukin function N.6", new BukinFunctionN6());
            RegisterFunction("Matyas function", new MatyasFunction());
            RegisterFunction("Three-hump camel function", new ThreeHumpCamelFunction());
            RegisterFunction("Easom function", new EasomFunction());
            RegisterFunction("Cross-in-tray function", new CrossInTrayFunction());
            RegisterFunction("Hölder table function", new HolderTableFunction());
            RegisterFunction("McCormick function", new McCormickfunction());
            RegisterFunction("Schaffer function N. 2", new SchafferFunctionN2());
            RegisterFunction("Schaffer function N. 4", new SchafferFunctionN4());
            RegisterFunction("Lesson3 F=0.5", new Lesson3Function(0.5f));
            RegisterFunction("Lesson3 F=1", new Lesson3Function(1f));
            RegisterFunction("Lesson3 F=2", new Lesson3Function(2f));
        }

        TestFunctionBase GetSelectedTestFunction()
        {
            var selectedFunctionValue = (string)functionsCB.SelectedItem;
            var testFunction = functionsDictionary[selectedFunctionValue];
            return testFunction;
        }

        void RemoveSurfaceIfExist(ILNode node)
        {
            if (node == null)
                return;

            plotCube.Remove(node);
            node.Dispose();
        }

        void RefreshFunction(object sender, EventArgs e)
        {
            var testFunction = GetSelectedTestFunction();

            var surface = new ILSurface((x, y) => testFunction.Calculate(x, y),
                xmin: testFunction.MinX, xmax: testFunction.MaxX, xlen: 100,
                ymin: testFunction.MinY, ymax: testFunction.MaxY, ylen: 100)
            {
                Wireframe = { Color = Color.FromArgb(50, Color.LightGray) },
                Colormap = (Colormaps)colorMapCB.SelectedItem,
            };

            RemoveSurfaceIfExist(points);
            RemoveSurfaceIfExist(this.surface);
            plotCube.Add(surface);
            this.surface = surface;

            renderContainer.Refresh();
        }

        void GenerateFirstPopulation()
        {
            var count = int.Parse(tbPopulationCount.Text);
            var testFunction = GetSelectedTestFunction();
            var populationGenerator = new PopulationGenerator((testFunction.MinX, testFunction.MaxX), (testFunction.MinY, testFunction.MaxY));
            var populationPoints = populationGenerator.GenerateFirstPopulation(count);

            ILInArray<float> GetPositions()
            {
                var result = new float[count, 3];
                populationPoints.ForEach((p, i) =>
                {
                    result[i, 0] = parameterRestriction.Normalize(p[0], testFunction.MinX, testFunction.MaxX);
                    result[i, 1] = parameterRestriction.Normalize(p[1], testFunction.MinY, testFunction.MaxY);
                    result[i, 2] = testFunction.Calculate(result[i, 0], result[i, 1]);
                });
                return result;
            }
            var positions = GetPositions();
            RemoveSurfaceIfExist(points);
            points = new ILPoints
            {
                Positions = positions,
                Color = Color.Black
            };
            plotCube.Add(points);
            renderContainer.Refresh();
        }
    }
}

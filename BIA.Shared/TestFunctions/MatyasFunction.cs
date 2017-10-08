namespace BIA.Shared.TestFunctions
{
    public class MatyasFunction : TestFunctionBase
    {
        public MatyasFunction() : base(-10f, 10f)
        {
        }

        public override float Calculate(params float[] values)
        {
            var x = values[0];
            var y = values[1];

            return (float)(0.26 * (x * x + y * y) - 0.48 * x * y);
        }
    }
}

using System.Linq;

namespace BIA.Shared.TestFunctions
{
    public class SphereFunction : TestFunctionBase
    {
        public SphereFunction() : base(-100, 100) // -inf, +inf theoretically
        {
        }

        public override float Calculate(params float[] values)
        {
            return values.Sum(t => t * t);
        }
    }
}

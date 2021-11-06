namespace FlexibleCalculator.Operations
{
    public class DivisionOperation : IOperation
    {
        public double Execute(double x, double y)
        {
            return x / y;
        }

        public string GetOperation()
        {
            return "/";
        }

        public Priority GetPriority()
        {
            return Priority.Medium;
        }
    }
}

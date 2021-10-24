namespace FlexibleCalculator.Operations
{
    public class MultiplicationOperation : IOperation
    {
        public double Execute(double x, double y)
        {
            return x * y;
        }

        public string GetOperation()
        {
            return "*";
        }

        public Priority GetPriority()
        {
            return Priority.Medium;
        }
    }
}

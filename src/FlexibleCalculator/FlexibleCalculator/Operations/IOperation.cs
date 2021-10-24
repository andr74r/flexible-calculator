namespace FlexibleCalculator.Operations
{
    public interface IOperation
    {
        string GetOperation();
        Priority GetPriority();
        double Execute(double x, double y);
    }
}

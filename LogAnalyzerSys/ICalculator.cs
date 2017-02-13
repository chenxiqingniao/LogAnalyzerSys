namespace LogAnalyzerSys
{
    public interface ICalculator
    {
        string Model { get; set; }
        double Add(double v1, double v2);
    }
}
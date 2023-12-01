using System;
using System.Collections.Generic;

abstract class Chart
{
    public abstract void Draw();
}

class LineChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Line Chart");
        Console.WriteLine("Data: [10, 20, 15, 25, 30]");
    }
}

class BarChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Bar Chart");
        Console.WriteLine("Data: [50, 70, 45, 80, 60]");
    }
}

class PieChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a Pie Chart");
        Console.WriteLine("Data: [30%, 20%, 15%, 25%, 10%]");
    }
}

abstract class GraphFactory
{
    public abstract Chart CreateChart();
}

class LineChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new LineChart();
    }
}

class BarChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new BarChart();
    }
}

class PieChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, GraphFactory> factories = new Dictionary<string, GraphFactory>
        {
            { "line", new LineChartFactory() },
            { "bar", new BarChartFactory() },
            { "pie", new PieChartFactory() }
        };

        Console.Write("Enter the type of chart (line/bar/pie): ");
        string chartType = Console.ReadLine().ToLower();

        if (factories.TryGetValue(chartType, out GraphFactory factory))
        {
            Chart chart = factory.CreateChart();
            chart.Draw();
        }
        else
        {
            Console.WriteLine("Invalid chart type.");
        }
    }
}

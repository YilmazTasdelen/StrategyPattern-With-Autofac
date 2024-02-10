using Autofac;
using System;


public interface IProject
{
    void Execute();
}

// Implementations of the interface
public class RegionManager : IProject
{
    public void Execute()
    {
        Console.WriteLine("RegionManager implementation");
    }
}

public class SystemAdmin : IProject
{
    public void Execute()
    {
        Console.WriteLine("SystemAdmin implementation");
    }
}

class Program
{
    static void Main()
    {
        // Create Autofac container builder
        var builder = new ContainerBuilder();

        // Register implementations with names
        builder.RegisterType<RegionManager>().Named<IProject>("RegionManager");
        builder.RegisterType<SystemAdmin>().Named<IProject>("SystemAdmin");

        // Build the container
        var container = builder.Build();

        // Simulate getting user type dynamically (replace this with your actual logic)
        string userType = "SystemAdmin"; // Replace with actual user type

        // Resolve the implementation based on the user type
        var project = container.ResolveNamed<IProject>(userType);

        // Call the Execute method on the resolved implementation
        project.Execute();
    }
}
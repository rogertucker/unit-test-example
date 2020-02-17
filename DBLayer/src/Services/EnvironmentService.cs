using System;
using System.Diagnostics.CodeAnalysis;

namespace DBLayer.Service{
    [ExcludeFromCodeCoverage]
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        public string EnvironmentName { get; set; }
    }
}
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure
{
    public class AssemblyExtension
    {
        public static Assembly[] GetExecutingAssemblies(string startName)
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var dependency in dependencies)
            {
                if (IsCandidateLibrary(dependency, startName))
                {
                    var assembly = Assembly.Load(new AssemblyName(dependency.Name));
                    assemblies.Add(assembly);
                }
            }

            return assemblies.ToArray();
        }

        private static bool IsCandidateLibrary(RuntimeLibrary library, string assemblyName)
        {
            return library.Name == (assemblyName)
                || library.Dependencies.Any(d => d.Name.StartsWith(assemblyName));
        }
    }
}

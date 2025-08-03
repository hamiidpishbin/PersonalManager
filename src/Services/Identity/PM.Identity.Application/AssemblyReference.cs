using System.Reflection;

namespace PM.Identity.Application;

public class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
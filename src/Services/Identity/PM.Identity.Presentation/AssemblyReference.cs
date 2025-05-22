using System.Reflection;

namespace PM.Identity.Presentation;

public class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
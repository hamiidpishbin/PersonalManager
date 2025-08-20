using System.Reflection;

namespace PM.DTM.Presentation;

public class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly; 
}
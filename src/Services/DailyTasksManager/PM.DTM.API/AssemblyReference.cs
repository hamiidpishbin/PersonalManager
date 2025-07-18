using System.Reflection;

namespace PM.DTM.API;

public class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly; 
}
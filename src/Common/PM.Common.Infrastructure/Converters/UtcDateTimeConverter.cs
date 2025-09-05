using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PM.Common.Infrastructure.Converters;

public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
{
	public UtcDateTimeConverter() 
		: base(
			v => v.Kind == DateTimeKind.Utc ? v : DateTime.SpecifyKind(v, DateTimeKind.Utc),
			v => v)
	{
	}
}
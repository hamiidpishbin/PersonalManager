using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PM.Common.Infrastructure.Converters;

public class UtcNullableDateTimeConverter : ValueConverter<DateTime?, DateTime?>
{
	public UtcNullableDateTimeConverter() 
		: base(
			v => v.HasValue ? (v.Value.Kind == DateTimeKind.Utc ? v.Value : DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)) : v,
			v => v)
	{
	}
}
using System;

namespace BlazorServerExample
{
	public class Calendar
	{
		public record CalendarItem(DateTime Date, string Name);
	}
}

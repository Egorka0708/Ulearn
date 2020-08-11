using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
	public class StatisticsTask
	{
		public static double GetMedianTimePerSlide(List<VisitRecord> visits, SlideType slideType)
		{
            if (visits.Count == 0)
            {
                return 0;
            }

            var visitsTimes = visits
                .OrderBy(record => record.DateTime)
                .GroupBy(record => record.UserId)
                .SelectMany(records => records.Bigramms())
                .Where(tuple => tuple.Item1.SlideType == slideType)
                .Select(tuple => tuple.Item2.DateTime - tuple.Item1.DateTime)
                .Where(span => span >= TimeSpan.FromMinutes(1) && span <= TimeSpan.FromHours(2))
                .Select(minutes => minutes.TotalMinutes);

            return visitsTimes.Median();
        }
	}
}
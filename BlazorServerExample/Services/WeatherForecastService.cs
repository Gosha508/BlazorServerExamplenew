using BlazorServerExample.Model;
using BlazorServerExample.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerExample.Services
{
    public class WeatherForecastService
    {
        private AppDbContext context;

        public WeatherForecastService(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateForecast(WeatherForecast wf)
        {
            context.Add(wf);
            context.SaveChanges();
        }

        //public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        //{
        //  return context.WeatherForecasts.ToArrayAsync();
        //}

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        //{
        //    var rng = new Random();
        //    return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = startDate.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    }).ToArray());
        //}
    }
}

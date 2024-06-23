namespace Sign.BoundContext.Domain;

public class WeatherService(IWeatherRepository weatherRepository) : IWeatherService
{
    public decimal GetTemp()
    {
        return weatherRepository.GetTemp();
    }

    public WeatherForecast GetForecast()
    {
        return new WeatherForecast {Temp = 9999};
    }

    public WeatherForecast GetForecastExp()
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }
}


// a -> b -> c -> d

//             infrastructure
//                   |
//                   \/
// application -> domain 
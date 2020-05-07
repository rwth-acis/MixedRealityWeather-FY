using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

//Makes sure that WeatherQuery is on same Object! (Is done automatically if not)
[RequireComponent(typeof(WeatherQuery))]
public class WeatherController : MonoBehaviour
{
    //Task: 2.2h
    //By Felix Voigtländer 07.05.2020
    //Look up Links

    public TextMeshPro textCity;
    public TextMeshPro textTemp;
    public TextMeshPro textDescription;
    public WeatherWidget weatherWidget;


    WeatherQuery weatherQuery;


    private void Start()
    {
        weatherQuery = GetComponent<WeatherQuery>();
        if (!weatherQuery)
            Debug.LogError("WeatherQuery not on same Object!");
    }

    public async Task LoadWeather(string cityName)
    {
        //Reseting Weather Text:
        //Write WeatherData
        textCity.text = textTemp.text = textDescription.text = "...";

        //Fetch WeatherData
        WeatherData weatherData = await weatherQuery.FetchWeatherData(cityName);
        if (weatherData == null)
        {
            Debug.LogError("WeatherData is null!");
            return;
        }

        int code = weatherData.weather[0].id;

        //Assign Weatherscene
        WeatherScene weatherScene = CodeToWeather(code);
        weatherWidget.WeatherScene = weatherScene;

        //Assign Rain
        //Thunderstrom or Cloudy
        weatherWidget.ThunderstormRain.enabled = weatherScene == WeatherScene.THUNDERSTORM;
        weatherWidget.CloudRain.enabled = weatherScene == WeatherScene.PARTLY_CLOUDY || weatherScene == WeatherScene.CLOUDY;
        //Assign Rain Intensity
        float rainIntensity = CodeToRainIntensity(code);
        weatherWidget.ThunderstormRain.RainRate = rainIntensity;
        weatherWidget.CloudRain.RainRate = rainIntensity;

        //Assign Snow
        float snowIntensity = CodeToSnowIntensity(code);
        weatherWidget.CloudSnow.RainEnabled = snowIntensity > 0;
        weatherWidget.CloudSnow.RainRate = snowIntensity;

        //Write WeatherData
        textCity.text = weatherData.name;
        textTemp.text = weatherData.main.temp + "F";
        textDescription.text = weatherScene.ToString();


    }

    public WeatherScene CodeToWeather(int code)
    {
        //2 starten ¨ WeatherScene.THUNDERSTORM
        if (GetFirstDigit(code) == 2)
            return WeatherScene.THUNDERSTORM;

        //ID 800 soll ¨ WeatherScene.SUNNY
        if (code == 800)
            return WeatherScene.SUNNY;

        //fur 801 und 802 ¨ WeatherScene.PARTLY CLOUDY
        if (code == 801 || code == 802)
            return WeatherScene.PARTLY_CLOUDY;

        //Fur alle anderen Werte soll WeatherScene.CLOUDY ausgew¨ahlt werden
        return WeatherScene.CLOUDY;
    }

    public float CodeToRainIntensity(int code)
    {
        //Codes, die mit 2 starten soll 150f zuruckgegeben werden
        if (GetFirstDigit(code) == 2)
            return 150f;

        //f ¨ ur alles zwischen 300 und 499 20f
        if (code >= 300 && code <= 499)
            return 20f;

        //Codes, die mit 5 starten 40f
        if (GetFirstDigit(code) == 5)
            return 40f;

        // fur alle anderen Codes
        return 0f;
    }

    public float CodeToSnowIntensity(int code)
    {
        //50f fur alle Wetter-Codes zwischen 600 und 700
        if (code >= 600 && code <= 700)
            return 50f;

        // fur alle anderen Codes
        return 0f;
    }

    //Returns first digit of i : 
    // if i is 2140124989 the int 2 is returned
    public int GetFirstDigit(int i)
    {
        while (i >= 10)
            i /= 10;

        return i;
    }
}

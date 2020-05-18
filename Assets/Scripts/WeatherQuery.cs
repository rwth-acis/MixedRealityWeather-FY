using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Threading.Tasks;
using System.Net;
using System;
using System.IO;

public class WeatherQuery : MonoBehaviour
{
    //Task: 2.2g
    //By Felix Voigtländer 07.05.2020
    //Look up Links: 
    // Async/Rest/await: https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/concepts/async/
    // WeatherWebsite: https://openweathermap.org/current
    // !WeatherWebsite Tutorial: https://www.red-gate.com/simple-talk/dotnet/c-programming/calling-restful-apis-unity3d/

    public WeatherData weatherData;
    private async Task Start()
    {
        print("Weather test");
        weatherData = await FetchWeatherData("Sydney");
    }

    public async Task<WeatherData> FetchWeatherData(string cityName)
    {
        print("Starting to Fetch");
        // Request Information
        string apiKey = "16fb128280d16cd1acdeed497976a523";

        //HTTP Fetch
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", cityName, apiKey));
        HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());

        //Parse to Json String
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();

        // Parse from Json string to WeatherData
        WeatherData data = JsonUtility.FromJson<WeatherData>(jsonResponse);

        //Return Fetched WeatherData
        return data;
    }
}

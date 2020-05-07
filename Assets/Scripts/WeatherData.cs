using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeatherData 
{
    public List<WeatherState> weather;
    public ClimateData main;
    public int id;
    public string name;
}

[Serializable]
public class WeatherState
{
    public int id;
    public string main;
}

[Serializable]
public class ClimateData
{
    public float temp;
    public float feels_like;
    public float temp_min;
    public float temp_max;
    public float pressure;
    public float humidity;

}
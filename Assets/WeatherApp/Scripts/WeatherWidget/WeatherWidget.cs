using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherWidget : MonoBehaviour
{
    [SerializeField] private RainController cloudRain;
    [SerializeField] private RainController cloudSnow;
    [SerializeField] private RainController thunderstormRain;

    [SerializeField] private WeatherScene weatherScene;

    public WeatherScene WeatherScene
    {
        get => weatherScene;
        set
        {
            weatherScene = value;
            animator.SetInteger("WeatherState", (int)weatherScene);
        }
    }

    public RainController CloudRain { get => cloudRain; }
    public RainController CloudSnow { get => cloudSnow; }
    public RainController ThunderstormRain { get => thunderstormRain; }

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CloudRain.RainEnabled = true;
        CloudSnow.RainEnabled = false;
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            animator.SetInteger("WeatherState", (int)weatherScene);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CloudSnow.RainEnabled = !CloudSnow.RainEnabled;
            CloudRain.RainEnabled = !CloudSnow.RainEnabled;
        }
    }
}

public enum WeatherScene
{
    SUNNY, PARTLY_CLOUDY, CLOUDY, THUNDERSTORM
}
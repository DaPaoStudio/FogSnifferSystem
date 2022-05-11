using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XCharts;
using XCharts.Runtime;

/// <summary>
/// 管理并显示UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public LineChart temperatureChart;
    public LineChart humidityChart;
    public Text aqiLevel, aqi, primary, pm10, pm2p5, no2, so2, co, o3;
    public Text weatherLevel, temperature, humidity, windDir, windLevel, windSpeed, pressure, cloud, rain;
    public Text location,time;

    void Start()
    {

    }

    //更新屏幕上的时间
    void Update()
    {
        time.text = DateTime.Now.ToString();
    }

    /// <summary>
    /// 更新屏幕上的全部信息
    /// ①更新位置
    /// ②更新温度折线图
    /// ③更新湿度折线图
    /// ④更新天气数据
    /// ⑤更新空气数据
    /// </summary>
    public void UpdateData()
    {
        location.text = "您当前的位置：" + StaticData.location.ad_info.city;
        UpdateTempChart();
        UpdateHumiChart();
        UpdateWeatherData();
        UpdateAQIData();
    }

    /// <summary>
    /// 更新温度折线图
    /// </summary>
    void UpdateTempChart()
    {
        temperatureChart.ClearData();
        temperatureChart.AddXAxisData("当前");
        temperatureChart.AddData(0, int.Parse(StaticData.weather[0].temp));
        for (int i = 1; i < 23; i++)
        {
            temperatureChart.AddXAxisData(StaticData.weather[i].fxTime.Substring(11, 5));
            temperatureChart.AddData(0, int.Parse(StaticData.weather[i].temp));
        }
    }

    /// <summary>
    /// 更新湿度折线图
    /// </summary>
    void UpdateHumiChart()
    {
        humidityChart.ClearData();
        humidityChart.AddXAxisData("当前");
        humidityChart.AddData(0, int.Parse(StaticData.weather[0].humidity));
        for (int i = 1; i < 23; i++)
        {
            humidityChart.AddXAxisData(StaticData.weather[i].fxTime.Substring(11, 5));
            humidityChart.AddData(0, int.Parse(StaticData.weather[i].humidity));
        }
    }

    /// <summary>
    /// 更新天气数据
    /// </summary>
    void UpdateWeatherData()
    {
        UpdateWeatherWithColor();
        temperature.text = "当前温度：" + StaticData.weather[0].temp + "℃";
        humidity.text = "相对湿度：" + StaticData.weather[0].humidity + "%";
        windDir.text = "风向：" + StaticData.weather[0].windDir;
        windLevel.text = "风力等级：" + StaticData.weather[0].windScale + "级";
        windSpeed.text = "风速：" + StaticData.weather[0].windSpeed + "Km/h";
        pressure.text = "大气压：" + StaticData.weather[0].pressure + "hPa";
        cloud.text = "云量：" + StaticData.weather[0].cloud + "%";
        rain.text = "降水概率：" + StaticData.weather[0].pop + "%";
    }

    /// <summary>
    /// 更新空气质量数据
    /// </summary>
    void UpdateAQIData()
    {
        UpdateAQIWithColor();
        aqi.text = "当前空气质量指数：" + StaticData.aqi.aqi;
        if (StaticData.aqi.primary == "NA")
            primary.text = "主要污染物：无";
        else
            primary.text = "主要污染物：" + StaticData.aqi.primary;
        pm10.text = "PM10浓度：" + StaticData.aqi.pm10;
        pm2p5.text = "PM2.5浓度：" + StaticData.aqi.pm2p5;
        no2.text = "二氧化氮浓度：" + StaticData.aqi.no2;
        so2.text = "二氧化硫浓度：" + StaticData.aqi.so2;
        co.text = "一氧化碳浓度：" + StaticData.aqi.co;
        o3.text = "臭氧浓度：" + StaticData.aqi.o3;
    }

    /// <summary>
    /// 根据天气状态对天气描述进行着色，晴天是绿色
    /// </summary>
    void UpdateWeatherWithColor()
    {
        switch (StaticData.weather[0].text)
        {
            case "晴":case "多云":case "少云":case "晴间多云":
                weatherLevel.text = "<color=green>" + StaticData.weather[0].text + "</color>";
                break;
            case "阴":
                weatherLevel.text = "<color=grey>" + StaticData.weather[0].text + "</color>";
                break;
            case "阵雨":case "强阵雨":case "雷阵雨":case "强雷阵雨":case "雷阵雨伴有冰雹":case "小雨":case "中雨":case "大雨":case "极端降雨":
            case "毛毛雨/细雨":case "暴雨":case "	大暴雨":case "特大暴雨":case "冻雨":case "小到中雨":case "中到大雨":case "大到暴雨":case "暴雨到大暴雨":
            case "大暴雨到特大暴雨":case "雨":
                weatherLevel.text = "<color=darkblue>" + StaticData.weather[0].text + "</color>";
                break;
            case "薄雾":case "雾":case "霾":case "扬沙":case "浮尘":case "沙尘暴":case "强沙尘暴":case "浓雾":case "强浓雾":case "中度霾":case "重度霾":
            case "严重霾":case "大雾":case "特强浓雾":
                weatherLevel.text = "<color=black>" + StaticData.weather[0].text + "</color>";
                break;
            case "新月":case "蛾眉月":case "上弦月":case "盈凸月":case "满月":case "亏凸月":case "下弦月":case "残月":case "热":case "冷":case "未知":
                weatherLevel.text = "<color=teal>" + StaticData.weather[0].text + "</color>";
                break;
            default:
                weatherLevel.text = "<color=aqua>" + StaticData.weather[0].text + "</color>";
                break;
        }
    }

    /// <summary>
    /// 根据AQI对空气质量进行着色，绿、黄、橙、红、紫、黑
    /// </summary>
    void UpdateAQIWithColor()
    {
        switch (StaticData.aqi.level)
        {
            case "1":
                aqiLevel.text = "<color=green>" + StaticData.aqi.category + "</color>";
                break;
            case "2":
                aqiLevel.text = "<color=yellow>" + StaticData.aqi.category + "</color>";
                break;
            case "3":
                aqiLevel.text = "<color=orange>" + StaticData.aqi.category + "</color>";
                break;
            case "4":
                aqiLevel.text = "<color=red>" + StaticData.aqi.category + "</color>";
                break;
            case "5":
                aqiLevel.text = "<color=purple>" + StaticData.aqi.category + "</color>";
                break;
            default:
                aqiLevel.text = "<color=black>" + StaticData.aqi.category + "</color>";
                break;
        }
    }
}

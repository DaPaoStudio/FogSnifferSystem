using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject mainUI;
    
    /// <summary>
    /// 打开软件时自动运行一次，初始化系统
    /// </summary>
    void Start()
    {
        StartCoroutine(SystemInit());
    }

    
    void Update()
    {
        
    }
    /// <summary>
    /// 清空缓存并初始化系统内的数据：
    /// ①获取位置信息并保存
    /// ②使用保存后的位置信息查询天气和AQI
    /// ③解析并保存天气和AQI数据
    /// ④绘制并显示折线图
    /// </summary>
    IEnumerator SystemInit()
    {
        //清空本地缓存
        StaticData.location = null;
        StaticData.aqi = null;
        StaticData.weather = null;
        //首先获取位置
        GetLocation();
        while(StaticData.location == null)
            yield return null;
        //获取实时AQI
        GetRealTimeAQI();
        while (StaticData.aqi == null)
            yield return null;
        //获取24小时内天气
        Get24HWeather();
        while (StaticData.weather == null)
            yield return null;
        //绘制图表并更新数据显示在屏幕上
        mainUI.GetComponent<UIManager>().UpdateData();
    }

    /// <summary>
    /// 通过IP获取位置并保存到系统中
    /// </summary>
    void GetLocation()
    {
        StartCoroutine(Tools.GetLocationRequest((location) =>
        {
            StaticData.location = location;
            Debug.Log(location.ad_info.city);
        }));
    }

    /// <summary>
    /// 通过地址获取AQI数据并保存到系统中
    /// </summary>
    void GetRealTimeAQI()
    {
        StartCoroutine(Tools.GetRealTimeAQIRequest(StaticData.location.location.lng, StaticData.location.location.lat, (aqi) =>
        {
            StaticData.aqi = aqi;
            Debug.Log(aqi.category);
        }));
    }

    /// <summary>
    /// 通过地址获取24h天气数据并保存到系统中
    /// </summary>
    void Get24HWeather()
    {
        StartCoroutine(Tools.Get24HWeatherRequest(StaticData.location.location.lng, StaticData.location.location.lat, (weather) =>
        {
            StaticData.weather = weather;
            Debug.Log(weather[0].text);
        }));
    }

    /// <summary>
    /// 按下刷新按钮时重新定位并查询天气等
    /// </summary>
    public void Refresh()
    {
        StartCoroutine(SystemInit());
    }
}

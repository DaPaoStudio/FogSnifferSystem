using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    /// <summary>
    /// 获取后的地址信息
    /// </summary>
    public static LocationAnalysis location { get;  set; }    
    /// <summary>
    /// 查询到的空气质量数据
    /// </summary>
    public static AQIAnalysis aqi { get; set; }
    /// <summary>
    /// 查询到的24小时天气数据
    /// </summary>
    public static List<WeatherAnalysis> weather { get; set; }
}

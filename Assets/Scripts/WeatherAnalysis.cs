using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解析回传的天气Json数据，反序列化到天气这个类
/// </summary>
public class WeatherAnalysis
{
    /// <summary>
    /// 预报时间
    /// </summary>
    public string fxTime { get; set; }
    /// <summary>
    /// 气温
    /// </summary>
    public string temp { get; set; }
    /// <summary>
    /// 天气图标编号
    /// </summary>
    public string icon { get; set; }
    /// <summary>
    /// 天气文字描述
    /// </summary>
    public string text { get; set; }
    /// <summary>
    /// 风向角
    /// </summary>
    public string wind360 { get; set; }
    /// <summary>
    /// 风向
    /// </summary>
    public string windDir { get; set; }
    /// <summary>
    /// 风力等级
    /// </summary>
    public string windScale { get; set; }
    /// <summary>
    /// 风速
    /// </summary>
    public string windSpeed { get; set; }
    /// <summary>
    /// 相对湿度
    /// </summary>
    public string humidity { get; set; }
    /// <summary>
    /// 小时降水量
    /// </summary>
    public string precip { get; set; }
    /// <summary>
    /// 降水概率
    /// </summary>
    public string pop { get; set; }
    /// <summary>
    /// 大气压强
    /// </summary>
    public string pressure { get; set; }
    /// <summary>
    /// 云量
    /// </summary>
    public string cloud { get; set; }
    /// <summary>
    /// 露点温度
    /// </summary>
    public string dew { get; set; }
}

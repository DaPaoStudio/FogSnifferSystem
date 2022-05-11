using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解析回传的空气质量Json数据，反序列化到空气质量这个类
/// </summary>
public class AQIAnalysis
{
    /// <summary>
    /// 更新时间
    /// </summary>
    public string pubTime { get; set; }
    /// <summary>
    /// AQI数值
    /// </summary>
    public string aqi { get; set; }
    /// <summary>
    /// 空气污染等级
    /// </summary>
    public string level { get; set; }
    /// <summary>
    /// AQI等级标签（优良等）
    /// </summary>
    public string category { get; set; }
    /// <summary>
    /// 主要污染物
    /// </summary>
    public string primary { get; set; }
    /// <summary>
    /// PM10数值
    /// </summary>
    public string pm10 { get; set; }
    /// <summary>
    /// PM2.5数值
    /// </summary>
    public string pm2p5 { get; set; }
    /// <summary>
    /// 二氧化氮数值
    /// </summary>
    public string no2 { get; set; }
    /// <summary>
    /// 二氧化硫数值
    /// </summary>
    public string so2 { get; set; }
    /// <summary>
    /// 一氧化碳数值
    /// </summary>
    public string co { get; set; }
    /// <summary>
    /// 臭氧数值
    /// </summary>
    public string o3 { get; set; }
}

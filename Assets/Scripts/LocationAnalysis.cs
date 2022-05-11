using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解析腾讯地图IP-地址API返回的结果
/// </summary>
public class LocationAnalysis
{
    /// <summary>
    /// IP地址
    /// </summary>
    public string ip { get; set; }
    /// <summary>
    /// 经纬度位置
    /// </summary>
    public Location location { get; set; }
    /// <summary>
    /// 地址信息
    /// </summary>
    public Ad_info ad_info { get; set; }
}

public class Location
{
    /// <summary>
    /// 纬度
    /// </summary>
    public double lat { get; set; }
    /// <summary>
    /// 经度
    /// </summary>
    public double lng { get; set; }
}

public class Ad_info
{
    /// <summary>
    /// 国家
    /// </summary>
    public string nation { get; set; }
    /// <summary>
    /// 省份
    /// </summary>
    public string province { get; set; }
    /// <summary>
    /// 市
    /// </summary>
    public string city { get; set; }
    /// <summary>
    /// 区
    /// </summary>
    public string district { get; set; }
    /// <summary>
    /// 城市编码
    /// </summary>
    public int adcode { get; set; } 
}
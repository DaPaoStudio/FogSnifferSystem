using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ѷ��ͼIP-��ַAPI���صĽ��
/// </summary>
public class LocationAnalysis
{
    /// <summary>
    /// IP��ַ
    /// </summary>
    public string ip { get; set; }
    /// <summary>
    /// ��γ��λ��
    /// </summary>
    public Location location { get; set; }
    /// <summary>
    /// ��ַ��Ϣ
    /// </summary>
    public Ad_info ad_info { get; set; }
}

public class Location
{
    /// <summary>
    /// γ��
    /// </summary>
    public double lat { get; set; }
    /// <summary>
    /// ����
    /// </summary>
    public double lng { get; set; }
}

public class Ad_info
{
    /// <summary>
    /// ����
    /// </summary>
    public string nation { get; set; }
    /// <summary>
    /// ʡ��
    /// </summary>
    public string province { get; set; }
    /// <summary>
    /// ��
    /// </summary>
    public string city { get; set; }
    /// <summary>
    /// ��
    /// </summary>
    public string district { get; set; }
    /// <summary>
    /// ���б���
    /// </summary>
    public int adcode { get; set; } 
}
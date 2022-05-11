using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ش��Ŀ�������Json���ݣ������л����������������
/// </summary>
public class AQIAnalysis
{
    /// <summary>
    /// ����ʱ��
    /// </summary>
    public string pubTime { get; set; }
    /// <summary>
    /// AQI��ֵ
    /// </summary>
    public string aqi { get; set; }
    /// <summary>
    /// ������Ⱦ�ȼ�
    /// </summary>
    public string level { get; set; }
    /// <summary>
    /// AQI�ȼ���ǩ�������ȣ�
    /// </summary>
    public string category { get; set; }
    /// <summary>
    /// ��Ҫ��Ⱦ��
    /// </summary>
    public string primary { get; set; }
    /// <summary>
    /// PM10��ֵ
    /// </summary>
    public string pm10 { get; set; }
    /// <summary>
    /// PM2.5��ֵ
    /// </summary>
    public string pm2p5 { get; set; }
    /// <summary>
    /// ����������ֵ
    /// </summary>
    public string no2 { get; set; }
    /// <summary>
    /// ����������ֵ
    /// </summary>
    public string so2 { get; set; }
    /// <summary>
    /// һ����̼��ֵ
    /// </summary>
    public string co { get; set; }
    /// <summary>
    /// ������ֵ
    /// </summary>
    public string o3 { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    /// <summary>
    /// ��ȡ��ĵ�ַ��Ϣ
    /// </summary>
    public static LocationAnalysis location { get;  set; }    
    /// <summary>
    /// ��ѯ���Ŀ�����������
    /// </summary>
    public static AQIAnalysis aqi { get; set; }
    /// <summary>
    /// ��ѯ����24Сʱ��������
    /// </summary>
    public static List<WeatherAnalysis> weather { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ش�������Json���ݣ������л������������
/// </summary>
public class WeatherAnalysis
{
    /// <summary>
    /// Ԥ��ʱ��
    /// </summary>
    public string fxTime { get; set; }
    /// <summary>
    /// ����
    /// </summary>
    public string temp { get; set; }
    /// <summary>
    /// ����ͼ����
    /// </summary>
    public string icon { get; set; }
    /// <summary>
    /// ������������
    /// </summary>
    public string text { get; set; }
    /// <summary>
    /// �����
    /// </summary>
    public string wind360 { get; set; }
    /// <summary>
    /// ����
    /// </summary>
    public string windDir { get; set; }
    /// <summary>
    /// �����ȼ�
    /// </summary>
    public string windScale { get; set; }
    /// <summary>
    /// ����
    /// </summary>
    public string windSpeed { get; set; }
    /// <summary>
    /// ���ʪ��
    /// </summary>
    public string humidity { get; set; }
    /// <summary>
    /// Сʱ��ˮ��
    /// </summary>
    public string precip { get; set; }
    /// <summary>
    /// ��ˮ����
    /// </summary>
    public string pop { get; set; }
    /// <summary>
    /// ����ѹǿ
    /// </summary>
    public string pressure { get; set; }
    /// <summary>
    /// ����
    /// </summary>
    public string cloud { get; set; }
    /// <summary>
    /// ¶���¶�
    /// </summary>
    public string dew { get; set; }
}

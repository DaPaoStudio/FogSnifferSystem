using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XCharts;
using XCharts.Runtime;

/// <summary>
/// ������ʾUI
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

    //������Ļ�ϵ�ʱ��
    void Update()
    {
        time.text = DateTime.Now.ToString();
    }

    /// <summary>
    /// ������Ļ�ϵ�ȫ����Ϣ
    /// �ٸ���λ��
    /// �ڸ����¶�����ͼ
    /// �۸���ʪ������ͼ
    /// �ܸ�����������
    /// �ݸ��¿�������
    /// </summary>
    public void UpdateData()
    {
        location.text = "����ǰ��λ�ã�" + StaticData.location.ad_info.city;
        UpdateTempChart();
        UpdateHumiChart();
        UpdateWeatherData();
        UpdateAQIData();
    }

    /// <summary>
    /// �����¶�����ͼ
    /// </summary>
    void UpdateTempChart()
    {
        temperatureChart.ClearData();
        temperatureChart.AddXAxisData("��ǰ");
        temperatureChart.AddData(0, int.Parse(StaticData.weather[0].temp));
        for (int i = 1; i < 23; i++)
        {
            temperatureChart.AddXAxisData(StaticData.weather[i].fxTime.Substring(11, 5));
            temperatureChart.AddData(0, int.Parse(StaticData.weather[i].temp));
        }
    }

    /// <summary>
    /// ����ʪ������ͼ
    /// </summary>
    void UpdateHumiChart()
    {
        humidityChart.ClearData();
        humidityChart.AddXAxisData("��ǰ");
        humidityChart.AddData(0, int.Parse(StaticData.weather[0].humidity));
        for (int i = 1; i < 23; i++)
        {
            humidityChart.AddXAxisData(StaticData.weather[i].fxTime.Substring(11, 5));
            humidityChart.AddData(0, int.Parse(StaticData.weather[i].humidity));
        }
    }

    /// <summary>
    /// ������������
    /// </summary>
    void UpdateWeatherData()
    {
        UpdateWeatherWithColor();
        temperature.text = "��ǰ�¶ȣ�" + StaticData.weather[0].temp + "��";
        humidity.text = "���ʪ�ȣ�" + StaticData.weather[0].humidity + "%";
        windDir.text = "����" + StaticData.weather[0].windDir;
        windLevel.text = "�����ȼ���" + StaticData.weather[0].windScale + "��";
        windSpeed.text = "���٣�" + StaticData.weather[0].windSpeed + "Km/h";
        pressure.text = "����ѹ��" + StaticData.weather[0].pressure + "hPa";
        cloud.text = "������" + StaticData.weather[0].cloud + "%";
        rain.text = "��ˮ���ʣ�" + StaticData.weather[0].pop + "%";
    }

    /// <summary>
    /// ���¿�����������
    /// </summary>
    void UpdateAQIData()
    {
        UpdateAQIWithColor();
        aqi.text = "��ǰ��������ָ����" + StaticData.aqi.aqi;
        if (StaticData.aqi.primary == "NA")
            primary.text = "��Ҫ��Ⱦ���";
        else
            primary.text = "��Ҫ��Ⱦ�" + StaticData.aqi.primary;
        pm10.text = "PM10Ũ�ȣ�" + StaticData.aqi.pm10;
        pm2p5.text = "PM2.5Ũ�ȣ�" + StaticData.aqi.pm2p5;
        no2.text = "��������Ũ�ȣ�" + StaticData.aqi.no2;
        so2.text = "��������Ũ�ȣ�" + StaticData.aqi.so2;
        co.text = "һ����̼Ũ�ȣ�" + StaticData.aqi.co;
        o3.text = "����Ũ�ȣ�" + StaticData.aqi.o3;
    }

    /// <summary>
    /// ��������״̬����������������ɫ����������ɫ
    /// </summary>
    void UpdateWeatherWithColor()
    {
        switch (StaticData.weather[0].text)
        {
            case "��":case "����":case "����":case "������":
                weatherLevel.text = "<color=green>" + StaticData.weather[0].text + "</color>";
                break;
            case "��":
                weatherLevel.text = "<color=grey>" + StaticData.weather[0].text + "</color>";
                break;
            case "����":case "ǿ����":case "������":case "ǿ������":case "��������б���":case "С��":case "����":case "����":case "���˽���":
            case "ëë��/ϸ��":case "����":case "	����":case "�ش���":case "����":case "С������":case "�е�����":case "�󵽱���":case "���굽����":
            case "���굽�ش���":case "��":
                weatherLevel.text = "<color=darkblue>" + StaticData.weather[0].text + "</color>";
                break;
            case "����":case "��":case "��":case "��ɳ":case "����":case "ɳ����":case "ǿɳ����":case "Ũ��":case "ǿŨ��":case "�ж���":case "�ض���":
            case "������":case "����":case "��ǿŨ��":
                weatherLevel.text = "<color=black>" + StaticData.weather[0].text + "</color>";
                break;
            case "����":case "��ü��":case "������":case "ӯ͹��":case "����":case "��͹��":case "������":case "����":case "��":case "��":case "δ֪":
                weatherLevel.text = "<color=teal>" + StaticData.weather[0].text + "</color>";
                break;
            default:
                weatherLevel.text = "<color=aqua>" + StaticData.weather[0].text + "</color>";
                break;
        }
    }

    /// <summary>
    /// ����AQI�Կ�������������ɫ���̡��ơ��ȡ��졢�ϡ���
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

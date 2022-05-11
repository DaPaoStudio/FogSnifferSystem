using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject mainUI;
    
    /// <summary>
    /// �����ʱ�Զ�����һ�Σ���ʼ��ϵͳ
    /// </summary>
    void Start()
    {
        StartCoroutine(SystemInit());
    }

    
    void Update()
    {
        
    }
    /// <summary>
    /// ��ջ��沢��ʼ��ϵͳ�ڵ����ݣ�
    /// �ٻ�ȡλ����Ϣ������
    /// ��ʹ�ñ�����λ����Ϣ��ѯ������AQI
    /// �۽���������������AQI����
    /// �ܻ��Ʋ���ʾ����ͼ
    /// </summary>
    IEnumerator SystemInit()
    {
        //��ձ��ػ���
        StaticData.location = null;
        StaticData.aqi = null;
        StaticData.weather = null;
        //���Ȼ�ȡλ��
        GetLocation();
        while(StaticData.location == null)
            yield return null;
        //��ȡʵʱAQI
        GetRealTimeAQI();
        while (StaticData.aqi == null)
            yield return null;
        //��ȡ24Сʱ������
        Get24HWeather();
        while (StaticData.weather == null)
            yield return null;
        //����ͼ������������ʾ����Ļ��
        mainUI.GetComponent<UIManager>().UpdateData();
    }

    /// <summary>
    /// ͨ��IP��ȡλ�ò����浽ϵͳ��
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
    /// ͨ����ַ��ȡAQI���ݲ����浽ϵͳ��
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
    /// ͨ����ַ��ȡ24h�������ݲ����浽ϵͳ��
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
    /// ����ˢ�°�ťʱ���¶�λ����ѯ������
    /// </summary>
    public void Refresh()
    {
        StartCoroutine(SystemInit());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

public static class Tools
{
    //使用腾讯地图API获取本机IP所处的城市信息
    public static IEnumerator GetLocationRequest(Action<LocationAnalysis> callback)
    {
        Uri uri = new Uri("https://apis.map.qq.com/ws/location/v1/ip?" + "&key=FJ3BZ-HTAKW-4EPRT-R3WS6-EFNKV-YMFI4&get_poi=1");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                object obj = JsonConvert.DeserializeObject(webRequest.downloadHandler.text);
                Newtonsoft.Json.Linq.JObject js = obj as Newtonsoft.Json.Linq.JObject;
                if (js == null)
                    yield return null;
                callback?.Invoke(js["result"].ToObject<LocationAnalysis>());
            }
        }
    }

    /// <summary>
    /// 通过定位获取的城市经纬度获取城市实时AQI(和风天气)
    /// </summary>
    /// <param name="lon">城市经度</param>
    /// <param name="lat">城市纬度</param>
    /// <returns></returns>
    public static IEnumerator GetRealTimeAQIRequest(double lng, double lat, Action<AQIAnalysis> callback)
    {
        string location = String.Format("location={0:F},{1:F}", lng, lat);
        Uri uri = new Uri("https://devapi.qweather.com/v7/air/now?" + location + "&key=02b223adc9f74eabb3453af47e463166");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                object obj = JsonConvert.DeserializeObject(webRequest.downloadHandler.text);
                Newtonsoft.Json.Linq.JObject js = obj as Newtonsoft.Json.Linq.JObject;
                if (js == null)
                    yield return null;
                callback?.Invoke(js["now"].ToObject<AQIAnalysis>());
            }
        }
    }

    /// <summary>
    /// 通过定位获取的城市经纬度获取城市24小时天气预报(和风天气)
    /// </summary>
    /// <param name="lon">城市经度</param>
    /// <param name="lat">城市纬度</param>
    /// <returns></returns>
    public static IEnumerator Get24HWeatherRequest(double lng, double lat, Action<List<WeatherAnalysis>> callback)
    {
        string location = String.Format("location={0:F},{1:F}", lng, lat);
        Uri uri = new Uri("https://devapi.qweather.com/v7/weather/24h?" + location + "&key=42f1468340224d15aac836a4b73dad30");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                object obj = JsonConvert.DeserializeObject(webRequest.downloadHandler.text);
                Newtonsoft.Json.Linq.JObject js = obj as Newtonsoft.Json.Linq.JObject;
                if (js == null)
                    yield return null;
                callback?.Invoke(js["hourly"].ToObject<List<WeatherAnalysis>>());
            }
        }
    }

}

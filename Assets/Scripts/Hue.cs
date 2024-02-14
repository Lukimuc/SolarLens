using System.Net;
using System.IO;
using UnityEngine;
using System.Net.Http;
using System.Text;
using System;
using System.Threading.Tasks;

//This code was generated by Microsoft Copilot. After that, if altered it to fit to our example
public class RestAPIExample : MonoBehaviour
{
    private string getLightsURL = "http://192.168.178.88/api/cT9veCulwYLdWUFLanU1c1MfMGsA1NF9tkYScZFD/lights";
    private string lamp1URL = "http://192.168.178.88/api/cT9veCulwYLdWUFLanU1c1MfMGsA1NF9tkYScZFD/lights/1/state";
    private string lamp3URL = "http://192.168.178.88/api/cT9veCulwYLdWUFLanU1c1MfMGsA1NF9tkYScZFD/lights/3/state";

    private string putBrightnessBody = "{\"on\": true, \"bri\": " + 100 + "}";

    private int brightness = 0;

    private void Start()
    {
        Debug.Log(HttpGet(getLightsURL));
        changeBrightness(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeBrightness(200);
        }
    }


    //This code was generated by Microsoft Copilot
    public string HttpGet(string url)
    {
        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        string result = null;

        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            result = reader.ReadToEnd();
        }

        return result;
    }

    //This code was generated by Microsoft Copilot
    public async Task SendPutRequestAsync()
    {
        var httpClient = new HttpClient();
        var content = new StringContent(putBrightnessBody, Encoding.UTF8, "application/json");
        //Change URL here
        var response = await httpClient.PutAsync(lamp3URL, content);
        Debug.Log(response.Content);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("PUT request was successful.");
        }
        else
        {
            Console.WriteLine("PUT request failed.");
        }
    }

    public async void changeBrightness(int brighntess)
    {
        Debug.Log("Brightness: " + brighntess);
        String bright = brighntess.ToString();
        putBrightnessBody = "{\"on\": true, \"bri\": " + bright + "}";
        Debug.Log(putBrightnessBody);
        putBrightnessBody = putBrightnessBody.ToString();
        this.brightness = brightness;
        await SendPutRequestAsync();
    }
}
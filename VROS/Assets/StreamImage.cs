using UnityEngine;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using UnityEngine.Experimental.Networking;

public class StreamImage : MonoBehaviour
{
    public string url = "http://localhost:8084/";


    void Start()
    {
        StartCoroutine(LoadTexture(url, false));
    }


    void SetTexture(Texture2D texture)
    {
        //this.texture = texture;
        var render = GetComponent<Renderer>();
        if (render)
            render.material.mainTexture = texture;
        var img = GetComponent<UnityEngine.UI.Image>();
        if (img)
            img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
    }

    IEnumerator LoadTexture(string url, bool readable = true)
    {
        while (isActiveAndEnabled)
        {
            var start = Time.time;
            UnityWebRequest wr = new UnityWebRequest(url);
            DownloadHandlerTexture texDl = new DownloadHandlerTexture(readable);
            wr.downloadHandler = texDl;
            yield return wr.Send();
            if (!wr.isError)
                SetTexture(texDl.texture);
            else
                print(wr.error);
            wr.Dispose();
            print(Time.time - start);
        }
    }
}

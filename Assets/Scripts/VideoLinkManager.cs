using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Networking;

public class VideoLinkManager : MonoBehaviour
{
    public GameObject[] imageTargets;

    private void Start()
    {
        foreach (GameObject target in imageTargets)
        {
            YoutubePlayer.YoutubePlayer player = target.GetComponent<YoutubePlayer.YoutubePlayer>();
            print(player);
            StartCoroutine(BindLink(target.name, player));
        }
    }

    IEnumerator BindLink(string s, YoutubePlayer.YoutubePlayer player)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", s);

        using (UnityWebRequest www = UnityWebRequest.Post(
            "https://script.google.com/macros/s/AKfycbw8fevrBl5bDRx7G1dQha9fF8aM3k3vkaXaCbTma_FPvumwO4VdTGtHSkfsi-IWWpxj/exec",
            form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                player.youtubeUrl = www.downloadHandler.text;
                Debug.Log("complete");
            }
        }
    }
}

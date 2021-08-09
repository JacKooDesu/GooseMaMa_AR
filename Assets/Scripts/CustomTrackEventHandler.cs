using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;
public class CustomTrackEventHandler : DefaultTrackableEventHandler
{
    protected async override void OnTrackingFound()
    {
        foreach (Transform t in mTrackableBehaviour.transform)
        {
            t.gameObject.SetActive(true);
        }
        await GetComponent<YoutubePlayer.YoutubePlayer>().PlayVideoAsync();

    }

    protected override void OnTrackingLost()
    {
        foreach (Transform t in mTrackableBehaviour.transform)
        {
            t.gameObject.SetActive(false);
        }

        GetComponent<VideoPlayer>().Stop();
    }
}

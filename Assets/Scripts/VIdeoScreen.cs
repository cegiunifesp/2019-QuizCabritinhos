using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VIdeoScreen : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public RawImage rawImage;


    // Start is called before the first frame update
    public void VideoPlay()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
        while(!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
}

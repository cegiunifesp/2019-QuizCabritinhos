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
        print("Corrotine Appear");
        StartCoroutine(PlayVideo());
    }

    public void VideoPause()
    {
        videoPlayer.Stop();
    }

    IEnumerator PlayVideo()
    {
        print("Corrotine Started");
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
        while(!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        print("Corrotine Done");
    }
}

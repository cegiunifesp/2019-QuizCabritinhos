using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VIdeoScreen : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public RawImage rawImage;
    public Button button;


    private void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    // Start is called before the first frame update
    public void VideoPlay()
    {
        print("Corrotine Appear");
        StartCoroutine(PlayVideo());
        button.gameObject.SetActive(false);
    }

    public void VideoPause()
    {
        videoPlayer.Stop();
        button.gameObject.SetActive(true);
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

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        print("Acabou");
        VideoPause();
    }

}

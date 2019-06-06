using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TelaBehavior : MonoBehaviour {

    [Header("Identificação")]
    public int index;

    [Header("Animações")]
    private Animator anim;

    [Header("Animações")]
    public UnityEvent StartFI;
    public UnityEvent StartFO;
    public UnityEvent EndFI;
    public UnityEvent EndFO;

    // Use this for initialization
    void Start () {

        //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        transform.SetSiblingIndex(index: 4-index);

        anim = GetComponent<Animator>();

        if (index > 0)
            PlayFadeOut();
    }
	
	// Update is called once per frame
	void Update () {
    }



    public void PlayFadeIn()
    {
        anim.SetBool("Show", true);
        transform.SetAsLastSibling();
    }

    public void PlayFadeOut()
    {
        anim.SetBool("Show", false);
    }

    public void StartFadeIn()
    {
        StartFI.Invoke();
    }

    public void StartFadeOut()
    {
        StartFO.Invoke();
    }

    public void EndFadeIn()
    {
        EndFI.Invoke();
    }

    public void EndFadeOut()
    {
        EndFO.Invoke();
    }
}

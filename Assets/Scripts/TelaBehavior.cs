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
        
        transform.position = new Vector2(960, 540);
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
    }

    public void PlayFadeOut()
    {
        anim.SetBool("Show", false);
    }

    public void StartFadeIn()
    {

    }

    public void StartFadeOut()
    {

    }

    public void EndFadeIn()
    {

    }

    public void EndFadeOut()
    {

    }
}

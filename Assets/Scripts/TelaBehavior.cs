using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaBehavior : MonoBehaviour {

    [Header("Identificação")]
    public int index;

    [Header("Animações")]
    private Animator anim;

    // Use this for initialization
    void Start () {
        transform.position = new Vector2(0, 0);
        transform.SetSiblingIndex(index: index);

        anim = GetComponent<Animator>();
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
}

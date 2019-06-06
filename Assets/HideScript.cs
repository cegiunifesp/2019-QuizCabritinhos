using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hide()
    {
        Destroy(gameObject);
    }
}

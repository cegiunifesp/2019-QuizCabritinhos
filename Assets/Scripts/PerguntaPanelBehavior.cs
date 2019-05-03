using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerguntaPanelBehavior : MonoBehaviour {

    private PerguntaScript pergunta;
    public Text perguntaText;
    public Text[] respText;

    private PerguntaManagerBehavior pai;

    // Update is called once per frame
    void Update () {
		
	}

    public void SetPergunta(PerguntaScript p)
    {
        pergunta = p;

        perguntaText.text = p.question;

        respText[(int)Random.Range(0, 3)].text = p.rightAnsw;

        foreach(string s in p.wrongAnsw)
        {
            int id = (int)Random.Range(0, 3);

            while(respText[id].text != "New Text")
            {
                id = (id + 1) % 4;
            }

            respText[id].text = s;
        }
    }

    public void SetPai(PerguntaManagerBehavior pai)
    {
        this.pai = pai;
    }

    public void Click(Text t)
    {
        if(t.text == pergunta.rightAnsw)
        {
            //anim Certo
            print("Certo");
        }
        else
        {
            //anim Errado
            print("Errado");
        }
    }

    public void FadeOut()
    {
        gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
    }

    public void ClickNext()
    {
        pai.NextButton();
    }

    public void ClickPrev()
    {
        pai.PreviousButton();
    }
}

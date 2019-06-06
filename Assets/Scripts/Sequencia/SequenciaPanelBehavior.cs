using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenciaPanelBehavior : MonoBehaviour, IQuizPanel
{

    public static SequenciaPanelBehavior CurrentSequencia;

    private SequenciaScript sequencia;
    public Text sequenciaText;
    public Text[] topText;

    private int acertos = 0;

    private QuizManagerBehavior pai;

    public GameObject proxButton;

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSequencia(SequenciaScript s)
    {
        sequencia = s;

        sequenciaText.text = s.question;

        int i = 1;

        foreach (string t in sequencia.topicos)
        {
            int id = (int)Random.Range(0, 3);

            while (topText[id].text != "New Text")
            {
                id = (id + 1) % 4;
            }

            topText[id].text = t;

            if (topText[id].text.Length > 120)
                topText[id].fontSize = 34;

            topText[id].gameObject.transform.parent.GetComponent<TopicoBehaviour>().SetId((i).ToString());
            i++;
        }

    }

    public void SetPai(QuizManagerBehavior pai)
    {
        this.pai = pai;
    }


    public void FadeOut()
    {
        gameObject.SetActive(false);
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        CurrentSequencia = this;
    }

    public void ClickNext()
    {
        pai.NextButton();
    }

    public void ClickPrev()
    {
        pai.PreviousButton();
    }

    public void SetPiece(QuizPiece q)
    {
        SetSequencia((SequenciaScript)q);
    }

    public void Acertou()
    {
        acertos++;
        print("Certo");

        if (acertos == 4)
            proxButton.SetActive(true);
    }

    public void Errou()
    {
        acertos--;
        proxButton.SetActive(false);
        print("Errado");
    }

}

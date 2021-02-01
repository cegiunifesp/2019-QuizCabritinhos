using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PerguntaPanelBehavior : MonoBehaviour, IQuizPanel
{

    private PerguntaScript pergunta;
    public Text perguntaText;
    public Text[] respText;
    public VideoPlayer quadro;
    public VIdeoScreen videoScript;
    public GameObject proxButton;
    public Image backImage;

    private QuizManagerBehavior pai;

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPergunta(PerguntaScript p)
    {
        pergunta = p;

        perguntaText.text = p.question;

        respText[(int)Random.Range(0, 3)].text = p.rightAnsw;

        quadro.clip = p.RecursoVideo;

        backImage.sprite = p.RecursoImagem;

        foreach (string s in p.wrongAnsw)
        {
            int id = (int)Random.Range(0, 3);

            while (respText[id].text != "New Text")
            {
                id = (id + 1) % 4;
            }

            respText[id].text = s;
        }

        foreach (Text t in respText)
        {
            if (t.text.Length > 100)
                t.fontSize = 31;
            else
                t.fontSize = 45;
        }

        Object recurso = p.getRecurso();

        if (p != null)
        {
            // Exibe video ou imagem
        }


    }

    public void SetPai(QuizManagerBehavior pai)
    {
        this.pai = pai;
    }

    public void Click(Text t)
    {
        if (t.text == pergunta.rightAnsw)
        {
            //Certo
            t.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Certo");
            proxButton.SetActive(true);
            print("Certo");
        }
        else
        {
            //Errado
            t.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Errado");
            print("Errado");
        }
    }

    public void FadeOut()
    {
        gameObject.SetActive(false);
        videoScript.VideoPause();
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        videoScript.VideoPlay();
        print(Time.deltaTime);
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
        SetPergunta((PerguntaScript)q);
    }
}

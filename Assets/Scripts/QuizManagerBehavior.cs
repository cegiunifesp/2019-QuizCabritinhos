using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuizManagerBehavior : MonoBehaviour {

    [Header("Perguntas")]
    public QuizPiece[] quizPiece;

    [Header("Painel")]
    public GameObject perguntaPanel;
    public GameObject sequenciaPanel;
    private IQuizPanel[] panels;
    private int currentPanel = 0;

    [Header("Animações")]
    public UnityEvent NextTela;
    public UnityEvent PrevTela;

    // Use this for initialization
    void Start()
    {

        panels = new IQuizPanel[quizPiece.Length];

        foreach (QuizPiece q in quizPiece)
        {
            if (q.getPieceType() == "Pergunta")
            {
                GameObject go = Instantiate(perguntaPanel, transform);
                panels[currentPanel] = go.GetComponent<PerguntaPanelBehavior>();
                panels[currentPanel].SetPiece(q);
                panels[currentPanel].SetPai(this);
                panels[currentPanel].FadeOut();
                currentPanel++;
            }
            else if (q.getPieceType() == "Sequencia")
            {
                GameObject go = Instantiate(sequenciaPanel, transform);
                panels[currentPanel] = go.GetComponent<SequenciaPanelBehavior>();
                panels[currentPanel].SetPiece(q);
                panels[currentPanel].SetPai(this);
                panels[currentPanel].FadeOut();
                currentPanel++;
            }
        }

        currentPanel = 0;

        panels[currentPanel].FadeIn();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void NextButton()
    {

        if(currentPanel < panels.Length-1)
        {
            panels[currentPanel].FadeOut();
            currentPanel++;
            panels[currentPanel].FadeIn();
        }
        else
        {
            NextTela.Invoke();
        }
    }

    public void PreviousButton()
    {

        if (currentPanel > 0)
        {
            panels[currentPanel].FadeOut();
            currentPanel--;
            panels[currentPanel].FadeIn();
        }
        else
        {
            PrevTela.Invoke();
        }
    }

    public void ResetQuestions()
    {
        for(int i = panels.Length - 1; i > 0; i--)
        {
            panels[i].FadeOut();
        }

        currentPanel = 0;

        panels[currentPanel].FadeIn();

    }
}

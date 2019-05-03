using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PerguntaManagerBehavior : MonoBehaviour {

    [Header("Perguntas")]
    public PerguntaScript[] perguntas;

    [Header("Painel")]
    public GameObject perguntaPanel;
    private PerguntaPanelBehavior[] panels;
    private int currentPanel = 0;

    [Header("Animações")]
    public UnityEvent NextTela;
    public UnityEvent PrevTela;

    // Use this for initialization
    void Start()
    {

        panels = new PerguntaPanelBehavior[perguntas.Length];

        foreach (PerguntaScript p in perguntas)
        {
            GameObject go = Instantiate(perguntaPanel ,transform);
            panels[currentPanel] = go.GetComponent<PerguntaPanelBehavior>();
            panels[currentPanel].SetPergunta(p);
            panels[currentPanel].SetPai(this);
            panels[currentPanel].FadeOut();
            currentPanel++;
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
}

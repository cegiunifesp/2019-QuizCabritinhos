using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Pergunta", menuName = "Pergunta Data", order = 1)]
public class PerguntaScript : ScriptableObject
{
    [Header("Pergunta")]
    public string question;

    [Header("Respostas")]
    public string rightAnsw;
    public string[] wrongAnsw;

}

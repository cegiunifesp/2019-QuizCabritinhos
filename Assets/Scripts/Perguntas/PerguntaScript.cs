using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Nova Pergunta", menuName = "Pergunta Data", order = 1)]
public class PerguntaScript : QuizPiece
{
    [Header("Pergunta")]
    public string question;
    public Sprite RecursoImagem;
    public VideoClip RecursoVideo;

    [Header("Respostas")]
    public string rightAnsw;
    public string[] wrongAnsw;

    public override string getPieceType()
    {
        return "Pergunta";
    }

    public Object getRecurso()
    {
        if (RecursoImagem != null)
            return RecursoImagem;
        else
            return RecursoVideo;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Sequencia", menuName = "Sequencia Data", order = 1)]
public class SequenciaScript : QuizPiece
{
    [Header("Pergunta")]
    public string question;

    [Header("Respostas")]
    public string[] topicos;

    public override string getPieceType()
    {
        return "Sequencia";
    }

}

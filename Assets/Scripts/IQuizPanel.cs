using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuizPanel {
    void SetPiece(QuizPiece q);
    void SetPai(QuizManagerBehavior pai);
    void FadeOut();
    void FadeIn();
}

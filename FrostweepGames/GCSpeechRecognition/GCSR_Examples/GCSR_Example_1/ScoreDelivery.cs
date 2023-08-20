using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDelivery : MonoBehaviour
{
    public static int SceneScore = 0;

    public static void SetSceneScore(int scoreValue) {
        SceneScore = scoreValue;
    }

    public void NextonClick() { // next버튼 눌렀을 때 마지막 점수가 ScoreManager에 합산되도록 보내기
        ScoreManager.AddScore(SceneScore);
    }

}

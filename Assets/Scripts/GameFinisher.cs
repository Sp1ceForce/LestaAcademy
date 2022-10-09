using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinisher : MonoBehaviour
{
    List<LineObserver> lines = new List<LineObserver>();

    private void Start()
    {
        lines.AddRange(FindObjectsOfType<LineObserver>());
        foreach (var observer in lines)
        {
            observer.OnLineComplete += CheckForFinish;
        }
        CheckForFinish();
    }

    private void CheckForFinish()
    {
        bool isGameFinished = true;
        foreach (var line in lines)
        {
            if(!line.IsComplete) isGameFinished = false;
        }
        if (isGameFinished) FinishGame();
    }

    private void FinishGame()
    {
        SceneManager.LoadScene(1);
    }
}

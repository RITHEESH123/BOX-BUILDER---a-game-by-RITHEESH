﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public BoxSpawner box_Spawner;

    [HideInInspector]
    public BoxScript currentBox;

    public CameraFollow cameraScript;
    private int moveCount;

    private Text scoreText;
    private int score = 0;

    [HideInInspector]
    public AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        box_Spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();
            IncrementScore();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 1f);
    }
    void NewBox()
    {
        box_Spawner.SpawnBox();
    }

    public void MoveCamera()
    {
        moveCount++;

        if (moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }
    }

    void IncrementScore()
    {
        score += 5;
        scoreText.text = "Score : " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

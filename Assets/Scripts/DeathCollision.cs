using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCollision : MonoBehaviour
{

    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private AudioClip _sfx;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private Text bestScore;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text realScore;
    [SerializeField] private AudioSource levelMusic;

    public player_movement _playerMovement;


    AudioSource sfx;

    void Update()
    {
        sfx = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerPrefs.SetString("HighScore", currentScore.text);
        PauseMenuOnOff();
    }

    public void PauseMenuOnOff()
    {
        levelMusic.Stop();
        sfx.PlayOneShot(_sfx, 1);

        if (mainCanvas.activeInHierarchy)
        {
            mainCanvas.SetActive(false);
            _playerMovement._paused = true;
            pauseFunction.instance.trunPauseOn();
            SetScores();
            deathCanvas.SetActive(true);
        }


    }


    void SetScores()
    {
        currentScore.text = realScore.text;
        bestScore.text = PlayerPrefs.GetString("HighScore");
    }
}

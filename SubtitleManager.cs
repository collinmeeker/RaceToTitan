using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SubtitleManager : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    public List<string> subtitles;  // list to store multiple subtitles
    public List<float> displayTimes;  // list to store display times for each subtitle
    public AudioClip audioClip; // audio clip to play
    private int currentIndex = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (subtitles.Count > 0 && displayTimes.Count == subtitles.Count)
        {
            PlayAudio();
            DisplaySubtitle(subtitles[currentIndex], displayTimes[currentIndex]);
        }
        else
        {
            Debug.LogError("Subtitles and displayTimes lists must be of the same length.");
        }
    }

    public void DisplaySubtitle(string text, float time)
    {
        subtitleText.text = text;
        subtitleText.gameObject.SetActive(true);
        Invoke("HideSubtitle", time);
    }

    void HideSubtitle()
    {
        subtitleText.gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex < subtitles.Count)
        {
            Invoke("NextSubtitle", 0.5f);  // wait for 1 second before showing next subtitle
        }
        else
        {
            LoadMainMenu();
        }
    }

    void NextSubtitle()
    {
        DisplaySubtitle(subtitles[currentIndex], displayTimes[currentIndex]);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void PlayAudio()
    {
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }


}

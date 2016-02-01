using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public CanvasGroup startMenu;
    public CanvasGroup credits;
    public CanvasGroup tuto1;
    public CanvasGroup tuto2;
    public CanvasGroup endMonk;
    public CanvasGroup endCrane;

    public AudioClip monk;
    public AudioClip crane;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Ball.winEvent += EndGame;
    }

    void EndGame(PlayerPosition player)
    {
        Ball.winEvent -= EndGame;
        HideAll();
        if(player == PlayerPosition.RIGHT)
        {
            ShowPanel(endMonk);
            audio.clip = monk;
        }
        else
        {
            ShowPanel(endCrane);
            audio.clip = crane;
        }
        audio.Play();
    }

    public void ShowPanel(CanvasGroup panel)
    {
        HideAll();
        panel.alpha = 1;
        panel.interactable = true;
        panel.blocksRaycasts = true;
    }

    public void ReloadScene()
    {
        Ball.gameBegin = false;
        Application.LoadLevel("Main");
    }

    public void HideAll()
    {
        startMenu.alpha = 0;
        startMenu.interactable = false;
        startMenu.blocksRaycasts = false;
        credits.alpha = 0;
        credits.interactable = false;
        credits.blocksRaycasts = false;
        tuto1.alpha = 0;
        tuto1.interactable = false;
        tuto1.blocksRaycasts = false;
        tuto2.alpha = 0;
        tuto2.interactable = false;
        tuto2.blocksRaycasts = false;
        endMonk.alpha = 0;
        endMonk.interactable = false;
        endMonk.blocksRaycasts = false;
        endCrane.alpha = 0;
        endCrane.interactable = false;
        endCrane.blocksRaycasts = false;
    }

    public void StartGame()
    {
        
        HideAll();
        Ball.gameBegin = true;
    }
}

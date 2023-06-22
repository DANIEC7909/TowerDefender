using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum MusicState { MENU,GAME}
public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource as_Music;
    [SerializeField] AudioClip ac_Menu;
    [SerializeField] AudioClip[] ac_Music;
    [SerializeField] MusicState State;
    private void OnEnable()
    {
        GameEvents.OnMusicStateChanged += GameEvents_OnMusicStateChanged;
    }
    private void Start()
    {
        GameController.Instance.MusicManager = this;
    }
    public void Update()
    {
        if(State == MusicState.GAME&& !as_Music.isPlaying)
        {
            as_Music.clip = ac_Music[Random.Range(0, ac_Music.Length - 1)];
            as_Music.Play();
        }
    }
    private void GameEvents_OnMusicStateChanged(MusicState state)
    {
        switch (state)
        {
            case MusicState.MENU :
                if (as_Music != null&&ac_Menu!=null) {
                    as_Music.clip = ac_Menu;
                    as_Music.Play();
                    State = MusicState.MENU;
                }
                break;

            case MusicState.GAME:
                if (as_Music != null && ac_Menu != null)
                {
                    as_Music.clip = ac_Music[Random.Range(0, ac_Music.Length-1)];
                    as_Music.Play();
                    State = MusicState.GAME;
                }
                break;
        }
    }

    private void OnDisable()
    {
        GameEvents.OnMusicStateChanged -= GameEvents_OnMusicStateChanged;
    }
}

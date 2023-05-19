using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum MusicState { MENU,GAME}
public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource as_Music;
    [SerializeField] AudioClip ac_Menu;
    
    private void OnEnable()
    {
        GameEvents.OnMusicStateChanged += GameEvents_OnMusicStateChanged;
    }
    private void Start()
    {
        GameController.Instance.MusicManager = this;
    }
    private void GameEvents_OnMusicStateChanged(MusicState state,AudioClip clip)
    {
        switch (state)
        {
            case MusicState.MENU :
                if (as_Music != null&&ac_Menu!=null) {
                    as_Music.clip = ac_Menu;
                    as_Music.Play();
                }
                break;

            case MusicState.GAME:
                if (as_Music != null && ac_Menu != null)
                {
                    as_Music.clip = clip;
                    as_Music.Play();
                }
                break;
        }
    }

    private void OnDisable()
    {
        GameEvents.OnMusicStateChanged -= GameEvents_OnMusicStateChanged;
    }
}

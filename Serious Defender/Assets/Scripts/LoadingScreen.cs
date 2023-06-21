using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Animator anim;
    bool canFade=true;
    private void OnEnable()
    {
        GameEvents.OnFadeScreenIN += GameEvents_OnFadeScreen;
    }

    private void GameEvents_OnFadeScreen()
    {
        
        if (anim&& canFade)
        {
            canFade = false;
            anim.SetTrigger("Fade");
        }
    }
    public void OnFadeScreenOff()
    {
        GameEvents.FadeScreenOUT_c();
        canFade = true;
    }
    public void OnFadeScreenScreenCoverd()
    {
        GameEvents.FadeScreenScreenCoverd_c();
    }
    private void OnDisable()
    {
        GameEvents.OnFadeScreenIN -= GameEvents_OnFadeScreen;
    }
}

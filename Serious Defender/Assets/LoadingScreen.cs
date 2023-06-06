using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void OnEnable()
    {
        GameEvents.OnFadeScreenIN += GameEvents_OnFadeScreen;
    }

    private void GameEvents_OnFadeScreen()
    {
        if (anim)
        {
            anim.SetTrigger("Fade");
        }
    }
    public void OnFadeScreenOff()
    {
        GameEvents.FadeScreenOUT_c();
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

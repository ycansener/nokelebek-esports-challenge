using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FadeOutCanvas : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] List<Transform> allPanels;
    [SerializeField] RectTransform profilePanel;

    private bool activated;

    public void Fade()
    {

        gameObject.SetActive(true);
        fadeImage.DOFade(1f, 2f).SetDelay(1f);

        float delay = 0f;
        foreach (Transform panel in allPanels)
        {
            panel.DOMove(Vector3.up * 20f, 1f).SetEase(Ease.InBack).SetDelay(delay).OnComplete(()=> { panel.gameObject.SetActive(false); });
            delay += 0.3f;
        }

        profilePanel.DOAnchorPosY(400f, 1f).SetEase(Ease.InBack).SetDelay(delay + 0.5f).OnComplete(()=> {
            activated = true;
        });
    }

    private void Update()
    {
        if(activated)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Restart();
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}

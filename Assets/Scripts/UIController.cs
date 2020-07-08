using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField] List<Transform> panels;

    private void Start()
    {
        foreach (Transform panel in panels)
        {
            panel.gameObject.SetActive(false);
        }
    }

    public void Appear()
    {
        float delay = 0f;
        foreach(Transform panel in panels)
        {
            panel.gameObject.SetActive(true);
            panel.DOMove(Vector3.up * 10f, 1f).From().SetEase(Ease.OutBack).SetDelay(delay);
            delay += 0.15f;
        }
    }

    public void Disappear()
    {
        float delay = 0f;
        foreach (Transform panel in panels)
        {
            panel.DOMove(Vector3.up * 10f, 1f).SetEase(Ease.InBack).SetDelay(delay).OnComplete(() => {
                panel.gameObject.SetActive(false);
            });
            delay += 0.15f;
        }
    }
}

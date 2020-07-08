using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    [SerializeField] Canvas popupCanvas;

    void Start()
    {
        Appear();
    }

    public void Appear()
    {
        popupCanvas.transform.DOMove(Vector3.up * 10f, 1f).From().SetEase(Ease.OutBack);
    }

    public void Disappear()
    {
        popupCanvas.transform.DOMove(Vector3.up * 10f, 1f).SetEase(Ease.InBack).OnComplete(() => {
            gameObject.SetActive(false);
        });

        Invoke("OpenMainUIAfterDelay", 1f);
    }

    private void OpenMainUIAfterDelay()
    {
        UIController.Instance.Appear();
    }
}

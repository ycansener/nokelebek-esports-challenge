using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProfileHUD : MonoBehaviour
{
    void Start()
    {
        GetComponent<RectTransform>().DOAnchorPosY(-400f, 1f).From().SetEase(Ease.OutSine);
        //transform.DOLocalMove(Vector3.up * 2f, 1f).From().SetEase(Ease.OutBack);
    }

}

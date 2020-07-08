using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] Image bg;
    [SerializeField] bool fade = true;
    [SerializeField] UnityEvent unityEvent;

    private bool focused;

    void Update()
    {
        if(focused)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cursor"))
        {
            Focus();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cursor"))
        {
            Defocus();
        }
    }

    public void Focus()
    {
        focused = true;
        bg.transform.DOScale(1.05f, 0.5f);
        if (fade)
        {
            bg.DOFade(1f, 0.5f);
        }
    }

    public void Defocus()
    {
        focused = false;
        bg.transform.DOScale(1f, 0.5f);
        if (fade)
        {
            bg.DOFade(0.5f, 0.5f);
        }
    }

    private void Interact()
    {
        unityEvent.Invoke();
    }
}

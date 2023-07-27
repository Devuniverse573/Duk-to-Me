using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverOver;

    public void OnPointerEnter(PointerEventData envetData)
    {
        HoverOver.SetActive(true);
    }

    public void OnPointerExit(PointerEventData envetData)
    {
        HoverOver.SetActive(false);
    }
}

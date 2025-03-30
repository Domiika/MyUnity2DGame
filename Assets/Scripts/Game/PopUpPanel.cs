using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    public GameObject popUpPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        popUpPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        popUpPanel.SetActive(false);
    }
}

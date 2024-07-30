using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isClickEnabled = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 特定のUI要素にマウスがポインティングされた時の処理
        isClickEnabled = !isClickEnabled;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 特定のUI要素からマウスが離れた時の処理
        isClickEnabled = true;
    }
}

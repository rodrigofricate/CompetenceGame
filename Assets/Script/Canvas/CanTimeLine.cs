using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanTimeLine : MonoBehaviour
{
    [SerializeField] Image[] portraitArray;
    [SerializeField] Color offTimeColor;

    public Image[] GetPortraitArray() {  return portraitArray; }
    public Color GetOffTimeColor() {  return offTimeColor; }
}

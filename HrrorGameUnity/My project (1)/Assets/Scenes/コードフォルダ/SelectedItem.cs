using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    [SerializeField] GameObject Item;
    public void HighlightsItem()
    {
        Item.layer = 3;
    }

    public void LightOutItem()
    {
        Item.layer = 0;
    }
}


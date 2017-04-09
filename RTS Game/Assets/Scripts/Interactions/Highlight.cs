using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : Interaction {

    public GameObject DisplayItem;

    public override void Select()
    {
        DisplayItem.SetActive(true);

    }

    public override void Deselect()
    {
        DisplayItem.SetActive(false);

    }

    void Start ()
    {
        DisplayItem.SetActive(false);

    }

}

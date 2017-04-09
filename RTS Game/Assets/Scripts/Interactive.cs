using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour {

    private bool _selected = false;
    public bool Selected { get { return _selected; } }

    public bool Swap = false;

    public void Select()
    {
        _selected = true;
        foreach (var selection in GetComponents<Interaction>())
            selection.Select();

    }

    public void Deselect()
    {
        _selected = false;
        foreach (var selection in GetComponents<Interaction>())
            selection.Deselect();

    }

	void Start ()
    {
		

	}
	
	void Update ()
    {
		if (Swap)
        {
            Swap = false;
            if (_selected)
                Deselect();
            else Select();

        }

	}
}

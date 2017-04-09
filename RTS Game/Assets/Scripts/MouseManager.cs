using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    private List<Interactive> selections = new List<Interactive>();
	
	void Update ()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        var es = UnityEngine.EventSystems.EventSystem.current;
        if (es != null && es.IsPointerOverGameObject())
            return;

        if (selections.Count > 0)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                foreach (var s in selections)
                {
                    if (s != null)
                        s.Deselect();

                }
                selections.Clear();

            }

        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
            return;

        var interact = hit.transform.GetComponent<Interactive>();
        if (interact == null)
            return;

        selections.Add(interact);
        interact.Select();

	}
}

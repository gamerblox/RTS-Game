using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBlip : MonoBehaviour {

    private GameObject blip;    

	void Start ()
    {
        blip = GameObject.Instantiate(Map.Current.BlipPrefab);
        blip.transform.parent = Map.Current.transform;
        var color = GetComponent<Player>().info.AccentColor;
        blip.GetComponent<Image>().color = color;

	}
	
	void Update ()
    {
        blip.transform.position = Map.Current.WorldPositionToMap(transform.position);

	}

    void OnDestroy()
    {
        GameObject.Destroy(blip);

    }

}

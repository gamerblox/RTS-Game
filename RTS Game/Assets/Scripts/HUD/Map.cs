using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public RectTransform ViewPort;
    public Transform Corner1, Corner2;
    public GameObject BlipPrefab;
    public static Map Current;

    public float xOffset;
    public float yOffset;

    private Vector2 terrainSize;

    private RectTransform mapRect;

    public Map()
    {
        Current = this;

    }

    public Vector2 WorldPositionToMap(Vector3 point)
    {
        //var pos = point - Corner1.position;
        var mapPos = new Vector2(
            point.x / terrainSize.x * mapRect.rect.width ,
            point.z / terrainSize.y * mapRect.rect.height);
        return mapPos;

    }

	void Start ()
    {
        terrainSize = new Vector2(
            Corner2.position.x - Corner1.position.x,
            Corner2.position.z - Corner1.position.z);

        mapRect = GetComponent<RectTransform>();

	}
	
	void Update ()
    {
        var viewPos = WorldPositionToMap(Camera.main.transform.position);
        var tempPos = new Vector2(
            viewPos.x + xOffset,
            viewPos.y + yOffset);
        ViewPort.position = tempPos;

	}

}

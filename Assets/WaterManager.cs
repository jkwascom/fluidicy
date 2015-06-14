using UnityEngine;
using System.Collections;

public class WaterManager : MonoBehaviour {
	[Range(0f,1f)]
	public float currentWaterLevel;
	public float baseHeight;
	public float maxHeight;
	public Transform waterObject;
	public Node interlockPrefab;
	public int numInterlocks;
	public float interlockHeightOffset;

	private Vector3 v;
	// Use this for initialization
	void Start () {
		v = waterObject.position;

	}
	
	// Update is called once per frame
	void Update () {
		v.y = currentWaterLevel * maxHeight + baseHeight;
		waterObject.position = v;
	}

	public float getPressureAtHeight(float height) {
		return Mathf.Clamp01((v.y + 1.5f) - height);
	}
}

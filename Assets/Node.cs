using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {
	public Node connector;
	public WaterManager localTube;
	public InputModeManager imm;
	public float localPressure;
	public float pressureDifferential;
	
	void OnDrawGizmos(){
		if(connector != null) {
			Gizmos.color = Color.red;
			Gizmos.DrawLine(gameObject.transform.position, connector.gameObject.transform.position);
		}
	}

	void Update() {
		localPressure = localTube.getPressureAtHeight(this.transform.position.y);
		if(connector != null) {
			pressureDifferential = localPressure - connector.localTube.getPressureAtHeight(connector.transform.position.y);
			pressureDifferential = Mathf.Clamp(pressureDifferential, -.01f,.01f);
			localTube.currentWaterLevel -= pressureDifferential;
			connector.localTube.currentWaterLevel += pressureDifferential;
		}
	}

	void OnMouseDown() {
		imm.inputStart(this);
	}
}

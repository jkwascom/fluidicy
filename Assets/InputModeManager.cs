using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputModeManager : MonoBehaviour {
	public enum InputModes {
		MAKE_LINKS,
		BREAK_LINKS,
		NONE
	}

	public Node linkStartNode;
	public InputModes currentMode = InputModes.MAKE_LINKS;
	public Dictionary<InputModes, string> modeNotifications;
	public UnityEngine.UI.Text notificationBox;
	// Use this for initialization
	void Start () {
		modeNotifications = new Dictionary<InputModes, string>();
		modeNotifications[InputModes.MAKE_LINKS] = "Link Makin'";
		modeNotifications[InputModes.BREAK_LINKS] = "Link Breakin'";
	}
	
	// Update is called once per frame
	void Update () {
		notificationBox.text = "MODE: " + modeNotifications[currentMode];
	}
	
	public void setMake() {
		this.currentMode = InputModes.MAKE_LINKS;
	}
	
	public void setBreak() {
		this.currentMode = InputModes.BREAK_LINKS;
	}
	
	void OnDrawGizmos(){
		if(linkStartNode != null) {
			Gizmos.color = Color.green;
			Gizmos.DrawLine(linkStartNode.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
	}

	IEnumerator startLink(Node node) {
		linkStartNode = node;
		Debug.Log("Going for it");
		while(Input.GetMouseButton(0)) {
			yield return null;
		}
		Debug.Log("Gone for it");
		Ray finalLinkRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if(Physics.Raycast(finalLinkRay, out hitInfo)) {
			Debug.Log(hitInfo.collider.gameObject.name);
			makeLink(node, hitInfo.collider.GetComponent<Node>());
		}else {			
			Debug.Log("didn't get anything with raycast");
		}
		linkStartNode = null;
	}

	public void inputStart (Node node)
	{
		switch (currentMode) {
		case InputModes.MAKE_LINKS:
			StartCoroutine(startLink(node));
			break;
		default:
			break;
		}
	}

	void makeLink (Node node, Node node2)
	{
		Debug.Log("trying to make a link");
		if(node2 == null || node2 == node) {
			return;
		}
		
		if(node.connector != null) 
			node.connector.connector = null;
		if(node2.connector != null) 
			node2.connector.connector = null;

		node.connector = node2;
		node2.connector = node;
	}

}

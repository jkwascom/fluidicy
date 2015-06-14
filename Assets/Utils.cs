using UnityEngine;
using System.Collections;

public class Utils
{
	const float k_Spring = 50.0f;
	const float k_Damper = 5.0f;
	const float k_Drag = 10.0f;
	const float k_AngularDrag = 5.0f;
	const float k_Distance = 0.01f;
	public static SpringJoint makeSpringJoint(GameObject jointHost, GameObject joinee, Vector3 relativeAnchor) {
		var sj = jointHost.AddComponent<SpringJoint>();

		sj.anchor = relativeAnchor;
		
		sj.spring = k_Spring;
		sj.damper = k_Damper;
		sj.maxDistance = k_Distance;
		sj.connectedBody = joinee.GetComponent<Rigidbody>();
		return sj;
	}

}


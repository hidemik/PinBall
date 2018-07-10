using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour {
	
	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent < HingeJoint> ();
		SetAngle (this.defaultAngle);		
	}
	
	// Update is called once per frame
	void Update () {
			foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began && touch.position.x < Screen.width / 2 && tag == "LeftFripperTag") {
				SetAngle (this.flickAngle);
			}
			if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2 && tag == "RightFripperTag") {
				SetAngle (this.flickAngle);
			}
			if (touch.phase == TouchPhase.Ended && touch.position.x < Screen.width / 2 && tag == "LeftFripperTag") {
				SetAngle (this.defaultAngle);
			}
			if (touch.phase == TouchPhase.Ended && touch.position.x > Screen.width / 2 && tag == "RightFripperTag") {
				SetAngle (this.defaultAngle);
			}
		}
	}

	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}

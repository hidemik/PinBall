using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

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
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
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

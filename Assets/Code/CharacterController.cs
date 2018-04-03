using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MovementController {

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		velocity = new Vector2(5 * horizontal, 5 * vertical);
	}

	protected override void DetermineDirection(){
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

	}
}

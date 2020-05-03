using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Controller2D : MonoBehaviour {

    // Attach to 2D gameObject 
    // Current Rigged to LeftHand Controller 
    // To Move: Hold down triggger button and toggle trackpad as if its a toggle stick

    // Notes: 
    //  Holding down trigger while trying to move the toggle around is a 
    //  bit awkward and uncomfortable if we are to create a game where 
    //  Player holds controller after grabbing controller it should snap it place after grabbing initially 
    //  so trigger doesn't need to be held down. 
    public float m_Speed = 1f;
    public SteamVR_Action_Vector2 m_MoveValue = null;
    public SteamVR_Input_Sources leftHand;
    private void Awake() {

    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // If lefthand trigger held down 
        if (SteamVR_Input.GetState("GrabPinch", leftHand)) {
            // Calculate movement of 2D Object
            CalculateMovement();
        }
    }

    private void CalculateMovement() {
        float y_movement;
        float x_movement;
        Vector2 movement = Vector2.zero;
        // If thumb mostly in the center don't move 2D Object
        if (Mathf.Abs(m_MoveValue.axis.x) > 0.25 | Mathf.Abs(m_MoveValue.axis.y) > 0.25) {
            x_movement = -m_MoveValue.axis.x * Time.deltaTime * m_Speed;
            y_movement = m_MoveValue.axis.y * Time.deltaTime * m_Speed;
            movement = new Vector2(x_movement, y_movement);
        }
        transform.Translate(movement);
    }
}

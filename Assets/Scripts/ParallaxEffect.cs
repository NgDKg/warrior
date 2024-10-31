using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // References to game object in scene
    public Camera camera; 
    public Transform followTarget; // follow target of camera that should be the player

    // Camera moves and follow player across the screeen 
    // Parallax effect is moving each of objects based on the movement of the camera 
    // Starting position for the parallax game object
    Vector2 startingPosition;

    // Start Z value of the parallax game object
    // Z axis is going to be the distance from the camera into the bg
    float startingZ;

    // Distance that camera moved from the starting position
    Vector2 canMoveSinceStart => (Vector2)camera.transform.position - startingPosition;    

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // If object is in front of target, near clip plane. else far clip plane
    float clippingPlane => (camera.transform.position.z + (zDistanceFromTarget > 0 ? camera.farClipPlane : camera.nearClipPlane));

    // The further object from player is, the faster ParallaxEffect object will move
    // Drag to Z value to make it move slower
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + canMoveSinceStart * parallaxFactor;

        // when moving, Z position stay const
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour {

    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        Vector2 thrust = new Vector2(Random.Range(-maxThrust,maxThrust),Random.Range(-maxThrust,maxThrust));
        float torque = Random.Range (-maxTorque, maxTorque);

        rb.AddForce (thrust);
        rb.AddTorque (torque);
    }

    // Update is called once per frame
    void Update() {
        
    }
}

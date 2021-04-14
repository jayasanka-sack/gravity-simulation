using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    const float G = 66.7f;
    public Rigidbody rigidBody;
    static List<Planet> planets = new List<Planet>();
    public Vector3 initialForce;

    private void OnEnable()
    {
        // Add this planet to the planet list
        planets.Add(this);
    }

    private void Start()
    {
        // Add initial Force to the planet
        rigidBody.AddForce(initialForce);
    }

    private void FixedUpdate()
    {
        foreach (Planet planet in planets)
        {
            if(planet != this)
            {
                Attract(planet);
            }
        }
    }

    private void Attract(Planet planetToAttract)
    {
        Rigidbody rigidBodyToAttract = planetToAttract.rigidBody;
        Vector3 direction = rigidBody.position - rigidBodyToAttract.position;
        float distance = direction.magnitude;
        //F = G * m1 * m2 / r ^ 2
        float forceMagnitude = G * rigidBody.mass * rigidBodyToAttract.mass / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        // Add force to the plant to attrack
        rigidBodyToAttract.AddForce(force);
    }
}

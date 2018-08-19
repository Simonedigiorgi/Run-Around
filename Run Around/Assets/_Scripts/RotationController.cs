using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour
{
    public float speed;
    private GameObject target;

    private float randomize;
    [HideInInspector] public float minRotation = 10f;
    [HideInInspector] public float maxRotation = 100f;

    private Vector3 zAxis = new Vector3(0, 0, 2);

    private void OnEnable()
    {
        randomize = Random.Range(minRotation, maxRotation);
    }

    private void Start()
    {
        // Get the orbit
        target = GameObject.Find("Orbit_pivot");

        // Destroy the object
        Destroy(gameObject, 10f);
    }

    void FixedUpdate()
    {
        // Rotate around a target (Gravity)
        transform.RotateAround(target.transform.position, zAxis, speed);

        // Rotate around itself
        transform.Rotate(Vector3.forward * randomize * Time.deltaTime);
    }
}
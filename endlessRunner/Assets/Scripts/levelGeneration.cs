using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGeneration : MonoBehaviour
{
    public GameObject[] roadSections;  // Array of road sections
    public float x = 1f;

    void Start()
    {
        // Initialize x or perform any other setup if needed
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Generate"))
        {
            // Get a random index to choose a road section from the array
            int randomIndex = Random.Range(0, roadSections.Length);

            // Instantiate the randomly selected road section at a random position
            Instantiate(roadSections[randomIndex], new Vector3(-3.6f, 0, 55 * x), Quaternion.identity);

            x++;
        }
    }

    void Update()
    {
        // Update logic if needed
    }
}

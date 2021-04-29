using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Handles user input for the camera</summary>
public class CameraController : MonoBehaviour
{
    ///<summary>Handler for all videos in the tour.</summary>
    public VideoManager tourManager;

    // Locations of each room's center.
    private Vector3[] locations = {
        new Vector3(0f, 0f, 0f), // Living Room
        new Vector3(-250f, 0f, 250f), // Cantina
        new Vector3(250f, 0f, 250f), // Cube
        new Vector3(0f, 0f, 500f) // Mezzanine
        };

    // Reference to the quad used for fading transitions.
    private GameObject fader;

    // Start is called before the first frame update
    void Awake()
    {
        fader = GameObject.Find("Fader");
        if (fader == null)
            Debug.LogWarning("No fader found, yo!");
    }


    ///<summary>Moves the camera to another place.</summary>
    public void Relocate(int newLocation)
    {
        StartCoroutine(FadeCamera(newLocation));
        Debug.Log("Done");
    }

    IEnumerator FadeCamera(int newLocation)
    {
        Material mat = fader.GetComponent<Renderer>().material;
        // Blackout the screen to avoid motion sickness
        Debug.Log("Fade In");
        for (float alpha = 0.0f; alpha < 1.0f; alpha += 0.1f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, alpha);
            yield return new WaitForSeconds(0.05f);
        }

        Debug.Log("Changing Video");
        tourManager.currentVideo.Stop();
        tourManager.ChangeVideo(newLocation);
        tourManager.currentVideo.Play();
        this.transform.position = locations[newLocation];

        Debug.Log("Fade Out");
        for (float alpha = 1.0f; alpha > 0.0f; alpha -= 0.1f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, alpha);
            yield return new WaitForSeconds(0.05f);
        }
    }
}

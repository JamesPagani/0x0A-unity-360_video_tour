using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

///<summary>Contains functions to handle the videos of the 360 video tour.</summary>
public class VideoManager : MonoBehaviour
{
    ///<summary>Reference to the current room/video.</summary>
    [HideInInspector] public VideoPlayer currentVideo;

    // Reference to all 360 videos
    [SerializeField] private VideoPlayer[] rooms;
    
    // Runs when the game starts
    private void Start()
    {
        currentVideo = rooms[0];
    }

    ///<summary>Deactivates the current video and activates the specified target video.</summary>
    public void ChangeVideo(int targetVideo)
    {
        currentVideo = rooms[targetVideo];
    }



}

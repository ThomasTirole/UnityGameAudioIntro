using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public AudioSource audioSource;

    public CharacterController controller;

    public float footstepThreshold;

    public float footstepRate;
    private float lastFootstepTime;

    void Update()
    {
        if(controller.velocity.magnitude > footstepThreshold)
        {
            if(Time.time - lastFootstepTime > footstepRate)
            {
                lastFootstepTime = Time.time;
                audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
            }
        }
    } 


}

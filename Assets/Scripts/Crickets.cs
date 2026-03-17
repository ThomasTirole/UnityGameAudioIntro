using UnityEngine;

public class Crickets : MonoBehaviour
{
    public AudioSource audioSource;

    public float stopDistance;

    private Transform player;
    private float defaultVolume;

    void Start()
    {
        defaultVolume = audioSource.volume;
        player = FindFirstObjectByType<PlayerController>().transform;
    }


    // Update is called once per frame
    void Update()
    {
        if(player == null)
            return;
        // distance from us to the player
        float dist = Vector3.Distance(transform.position, player.position);
        if(dist < stopDistance)
            audioSource.volume = defaultVolume;
        else
            audioSource.volume = 0.0f;
    }

}

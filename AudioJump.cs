using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioJump : MonoBehaviour
{
    public AudioSource audioData;
    // Start is called before the first frame update
    private void OnEnable()
    {
        audioData.PlayOneShot(audioData.clip);
    }
}

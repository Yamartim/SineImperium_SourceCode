using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGrass : MonoBehaviour
{
    public AudioSource audioData;
    // Start is called before the first frame update
    private void OnEnable()
    {
        audioData.pitch = Random.Range(0.4f,1.6f);
        audioData.PlayOneShot(audioData.clip);
    }
}

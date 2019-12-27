using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource efcSource;
    public AudioSource backgroundSource;
    public Slider volumeslider;
    
    public static SoundManager instance = null;
    public float lowPitch = 0.95f;
    public float highPitch = 1.05f;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else if (instance!=this){
            Destroy(gameObject);
        }
      
    }
    public void playSingle() {
        float randomPitch = Random.Range(lowPitch,highPitch);
        
        efcSource.pitch = randomPitch;
        efcSource.Play();
    }
    // Update is called once per frame
}

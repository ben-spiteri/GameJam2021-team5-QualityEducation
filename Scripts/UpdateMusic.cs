using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
public class UpdateMusic : MonoBehaviour
{
    public AudioSource asource;

    // Start is called before the first frame update
    void Start()
    {
        Slider musicSlider = this.GetComponent<Slider>(); //get music slider component.

        musicSlider.value = 1;

        //Set initial sound.
        UpdateMusicVolume(musicSlider.value);
        
    }

    public void UpdateMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("musicvolume", value);
        asource.volume = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

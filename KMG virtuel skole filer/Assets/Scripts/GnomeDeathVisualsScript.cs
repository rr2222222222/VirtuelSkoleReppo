using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VisualEffectsClear : MonoBehaviour
{

    private PostProcessVolume postProcessVolume;
    private Vignette vignette;
    public GameObject PostProcessObject;
    private ColorGrading colorGrading;
    

    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume = PostProcessObject.GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out colorGrading);
         
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {



            
            vignette.intensity.value = 0.133f;
            vignette.smoothness.value = 1f;
            colorGrading.saturation.value = 0f;
            



        }
    }
}

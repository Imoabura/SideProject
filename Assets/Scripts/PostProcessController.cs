using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PostProcessController : MonoBehaviour
{
    VolumeProfile profile;
    Vignette vignette;
    LensDistortion lensDistortion;

    // Start is called before the first frame update
    void Start()
    {
        profile = GetComponent<Volume>().profile;
        profile.TryGet(out vignette);
        profile.TryGet(out lensDistortion);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.IsSymptomHeadache())
        {
            UpdateLensDistortion();
            UpdateVignette();
        }
        else
        {
            vignette.intensity.value = 0f;
            lensDistortion.intensity.value = 0f;
        }
    }

    void UpdateVignette()
    {
        vignette.intensity.value = .5f + Mathf.Sin(Time.time * 3f) * .1f;
    }

    void UpdateLensDistortion()
    {
        lensDistortion.intensity.value = Mathf.Sin(Time.time * 4f) * .2f;
    }
}

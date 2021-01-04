using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessController : MonoBehaviour
{
    Vignette vindiesel;
    LensDistortion lenny;


    // Start is called before the first frame update
    void Start()
    {
        //vindiesel = GetComponent<Vignette>();
        //lenny = GetComponent<LensDistortion>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.IsSymptomHeadache())
        {

        }
    }

    void UpdateVignette()
    {

    }

    void UpdateLensDistortion()
    {

    }
}

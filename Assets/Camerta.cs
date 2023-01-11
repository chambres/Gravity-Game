using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Camerta : MonoBehaviour
{

    public PostProcessVolume volume;
    private Vignette _V;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out _V);
        _V.intensity.value = 0;

        //StartCoroutine(Shake(1f, 10f));
    }

    public void Intensity(float value){
        _V.intensity.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        //0-.614
    }

    public IEnumerator Shake(float duration, float magnitude){
        Vector3 originalPos = new Vector3(0,0, transform.position.z);
        float elapsedTime = 0f;
        while(elapsedTime<duration){
            float xOff = Random.Range(-.05f, .05f) * magnitude;
            float yOff = Random.Range(-.05f, .05f) * magnitude;

            transform.localPosition = new Vector3(xOff, 0.00000008940697f+yOff, -10);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPos;
    }

    
}

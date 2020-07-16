using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelskid : MonoBehaviour {

    //How hard the player has to turn in order for the skidmarks to be shown in the floor
    [SerializeField] float IntensityModifier = 1.5f;
    [SerializeField] float IntensityThreshold = 0.1f;

    Skidmarks SkidMarkController;
    ArcadeKart Car;
    ParticleSystem VFX;

    //Last index of which skidmark is refering to
    int lastSkidId = -1;

	void Start () {
        SkidMarkController = FindObjectOfType<Skidmarks>();
        Car = GetComponentInParent<ArcadeKart>();
        VFX = GetComponent<ParticleSystem>();
	}
	
	void LateUpdate () {

        float intensity = Car.SideSlipAmount;
        if(intensity < 0)
        {
            intensity = -intensity;
        }

        if(intensity > IntensityThreshold)
        {
            lastSkidId = SkidMarkController.AddSkidMark(transform.position, transform.up, intensity * IntensityModifier, lastSkidId);
            if(VFX != null && !VFX.isPlaying)
            {
                VFX.Play();
            }
        }
        else
        {
            lastSkidId = -1;
            if (VFX != null && VFX.isPlaying)
            {
                VFX.Stop();
            }
        }
	}
}

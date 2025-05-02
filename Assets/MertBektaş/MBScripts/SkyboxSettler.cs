using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Skybox))]
public class SkyboxSettler : MonoBehaviour
{
    [SerializeField] List<Material> skyboxMaterials;
    Skybox skybox;
    void Awake()
    {
        skybox=GetComponent<Skybox>();
    }

    void OnEnable()
    {
        ChangeSkybox(intSkyBox:0);
    }

    private void ChangeSkybox(int intSkyBox)
    {
        if (skybox!=null && intSkyBox>=0 && intSkyBox<=skyboxMaterials.Count)
        {
            skybox.material=skyboxMaterials[intSkyBox];
        }
    }
}

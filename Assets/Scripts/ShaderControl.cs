using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private MeshRenderer renderer;
    private SphereCollider sphereCollider;
    [SerializeField] Texture2D texture1;
    [SerializeField] Texture2D texture2;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X)) {
            renderer.material.SetTexture("_pattern", texture1);
        }
        if(Input.GetKey(KeyCode.Z)) {
            renderer.material.SetTexture("_pattern", texture2);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)){ 
            sphereCollider.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) { 
            sphereCollider.enabled = true;
        }
    }
}

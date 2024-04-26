using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParalaxFondo : MonoBehaviour
{
    

    [SerializeField]
    protected Transform cam;


    [SerializeField]
    private float parallaxMulti;

    private Transform cameraTransform;
    private Vector3 previousCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPos = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    


    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPos.x) * parallaxMulti;
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPos = cameraTransform.position;
    }

   

}

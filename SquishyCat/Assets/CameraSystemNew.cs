using UnityEngine;
using System.Collections;

public class CameraSystemNew : MonoBehaviour
{

    public GameObject SC0;
    public GameObject objectToFollow0;

    public float speed = 2.0f;

    
    void FixedUpdate()
    {
        float interpolation = speed * Time.deltaTime;
        Vector3 position0 = this.transform.position;
        position0.y = Mathf.Lerp(this.transform.position.y, objectToFollow0.transform.position.y, interpolation);
        position0.x = Mathf.Lerp(this.transform.position.x, objectToFollow0.transform.position.x, interpolation);
        this.transform.position = position0;
    }
}
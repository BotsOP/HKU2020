using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConotroller : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        transform.position += transform.forward * Time.deltaTime * vert * moveSpeed;
        transform.position += transform.right * Time.deltaTime * hor * moveSpeed;
    }
}

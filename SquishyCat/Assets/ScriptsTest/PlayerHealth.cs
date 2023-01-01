using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Transform objectDetectionDown;
    public Transform objectDetectionRight;
    public Transform objectDetectionLeft;
    public Transform objectDetectionTop;
    public Transform objectDetectionRightCrouch;
    public Transform objectDetectionLeftCrouch;
    public Transform objectDetectionTopCrouch;
    public float distance;
    private static int HeadAttackForce = 0;
    private static int BottemAttackForce = 0;
    private static int FrontAttackForce = 0;
    private static int BackAttackForce = 0;
    [SerializeField] private Text five = null;


    public int healthCount = 5;
    public CharacterController2D health;
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
        if (healthCount == 0)
        {
            Die();
        }
        RaycastHit2D objectInfoDown = Physics2D.Raycast(objectDetectionDown.position, Vector2.down, distance);
        RaycastHit2D objectInfoRight = Physics2D.Raycast(objectDetectionRight.position, Vector2.right, distance);
        RaycastHit2D objectInfoLeft = Physics2D.Raycast(objectDetectionLeft.position, Vector2.left, distance);
        RaycastHit2D objectInfoTop = Physics2D.Raycast(objectDetectionTop.position, Vector2.up, distance);
        RaycastHit2D objectInfoRightCrouch = Physics2D.Raycast(objectDetectionRightCrouch.position, Vector2.right, distance);
        RaycastHit2D objectInfoLeftCrouch = Physics2D.Raycast(objectDetectionLeftCrouch.position, Vector2.left, distance);
        RaycastHit2D objectInfoTopCrouch = Physics2D.Raycast(objectDetectionTopCrouch.position, Vector2.up, distance);



        if ((objectInfoDown == true)&&(objectInfoDown.collider.tag == "Enemy"))
        {
            Debug.Log("I hit an enemy at my bottem");
        }
        if (objectInfoRight == true)
        {

        }
        if (objectInfoLeft == true)
        {

        }
        if (objectInfoTop == true)
        {

        }
        if (objectInfoRightCrouch == true)
        {

        }
        if (objectInfoLeftCrouch == true)
        {

        }
        if (objectInfoTopCrouch == true)
        {

        }
        if (healthCount <= 0)
        {

        }
    }
    void Die ()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
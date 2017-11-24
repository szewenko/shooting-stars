using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public Boundary boundary;
    public Text gradeText;

    public float speed;
    public float tilt;
    public float fireRate;

    private float nextFire;
    private double grade;

    void Update ()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate ()
     {
         float moveHorizontal = Input.GetAxis ("Horizontal");
         float moveVertical = Input.GetAxis ("Vertical");
         
		 Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		 Rigidbody rigidBody = GetComponent<Rigidbody> ();

		rigidBody.velocity = movement * speed;

		rigidBody.position = new Vector3 
         (
             Mathf.Clamp (rigidBody.position.x, boundary.xMin, boundary.xMax), 
             0.0f, 
             Mathf.Clamp (rigidBody.position.z, boundary.zMin, boundary.zMax)
         );
         rigidBody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidBody.velocity.x * -tilt);
     }

    void SetGradeText ()
    {
        gradeText.text = "Grade: " + grade.ToString();
    }
}
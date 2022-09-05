using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    int number = 1;
    int number2 = 2;

    bool isTrue;

    Vector3 myOwnPosition;

    public float movementSpeed = 5f;

    [SerializeField] float jumpingSpeed = 15f;

    string characterName = "Stefan";


    // Start is called before the first frame update
    void Start()
    {

        myOwnPosition = gameObject.transform.position;
        print(myOwnPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            Vector3 moveRight = new Vector3(1f, 0f);
            gameObject.transform.Translate(moveRight * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            Vector3 moveLeft = new Vector3(-1f, 0f);
            gameObject.transform.Translate(moveLeft * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 moveUp = new Vector3(0f, 1f);
                gameObject.transform.Translate(moveUp * Time.deltaTime * jumpingSpeed);
        }   


    }
}
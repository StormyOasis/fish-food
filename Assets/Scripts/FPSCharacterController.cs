using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class FPSCharacterController : MonoBehaviour
{
    [SerializeField]
    private MouseLook m_MouseLook = new MouseLook();        

    private CharacterController m_CharacterController;

    public Camera m_Camera;
    public float MoveSpeed = 8.0f; 
    public float RunMultiplier = 2.0f;
    public KeyCode MoveKey = KeyCode.LeftControl;
    public KeyCode RunKey = KeyCode.LeftAlt;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_MouseLook.Init(transform, m_Camera.transform);
    }

    // Update is called once per frame
    void Update()
    {
        RotateView();
    }

    private void FixedUpdate()
    {
        float speed = 0;
        if (Input.GetKey(MoveKey))
            speed = MoveSpeed;
        if (Input.GetKey(RunKey))
            speed *= RunMultiplier;

        Vector3 desiredMove = m_Camera.transform.forward * speed + m_Camera.transform.right * speed;

        m_CharacterController.Move(desiredMove * Time.fixedDeltaTime);
    }

    private void RotateView()
    {
        m_MouseLook.LookRotation(transform, m_Camera.transform);
    }
}

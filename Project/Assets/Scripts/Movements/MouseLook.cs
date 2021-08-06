using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    private float mouseSensitivity = 50.0f;

    [SerializeField]
    private Transform playerBody;

    [SerializeField]
    private float TopClamp = 90f;
    [SerializeField]
    private float BottomClamp = -90f;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 좌표계 x와 회전 값 x의 방향은 서로 반대이다.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, BottomClamp, TopClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
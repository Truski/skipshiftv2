using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    #region Public Fields
    public float lookSensitivity;
    public float minXRot;
    public float maxXRot;
    public Transform camAnchor;
    #endregion

    #region Private Fields
    private float curXRot;
    #endregion

    #region Unity Calls
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Getting mouse input
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        // Rotate the player horizontally, in turn rotating the camera
        this.transform.eulerAngles += Vector3.up * x * this.lookSensitivity;

        // Vertical camera rotation
        this.curXRot -= y * this.lookSensitivity;
        this.curXRot = Mathf.Clamp(this.curXRot, this.minXRot, this.maxXRot);

        Vector3 clampedAngle = this.camAnchor.eulerAngles;
        clampedAngle.x = this.curXRot;
        this.camAnchor.eulerAngles = clampedAngle;
    }
    #endregion
}

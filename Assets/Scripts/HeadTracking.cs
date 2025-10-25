using Mediapipe;
using Mediapipe.Tasks.Vision.FaceLandmarker;
using Mediapipe.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTracking : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float smoothSpeed = 5f;

    private float yaw = 0f;
    private float pitch = 0f;
    private Quaternion targetRotate = Quaternion.identity;

    public void MoveCamera(FaceLandmarkerResult result) 
    { 
        var faceLandmarks = result.faceLandmarks[0];

        var nose = faceLandmarks.landmarks[4];
        var leftEye = faceLandmarks.landmarks[33];
        var rightEye = faceLandmarks.landmarks[263];
        var chin = faceLandmarks.landmarks[152];


        // Horizontal rotation (yaw)
        float faceWidth = Mathf.Abs(rightEye.x - leftEye.x);
        yaw = (nose.x - (leftEye.x + rightEye.x) / 2f) / faceWidth;

        // Vertical rotation (pitch)
        float faceHeight = Mathf.Abs(chin.y - nose.y);
        pitch = (nose.y - (chin.y + leftEye.y + rightEye.y) / 3f) / faceHeight;

        // Amplify
        yaw = Mathf.Clamp(yaw * 120f, -40f, 40f);
        pitch = Mathf.Clamp(pitch * 120f, -30f, 30f);

        targetRotate = Quaternion.Euler(pitch, yaw, 0);
    }

    private void Update()
    {
        _mainCamera.transform.localRotation = Quaternion.Slerp(
            _mainCamera.transform.localRotation,
            targetRotate,
            Time.deltaTime * smoothSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{

    public CinemachineVirtualCamera startCamera;
    public CinemachineVirtualCamera ShotCamera;

    public int camera_N = 0;

    public enum Camera_Number { Start = 0, Shot = 11 };
    void Awake()
    {
        startCamera.Priority = 11;
        ShotCamera.Priority = 0;

        camera_N = 0;
    }

    void Update()
    {

    }

    public void ChangeCamera()
    {

        if (camera_N == (int)Camera_Number.Start)
        {// 현재 상태가 start면 shot으로 바꿈

            camera_N = (int)Camera_Number.Shot;

            startCamera.Priority = 0;
            ShotCamera.Priority = 11;
        }
        else if (camera_N == (int)Camera_Number.Shot)
        {
            camera_N = (int)Camera_Number.Start;

            startCamera.Priority = 11;
            ShotCamera.Priority = 0;
        }
    }
}

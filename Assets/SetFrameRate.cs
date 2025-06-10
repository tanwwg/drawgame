using System;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
}

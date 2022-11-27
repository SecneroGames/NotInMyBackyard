using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource buttonSFX;

    public void playButtonSFX()
    {
        buttonSFX.Play();
    }
}
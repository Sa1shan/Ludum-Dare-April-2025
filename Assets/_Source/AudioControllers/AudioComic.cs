using System.Collections;
using System.Collections.Generic;
using _Source.AudioControllers;
using UnityEngine;

public class AudioComic : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.Instance?.PlayObject1Music();
    }
}

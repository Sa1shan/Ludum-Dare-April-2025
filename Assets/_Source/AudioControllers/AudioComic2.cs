using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioComic2 : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.Instance?.PlayObject2Music();
    }
}

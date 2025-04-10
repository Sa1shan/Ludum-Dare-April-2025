using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioComic : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.Instance?.PlayObject1Music();
    }
}

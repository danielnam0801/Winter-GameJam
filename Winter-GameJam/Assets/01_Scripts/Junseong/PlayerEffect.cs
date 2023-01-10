using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] GameObject dustParticle;
    [SerializeField] GameObject criticialEffectImage;
    [SerializeField] Vector3 ImagePos;

    public void CriticialImageSpawn()
    {
        GameObject image = Instantiate(criticialEffectImage, transform.position + ImagePos, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private Animator _noteHitAnimator = null;
    string hit = "Hit";

    public void NodeHitEffect()
    {
        _noteHitAnimator.SetTrigger(hit); 
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Rendering;
/// <summary>
/// i need this script to handle the animation and the animations rigging for any character in the game 
/// so far only for now is the animator and the multi aim constrant that we need to worry about 
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(RigBuilder))]
public class AnimationAndRiggingManager : MonoBehaviour
{
    private Animator m_Animator;
    private RigBuilder m_RigBuilder;
    [SerializeField] private MultiAimConstraint m_MultiAimConstraint;
    private bool _Animtor;
    private void Awake()
    {
        TryGetComponent<Animator>(out m_Animator);
        TryGetComponent<RigBuilder>(out m_RigBuilder);
        _Animtor = TryGetComponent(out m_Animator);
        Debug.Log(_Animtor);
        
    }
    public void TriggerAnimationsWithInt()
    {

    } 


}

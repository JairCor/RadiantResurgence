using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantAI : MonoBehaviour
{
    public Mutant mutant;
    public Character targetCharacter;

    MutantAIState currentState;
    public MutantAIChaseState chaseState{get; private set;}
    public MutantAIDieState dieState{get; private set;}

    public void ChangeState(MutantAIState newState){
        currentState = newState;
        currentState.BeginStateBase();
    }

    public void Start()
    {
        chaseState = new MutantAIChaseState(this);
        dieState = new MutantAIDieState(this);
        currentState = chaseState;
    }
    void FixedUpdate()
    {
        currentState.UpdateStateBase();
    }

    public Character GetTarget(){
        if(Vector3.Distance(transform.position, targetCharacter.transform.position) < 1000){
            return targetCharacter;
        }
        else{
            return null;
        }
    }
}

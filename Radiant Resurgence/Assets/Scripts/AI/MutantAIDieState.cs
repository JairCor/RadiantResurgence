using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantAIDieState : MutantAIState
{

    public MutantAIDieState(MutantAI mutantAI) : base(mutantAI){}


    public override void BeginState()
    {
        //mutantAI.mutant.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public override void UpdateState()
    {
        //if(mutantAI.GetTarget()!=null){
          //  mutantAI.mutant.MoveMutantToward(mutantAI.GetTarget().transform.position);
        //}
    }
}

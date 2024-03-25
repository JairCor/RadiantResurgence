using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MutantAIState
{
    protected MutantAI mutantAI;
    protected float timer = 0;
    public MutantAIState(MutantAI newAI){
        mutantAI = newAI;
    }

    public void UpdateStateBase(){
        timer += Time.fixedDeltaTime;
        UpdateState();
    }

    public void BeginStateBase(){
        timer = 0;
        BeginState();
    }

    public abstract void UpdateState();
    public abstract void BeginState();
}

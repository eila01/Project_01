using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abstract classes like this are different than abstract methods, despite them sharing the same
keyword – abstract classes cannot be instanced and can only be inherited. 
 * Abstract methods can be called,
but can ONLY be inherited from if they finish defining the method. 
 */
public abstract class State 
{
    public float StateDuration { get; private set; } = 0;

    // run once when state is entered
    public virtual void Enter()
    {
        StateDuration = 0;
    }

    // run once when state is exited 
    public virtual void Exit()
    {

    }

    // for Physics
    public virtual void FixedTick()
    {

    }

    // for Update
    public virtual void Tick()
    {
        StateDuration += Time.deltaTime;
    }
    
}

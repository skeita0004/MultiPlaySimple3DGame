using UnityEngine;

public interface IInput
{
    Vector2 move 
    { 
        get;
        set;
    }

    Vector2 look
    {  
        get;
        set;
    }

    bool attack
    {
        get;
        set;
    }

    bool sprint
    { 
        get;
        set;
    }

    bool guard
    {
        get;
        set;
    }

    bool ok
    {
        get;
        set;
    }

}

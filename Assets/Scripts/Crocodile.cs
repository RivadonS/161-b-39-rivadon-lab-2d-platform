using UnityEngine;

public class Crocodile : Enemy
{
    void Start()
    {
        base.Initialize(50); //set health for crocodile
    }

    public override void Behavior()
    {
        throw new System.NotImplementedException();
    }
}

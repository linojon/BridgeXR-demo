using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatedPosition : MonoBehaviour
{
    public enum Sex
    {
        Male,Female
    }

    public Sex CurrentSex = Sex.Male;
    public Transform ChairHeightTransform;
    public Transform EyeLevelTransform;

    void OnValidate()
    {
        if(!EyeLevelTransform || !ChairHeightTransform)
            return;
        
        Vector3 chairPosition = ChairHeightTransform.position;
        switch (CurrentSex)
        {
            case Sex.Male:
                chairPosition.y += .790f;
                break;
            case Sex.Female:
                chairPosition.y += .740f;
                break;
        }
        
        EyeLevelTransform.position = chairPosition;

    }
}

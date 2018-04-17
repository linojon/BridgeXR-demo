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
    public GameObject DummyGuy;
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

    void OnDrawGizmos()
    {
        if (DummyGuy)
        {
            MeshFilter[] meshFilters = DummyGuy.GetComponentsInChildren<MeshFilter>();
            for (int i = 0; i < meshFilters.Length; i++)
            {
                Vector3 localScale = meshFilters[i].transform.localScale + transform.localScale;
                Vector3 localPosition = meshFilters[i].transform.localPosition + transform.position;
                Quaternion localRotation = meshFilters[i].transform.localRotation * transform.rotation;
                Gizmos.color = Color.green;
                Gizmos.DrawMesh(meshFilters[i].sharedMesh, localPosition, localRotation, localScale);
            }
        }
   
    }
}

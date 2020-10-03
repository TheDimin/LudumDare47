using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;


public class ConveyorBelt : MonoBehaviour
{
    [Header("Auto")]
    [SerializeField] private GameObject ConveyorBeltObject;
    [SerializeField] private Material ConveyorMaterial;

    private GameObject BoxA;
    private GameObject BoxB;

    private List<GameObject> conveyorInstances;

    private List<GameObject> attachedObjects = new List<GameObject>();
    public float speed { get; private set; } = 1;

    private void Update()
    {
        foreach (var attachedObj in attachedObjects)
        {
            attachedObj.transform.localPosition += Vector3.forward * (speed * Time.deltaTime);
        }
    }

    [Button("SetConveyorBelts")]
    private void SetConveyorBelts()
    {
        ValidateVariables();

        var distance = BoxB.transform.position.z - BoxA.transform.position.z;

        foreach (var instance in conveyorInstances)
        {
            DestroyImmediate(instance, false);
        }

        conveyorInstances.Clear();
        Transform conveyorHolder = transform.Find("Conveyors");
        if (conveyorHolder == null)
        {
            conveyorHolder = new GameObject("Conveyors").transform;
            conveyorHolder.SetParent(transform);
            conveyorHolder.localPosition = Vector3.zero;
        }

        var boxApos = BoxA.transform.position;

        var width = ConveyorBeltObject.GetComponent<MeshRenderer>().bounds.extents.z * 2;

        var amount = distance - width - 1;

        for (int i = 0; i < amount; i++)
        {
            conveyorInstances.Add(GameObject.Instantiate(ConveyorBeltObject, boxApos + Vector3.forward * (width * i), Quaternion.identity, conveyorHolder));
        }
    }

    private void ValidateVariables()
    {
        if (BoxA != transform.Find("ConveyorBoxA"))
        {
            var boxATrans = transform.Find("ConveyorBoxA");
            Debug.Assert(boxATrans, "Failed to find 'ConveyorBoxA' in" + this.ToString());
            BoxA = boxATrans.gameObject;
        }

        if (BoxB != transform.Find("ConveyorBoxB"))
        {
            var boxBTrans = transform.Find("ConveyorBoxB");
            Debug.Assert(boxBTrans, "Failed to find 'ConveyorBoxB' in" + this.ToString());
            BoxB = boxBTrans.gameObject;
        }
    }

    public void AttachObject(GameObject obj)
    {
        ValidateVariables();

        if (attachedObjects.Contains(obj))
        {
            Debug.LogError("Attempted to attach a item that was already attached");
            return;
        }

        attachedObjects.Add(obj);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = BoxA.transform.localPosition;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        ConveyorMaterial.SetFloat("Vector1_EA6D7116", speed);
    }


}

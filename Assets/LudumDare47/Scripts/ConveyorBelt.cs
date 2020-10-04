using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;


public class ConveyorBelt : MonoBehaviour
{
    [Header("Auto")]
    [SerializeField] private GameObject ConveyorBeltObject = null;
    [SerializeField] private Material ConveyorMaterial = null;

    private GameObject BoxA;
    private Cloth clothA;
    private GameObject BoxB;
    private Cloth clothB;

    [SerializeField, HideInInspector] private List<GameObject> conveyorInstances = new List<GameObject>();

    [SerializeField, HideInInspector] private Transform hitTransform;
    private float hitLocation;

    private List<GameObject> attachedObjects = new List<GameObject>();
    public Transform AttachPoint { get; set; }
    public Transform WrapAroundLocation { get; set; }
    private Transform conveyorHolder;
    private static readonly int SpeedMatProp = Shader.PropertyToID("Vector1_EA6D7116");
    public float speed { get; private set; } = 1;

    private void Awake()
    {
        SetSpeed(speed);//

        ValidateVariables();
        if (hitTransform == null)
        {
            hitTransform = transform.Find("HitLocation");

            Debug.Assert(hitTransform, "Failed to find HitLocation in child objects");
        }

        hitLocation = hitTransform.localPosition.z;
    }

    private void Update()
    {
        UpdateObjectLocations();
    }

    private void UpdateObjectLocations(bool checkForPause = true)
    {
        List<GameObject> MarkedForRemove = new List<GameObject>();
        foreach (var attachedObj in attachedObjects)
        {

            if (attachedObj.transform.parent != transform)
            {
                MarkedForRemove.Add(attachedObj);
                continue;
            }

            attachedObj.transform.localPosition += Vector3.forward * (speed * Time.deltaTime);

            if (Math.Abs(attachedObj.transform.localPosition.z - hitLocation) < (speed * Time.deltaTime) * .5f)
            {
                SetSpeed(0);
            }

            if (Vector3.Distance(attachedObj.transform.localPosition, WrapAroundLocation.localPosition) < .5f)
            {
                clothA.enabled = false;
                clothB.enabled = false;
                //reataching would fuck up list ordering
                attachedObj.transform.localPosition = AttachPoint.localPosition;
                clothA.enabled = true;
                clothB.enabled = true;
            }
        }

        foreach (var markedRemoveObj in MarkedForRemove)
        {
            attachedObjects.Remove(markedRemoveObj);
        }
    }

    [Button()]
    private void SetSpeed()
    {
        SetSpeed(1);
        SetSpeed(1);
    }

    [SerializeField] private GameObject spawnGameObject;
    [Button()]
    private void AddTestObject()
    {
        var obj = GameObject.Instantiate(spawnGameObject, Vector3.forward, Quaternion.identity);
        AttachObject(obj);
    }

    [Button("SetConveyorBelts")]
    private void SetConveyorBelts()
    {
        ValidateVariables();

        var distance = (BoxB.transform.position - BoxA.transform.position).magnitude;

        foreach (var instance in conveyorInstances)
        {
            DestroyImmediate(instance, true);
        }

        conveyorInstances.Clear();


        var boxApos = BoxA.transform.position;

        var width = ConveyorBeltObject.GetComponent<MeshRenderer>().bounds.extents.z * 2f;

        var amount = distance / width;

        for (int i = 0; i < amount; i++)
        {
            conveyorInstances.Add(GameObject.Instantiate(ConveyorBeltObject, boxApos + Vector3.forward * (width * i), Quaternion.identity, conveyorHolder));
        }
    }

    private void ValidateVariables()
    {
        if (BoxA != transform.Find("ConveyorBoxA").gameObject)
        {
            var boxATrans = transform.Find("ConveyorBoxA");
            Debug.Assert(boxATrans, "Failed to find 'ConveyorBoxA' in" + this.ToString());
            BoxA = boxATrans.gameObject;
        }

        if (BoxB != transform.Find("ConveyorBoxB").gameObject)
        {
            var boxBTrans = transform.Find("ConveyorBoxB");
            Debug.Assert(boxBTrans, "Failed to find 'ConveyorBoxB' in" + this.ToString());
            BoxB = boxBTrans.gameObject;
        }

        conveyorHolder = transform.Find("Conveyors");
        if (conveyorHolder == null)
        {
            conveyorHolder = new GameObject("Conveyors").transform;
            conveyorHolder.SetParent(transform);
        }
        Debug.Assert(conveyorHolder, "conveyorHolder GameObject not found");

        WrapAroundLocation = transform.Find("WrapAround");
        Debug.Assert(WrapAroundLocation, "WrapAround not found");

        AttachPoint = transform.Find("AttachPoint");
    }

    public void AttachObject(GameObject obj)
    {
        ValidateVariables();

        if (attachedObjects.Contains(obj))
        {
            Debug.LogError("Attempted to attach a item that was already attached");
            return;
        }

        var sc = obj.AddComponent<SphereCollider>();
        if (clothA == null)
        {
            clothA = BoxA.transform.GetComponentInChildren<Cloth>();
        }
        if (clothB == null)
        {
            clothB = BoxB.transform.GetComponentInChildren<Cloth>();
        }



        attachedObjects.Add(obj);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = AttachPoint.localPosition;

        clothA.enabled = false;

        var colliders = new ClothSphereColliderPair[1];
        colliders[0] = new ClothSphereColliderPair(sc);

        clothA.sphereColliders = colliders;
        clothB.sphereColliders = colliders;

        clothA.enabled = true;
    }

    public void DetachObject(GameObject obj)
    {
        attachedObjects.Remove(obj);
        obj.transform.SetParent(null);
    }

    public void SetSpeed(float newSpeed)
    {
        if (Math.Abs(speed) < .1f)
        {
            foreach (var attachedObj in attachedObjects)
            {
                attachedObj.transform.localPosition += Vector3.forward * (speed * Time.deltaTime);
            }
        }

        speed = newSpeed;
        ConveyorMaterial.SetFloat(SpeedMatProp, speed);
    }
}

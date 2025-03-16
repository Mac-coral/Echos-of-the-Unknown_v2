using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/*
 * For the light up system to work, there must be a mutable list of material objects
 * Explore through every parent and child to then tie them
 * with a data structure of transform and mesh renderer
 * 
 * of the game object does not have a mesh renderer, skip the renderer
 * if the game object has a mesh renderer,
 * then get the first material and save a copy of it for restoring vision
 * the copied material will be presered
 * 
 * There will always be the black material as ligh turn off
 * while the saved material is light turn on
 * 
 * 
 * When the player collides with the light up object,
 * turn on the object from black to default color, and then set a timer for a limtied time
 * when timer runs out, the light goes back to black
 * 
 * timer does not begin until player exits collision of the game object
 * when player enters collision with the object, and timer is running, reset timer and still keep light on
 * 
 */

public class LightupObject : MonoBehaviour
{

    [SerializeField] private Material blackoutMaterial;
    [SerializeField] private float timerLightRemainOn = 2f;

    private List<GameObjectMaterial> materialObjectsList;

    private float timerRemaining;
    private bool timerActive;

    private void Awake()
    {
        materialObjectsList = new List<GameObjectMaterial>();
        GetObjectAndMaterialMatch(transform);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetToBlack();
    }

    // Update is called once per frame
    void Update()
    {
        LightsOnTimer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            EnterCollision();
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.transform.tag.Equals("Player"))
        {
            ExitCollision();
        }
    }

    public void ExitCollision()
    {
        timerActive = true;
    }

    public void EnterCollision()
    {
        SetToBright();
        timerActive = false;
        timerRemaining = timerLightRemainOn;
    }

    // Relies on recusion to obtain the proper materials for default material
    // before going black for blindness.
    private void GetObjectAndMaterialMatch(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.GetComponent<MeshRenderer>() != null)
            {
                SetGameObjectAndMaterialMatch(child.gameObject);
            }
            GetObjectAndMaterialMatch(child);
        }
    }

    private void SetGameObjectAndMaterialMatch(GameObject targetObject)
    {
        MeshRenderer renderer = targetObject.GetComponent<MeshRenderer>();
        Material targetMaterial = renderer.material;

        GameObjectMaterial item = new()
        {
            targetObject = targetObject,
            targetMaterial = new Material(targetMaterial)
        };

        materialObjectsList.Add(item);
    }

    private void SetToBlack()
    {
        foreach (GameObjectMaterial item in materialObjectsList)
        {
            var renderer = item.targetObject.GetComponent<MeshRenderer>();
            renderer.material = blackoutMaterial;
        }
    }

    private void SetToBright()
    {
        foreach (GameObjectMaterial item in materialObjectsList)
        {
            var renderer = item.targetObject.GetComponent<MeshRenderer>();
            renderer.material = item.targetMaterial;
        }
    }

    private void LightsOnTimer()
    {
        if (!timerActive) return;

        timerRemaining -= Time.deltaTime;
        if (timerRemaining <= 0f)
        {
            SetToBlack();
            timerActive = false;
        }
    }
}

public struct GameObjectMaterial
{
    public GameObject targetObject;
    public Material targetMaterial;
}



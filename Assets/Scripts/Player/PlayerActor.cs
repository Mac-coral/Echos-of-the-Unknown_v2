using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var targetLightup = LookForLightOutParent(collision.transform);
        if (targetLightup != null)
        {
            targetLightup.EnterCollision();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        var targetLightup = LookForLightOutParent(collision.transform);
        if (targetLightup != null)
        {
            targetLightup.ExitCollision();
        }

    }

    private LightupObject LookForLightOutParent(Transform targetTransform)
    {
        LightupObject targetLighup = targetTransform.GetComponent<LightupObject>();
        if (targetTransform.parent != null && targetLighup == null)
        {
            targetLighup = LookForLightOutParent(targetTransform.parent);
        }
        return targetLighup;
    }
}

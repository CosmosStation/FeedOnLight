using System.Collections;
using UnityEngine;
using RootMotion.FinalIK;

public class LegControl : MonoBehaviour
{
    public FABRIK[] fabrikComponents;
    public Transform[] ikTargets;
    public float stepDistance = 1f;
    public float stepHeight = 0.5f;
    public float stepDuration = 0.5f;
    public Vector3 walkingDirection = Vector3.forward;
    public Animator animator;
    public float animationSpeedMultiplier = 1f;
    
    private int currentLeg = 0;
    
    void Update()
    {
        if (Vector3.Distance(ikTargets[currentLeg].position, transform.position + walkingDirection * stepDistance) > stepDistance)
        {
            StartCoroutine(TakeStep(currentLeg));
            currentLeg = (currentLeg + 1) % ikTargets.Length;
        }
        
        float speed = walkingDirection.magnitude * animationSpeedMultiplier;
        animator.SetFloat("speed", speed);
    } 
    
    private IEnumerator TakeStep(int legIndex)
    {
        Vector3 startPosition = ikTargets[legIndex].position;
        Vector3 targetPosition = transform.position + walkingDirection * stepDistance;
        float startTime = Time.time;

        while (Time.time < startTime + stepDuration)
        {
            float progress = (Time.time - startTime) / stepDuration;
            float yOffset = Mathf.Sin(progress * Mathf.PI) * stepHeight;
            ikTargets[legIndex].position = Vector3.Lerp(startPosition, targetPosition, progress) + Vector3.up * yOffset;
            yield return null;
        }

        ikTargets[legIndex].position = targetPosition;
    }
    
}

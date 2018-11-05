using UnityEngine;

public class ModelTrackableEventHandler : DefaultTrackableEventHandler
{

    public Animator animator;


    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        animator.ResetTrigger("reset");
        animator.SetTrigger("play");
    }


    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        animator.ResetTrigger("play");
        animator.SetTrigger("reset");
    }
}

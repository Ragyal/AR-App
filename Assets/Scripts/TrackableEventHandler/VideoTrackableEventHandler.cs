public class VideoTrackableEventHandler : DefaultTrackableEventHandler
{

    public UIManager uiManager;


    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        this.uiManager.EnableControls();
    }


    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        this.uiManager.DisableControls();
    }
}

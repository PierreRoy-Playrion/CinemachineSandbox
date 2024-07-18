namespace CinemachineSandbox
{
    public class BuildingSelector : Selector<Building>
    {
        protected override void OnDeselect(Building selection)
        {
            selection.Camera.enabled = false;
        }
    }
}
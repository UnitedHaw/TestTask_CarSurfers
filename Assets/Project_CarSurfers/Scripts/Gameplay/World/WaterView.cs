
namespace Assets.Project_CarSurfers.Scripts.Gameplay.World
{
    public class WaterView : PlateView
    {
        protected override void DisableAction()
        {
            gameObject.SetActive(false);
        }

        protected override void EnableAction()
        {
            gameObject.SetActive(true);
        }
    }
}

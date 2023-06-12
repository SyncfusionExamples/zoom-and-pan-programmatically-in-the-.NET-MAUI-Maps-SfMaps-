using Syncfusion.Maui.Maps;

namespace MapProgrammaticZoomPan
{
    public class MapsBehavior : Behavior<ContentPage>
    {
        private MapTileLayer layer;
        private Button ZoomPanButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.layer = bindable.FindByName<MapTileLayer>("layer");
            this.ZoomPanButton = bindable.FindByName<Button>("ZoomPanButton");
            this.ZoomPanButton.Clicked += ZoomPanButton_Clicked;
        }

        private void ZoomPanButton_Clicked(object sender, EventArgs e)
        {
            this.layer.ZoomPanBehavior = new MapZoomPanBehavior();
            this.layer.ZoomPanBehavior.ZoomLevel = 4;
            this.layer.Center = new MapLatLng(-19.49, 132.55);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.ZoomPanButton != null)
            {
                this.ZoomPanButton.Clicked -= ZoomPanButton_Clicked;
            }

            this.ZoomPanButton = null;
            this.layer = null;
        }
    }
}

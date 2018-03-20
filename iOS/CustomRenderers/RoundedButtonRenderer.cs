using PhoneDirectory.Core.CustomRenderers;
using PhoneDirectory.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRenderer))]
namespace PhoneDirectory.iOS.CustomRenderers
{
    public class RoundedButtonRenderer : ButtonRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = 22;
                Control.ClipsToBounds = true;
            }
		}
	}
}

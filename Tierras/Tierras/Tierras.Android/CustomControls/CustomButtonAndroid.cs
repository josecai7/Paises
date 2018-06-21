using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Tierras.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Tierras1.CustomControls;

[assembly: ExportRenderer( typeof( CustomButton ), typeof( CustomButtonAndroid ) )]
namespace Tierras.Droid.CustomControls
{
    public class CustomButtonAndroid:ButtonRenderer
    {
        public CustomButtonAndroid(Context context) : base( context )
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged( e );

            if ( Control != null )
            {
                // remove default background image
                Control.Background = null;
                Control.SetBackgroundColor( Element.BackgroundColor.ToAndroid() );
            }
        }
    }
}
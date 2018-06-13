using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tierras.CustomControls;
using Tierras.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer( typeof( CustomEntry ), typeof( CustomEntryAndroid ) )]
namespace Tierras.Droid.CustomControls
{
    public class CustomEntryAndroid:EntryRenderer
    {
        public CustomEntryAndroid(Context context) : base( context )
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged( e );
            Control?.SetBackgroundColor( Android.Graphics.Color.Transparent );
            Control.Gravity = GravityFlags.CenterVertical;
        }
    }
}
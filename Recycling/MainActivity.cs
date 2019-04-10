using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Recycling
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            Button bt = FindViewById<Button>(Resource.Id.submit);
            bt.Click += Bt_Click;
            bt.Text = "ارسال کد تایید";
            bt.Enabled = false;
            EditText ed = FindViewById<EditText>(Resource.Id.InputNumber);
            ed.TextChanged += Ed_TextChanged;

        }

        private void Ed_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            EditText ed = FindViewById<EditText>(Resource.Id.InputNumber);
            if (ed.Text.Length >= 10)
            {
                Button bt = FindViewById<Button>(Resource.Id.submit);
                bt.Enabled = true;
            }
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            EditText ed = FindViewById<EditText>(Resource.Id.InputNumber);
            ed.Text = "";
            ed.Hint = "کد فعال سازی را وارد کنید";
            ed.TextChanged += Ed_TextChanged1;


            Button bt = FindViewById<Button>(Resource.Id.submit);
            bt.Text = "تایید";
            bt.Enabled = false;

        }

        private void Ed_TextChanged1(object sender, Android.Text.TextChangedEventArgs e)
        {
            EditText ed = FindViewById<EditText>(Resource.Id.InputNumber);



       
            if (ed.Text.Length == 4)
            {
                Button bt = FindViewById<Button>(Resource.Id.submit);
                bt.Enabled = true;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "ssss", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}


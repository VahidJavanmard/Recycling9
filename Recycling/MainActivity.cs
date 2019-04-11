using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Recycling
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Toolbar myToolbar;
        private ListView MyListView;
        private List<string> List;

        private ManageDrawer manageDrawer;
        private DrawerLayout MyDrawer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);

           
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
                bt.Click += Bt_Click1;
            }
        }

        private void Bt_Click1(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Map);
            myToolbar = FindViewById<Toolbar>(Resource.Id.MyToolBar);
            SetSupportActionBar(myToolbar);
            MyListView = FindViewById<ListView>(Resource.Id.MyListView);

            List = new List<string>()
            {

                "اطلاعات کاربری",
                "تاریخچه",
                "آدرس های منتخب",
                "پیام ها",
                "پشتیبانی",
                "تنظیمات",
                "درباره ما",
                "خروج",


            };
            MyListView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, List);
            MyListView.ItemClick += MyListView_ItemClick;



            MyDrawer = FindViewById<DrawerLayout>(Resource.Id.MyDrawer);
            MyListView.Tag = 0;
            manageDrawer = new ManageDrawer(this, MyDrawer, Resource.String.openDrawer, Resource.String.closeDrawe);
            MyDrawer.SetDrawerListener(manageDrawer);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            manageDrawer.SyncState();

            //if (savedInstanceState != null)
            //{
            //    if (savedInstanceState.GetString("DrawerState") == "Opend")
            //    {
            //        SupportActionBar.SetTitle(Resource.String.openDrawer);
            //    }
            //    else
            //    {
            //        SupportActionBar.SetTitle(Resource.String.closeDrawe);
            //    }
            //}
            //else
            //{
            //    SupportActionBar.SetTitle(Resource.String.closeDrawe);
            //}


        }

        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, List[e.Position], ToastLength.Short).Show();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                {
                    MyDrawer.CloseDrawer(MyListView);
                    manageDrawer.OnOptionsItemSelected(item);
                    break;
                }
                case Resource.Id.search:
                {
                    Toast.MakeText(this, "Search", ToastLength.Short).Show();
                    break;
                }

            }
            return base.OnOptionsItemSelected(item);
        }

     
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       

    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using TravelRecordApp.Model;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				conn.CreateTable<Post>();
				var posts = conn.Table<Post>().ToList();
				postListView.ItemsSource = posts;
			}
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			var selectedPost = postListView.SelectedItem as Post;

			if(selectedPost != null)
			{
				Navigation.PushAsync(new PostDetail(selectedPost));
			}
        }
    }
}
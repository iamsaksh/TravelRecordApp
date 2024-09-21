﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostDetail : ContentPage
	{
        Post selectedPost;
		public PostDetail (Post selectedPost)
		{
			InitializeComponent ();
            this.selectedPost = selectedPost;

            experienceEntry.Text=selectedPost.Experience;
		}

        void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);
                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully updated", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to update", "Ok");
            }
        }

        void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);
                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully deleted", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to deleted", "Ok");
            }
        }
    }
}
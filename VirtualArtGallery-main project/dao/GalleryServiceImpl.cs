using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VirtualArtGallery.Entity;
using VirtualArtGallery.Util;

namespace VirtualArtGallery.DAO
{
    public class GalleryServiceImpl : IGalleryService
    {
        private SqlConnection connection;

        public GalleryServiceImpl()
        {
            connection = DBConnUtil.GetConnection();
        }

        // Add Gallery
        public bool AddGallery(Gallery gallery)
        {
            string query = "INSERT INTO Gallery (Name, Description, Location, ArtistID, OpeningHours) " +
                           "VALUES (@Name, @Description, @Location, @ArtistID, @OpeningHours)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", gallery.Name);
                cmd.Parameters.AddWithValue("@Description", gallery.Description);
                cmd.Parameters.AddWithValue("@Location", gallery.Location);
                cmd.Parameters.AddWithValue("@ArtistID", gallery.ArtistId);
                cmd.Parameters.AddWithValue("@OpeningHours", gallery.OpeningHours);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        // Update Gallery
        public bool UpdateGallery(Gallery gallery)
        {
            string query = "UPDATE Gallery SET Name=@Name, Description=@Description, Location=@Location, " +
                           "ArtistID=@ArtistID, OpeningHours=@OpeningHours WHERE GalleryID=@GalleryID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Name", gallery.Name);
                cmd.Parameters.AddWithValue("@Description", gallery.Description);
                cmd.Parameters.AddWithValue("@Location", gallery.Location);
                cmd.Parameters.AddWithValue("@ArtistID", gallery.ArtistId);
                cmd.Parameters.AddWithValue("@OpeningHours", gallery.OpeningHours);
                cmd.Parameters.AddWithValue("@GalleryID", gallery.GalleryId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        // Remove Gallery
        public bool RemoveGallery(int galleryId)
        {
            string query = "DELETE FROM Gallery WHERE GalleryID=@GalleryID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@GalleryID", galleryId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        // Get Gallery by ID
        public Gallery GetGalleryById(int galleryId)
        {
            string query = "SELECT * FROM Gallery WHERE GalleryID=@GalleryID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@GalleryID", galleryId);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Gallery gallery = new Gallery
                    {
                        GalleryId = (int)reader["GalleryID"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Location = reader["Location"].ToString(),
                        ArtistId = (int)reader["ArtistID"],
                        OpeningHours = reader["OpeningHours"].ToString()
                    };
                    connection.Close();
                    return gallery;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
        }

        // Search Galleries
        public List<Gallery> SearchGalleries(string keyword)
        {
            List<Gallery> galleries = new List<Gallery>();
            string query = "SELECT * FROM Gallery WHERE Name LIKE @Keyword OR Description LIKE @Keyword";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    galleries.Add(new Gallery
                    {
                        GalleryId = (int)reader["GalleryID"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Location = reader["Location"].ToString(),
                        ArtistId = (int)reader["ArtistID"],
                        OpeningHours = reader["OpeningHours"].ToString()
                    });
                }
                connection.Close();
            }
            return galleries;
        }
    }
}
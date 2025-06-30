using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VirtualArtGallery.Entity;
using VirtualArtGallery.MyExceptions;
using VirtualArtGallery.Util;

namespace VirtualArtGallery.DAO
{
    public class VirtualArtGalleryImpl : IVirtualArtGallery
    {
        private SqlConnection connection;

        public VirtualArtGalleryImpl()
        {
            connection = DBConnUtil.GetConnection();
        }

        // Add Artwork
        public bool AddArtwork(Artwork artwork)
        {
            string query = "INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID) " +
                           "VALUES (@Title, @Description, @CreationDate, @Medium, @ImageURL, @ArtistID)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Description", artwork.Description);
                cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageUrl);
                cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        // Update Artwork
        public bool UpdateArtwork(Artwork artwork)
        {
            string query = "UPDATE Artwork SET Title=@Title, Description=@Description, CreationDate=@CreationDate, " +
                           "Medium=@Medium, ImageURL=@ImageURL, ArtistID=@ArtistID WHERE ArtworkID=@ArtworkID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Description", artwork.Description);
                cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageUrl);
                cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistId);
                cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        // Remove Artwork
        public bool RemoveArtwork(int artworkId)
        {
            string query = "DELETE FROM Artwork WHERE ArtworkID=@ArtworkID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                if (rows == 0)
                    throw new ArtworkNotFoundException("Artwork ID not found.");

                return true;
            }
        }

        // Get Artwork by ID
        public Artwork GetArtworkById(int artworkId)
        {
            string query = "SELECT * FROM Artwork WHERE ArtworkID=@ArtworkID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Artwork artwork = new Artwork
                    {
                        ArtworkId = (int)reader["ArtworkID"],
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreationDate = (DateTime)reader["CreationDate"],
                        Medium = reader["Medium"].ToString(),
                        ImageUrl = reader["ImageURL"].ToString(),
                        ArtistId = (int)reader["ArtistID"]
                    };
                    connection.Close();
                    return artwork;
                }
                else
                {
                    connection.Close();
                    throw new ArtworkNotFoundException("Artwork ID not found.");
                }
            }
        }

        // Search Artworks
        public List<Artwork> SearchArtworks(string keyword)
        {
            List<Artwork> artworks = new List<Artwork>();
            string query = "SELECT * FROM Artwork WHERE Title LIKE @Keyword OR Description LIKE @Keyword";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    artworks.Add(new Artwork
                    {
                        ArtworkId = (int)reader["ArtworkID"],
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreationDate = (DateTime)reader["CreationDate"],
                        Medium = reader["Medium"].ToString(),
                        ImageUrl = reader["ImageURL"].ToString(),
                        ArtistId = (int)reader["ArtistID"]
                    });
                }
                connection.Close();
            }
            return artworks;
        }

        // Add Artwork to Favorites
        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            string query = "INSERT INTO User_Favorite_Artwork (UserID, ArtworkID) VALUES (@UserID, @ArtworkID)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        // Remove Artwork from Favorites
        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            string query = "DELETE FROM User_Favorite_Artwork WHERE UserID=@UserID AND ArtworkID=@ArtworkID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        // Get User's Favorite Artworks
        public List<Artwork> GetUserFavoriteArtworks(int userId)
        {
            List<Artwork> favorites = new List<Artwork>();
            string query = "SELECT A.* FROM Artwork A INNER JOIN User_Favorite_Artwork UFA ON A.ArtworkID = UFA.ArtworkID WHERE UFA.UserID = @UserID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    favorites.Add(new Artwork
                    {
                        ArtworkId = (int)reader["ArtworkID"],
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CreationDate = (DateTime)reader["CreationDate"],
                        Medium = reader["Medium"].ToString(),
                        ImageUrl = reader["ImageURL"].ToString(),
                        ArtistId = (int)reader["ArtistID"]
                    });
                }
                connection.Close();
            }
            return favorites;
        }
    }
}
using System;

namespace VirtualArtGallery.Entity
{
    public class User
    {
        private int userId;
        private string username;
        private string password;
        private string email;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string profilePicture;

        public User() { }

        public User(int userId, string username, string password, string email, string firstName, string lastName, DateTime dateOfBirth, string profilePicture)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.profilePicture = profilePicture;
        }

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string ProfilePicture { get => profilePicture; set => profilePicture = value; }
    }
}

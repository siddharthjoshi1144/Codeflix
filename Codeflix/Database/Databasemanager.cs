using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Codeflix.Models;

namespace Codeflix.Database
{
	public class DatabaseManager
	{
		private readonly string connectionString;

		public DatabaseManager(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public bool InsertMediaItem(MediaItem item)
		{
			string query = @"INSERT INTO MediaItems 
                             (Id, Title, Genre, ReleaseYear, Type, Rating, Director)
                             VALUES
                             (@Id, @Title, @Genre, @ReleaseYear, @Type, @Rating, @Director)";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Id", item.Id);
					command.Parameters.AddWithValue("@Title", item.Title);
					command.Parameters.AddWithValue("@Genre", item.Genre);
					command.Parameters.AddWithValue("@ReleaseYear", item.ReleaseYear);
					command.Parameters.AddWithValue("@Type", item.Type);
					command.Parameters.AddWithValue("@Rating", item.Rating);
					command.Parameters.AddWithValue("@Director", item.Director);

					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();

					return rowsAffected > 0;
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine("Database insert error: " + ex.Message);
				return false;
			}
		}

		public List<MediaItem> GetAllMediaItems()
		{
			List<MediaItem> items = new List<MediaItem>();

			string query = "SELECT Id, Title, Genre, ReleaseYear, Type, Rating, Director FROM MediaItems";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					connection.Open();

					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							MediaItem item = new MediaItem(
								reader.GetInt32(0),
								reader.GetString(1),
								reader.GetString(2),
								reader.GetInt32(3),
								reader.GetString(4),
								reader.GetDouble(5),
								reader.GetString(6)
							);

							items.Add(item);
						}
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine("Database load error: " + ex.Message);
			}

			return items;
		}

		public bool DeleteMediaItemByTitle(string title)
		{
			string query = "DELETE FROM MediaItems WHERE Title = @Title";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Title", title);

					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();

					return rowsAffected > 0;
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine("Database delete error: " + ex.Message);
				return false;
			}
		}

		public bool MediaItemExists(string title)
		{
			string query = "SELECT COUNT(*) FROM MediaItems WHERE Title = @Title";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Title", title);

					connection.Open();
					int count = (int)command.ExecuteScalar();

					return count > 0;
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine("Database exists-check error: " + ex.Message);
				return false;
			}
		}
	}
}
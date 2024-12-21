using System;
using System.IO;

public class DirectoryHelper
{
    public static void EnsureDirectoryExists(string targetDirectory)
    {
        try
        {
            // Check if the directory exists
            if (!Directory.Exists(targetDirectory))
            {
                // Create the directory if it doesn't exist
                Directory.CreateDirectory(targetDirectory);
                Console.WriteLine($"Directory created at: {targetDirectory}");
            }
            else
            {
                Console.WriteLine($"Directory already exists at: {targetDirectory}");
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            // Handle permission issues
            Console.WriteLine($"Access denied: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle any other unexpected exceptions
            Console.WriteLine($"An error occurred while creating the directory: {ex.Message}");
        }
    }
}

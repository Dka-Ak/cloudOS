using System;
using System.Diagnostics;

namespace OSLang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Docker Command Prompt");
            Console.WriteLine("Use 'mod new' to start a new Docker container and 'run' to run a Docker container.");

            while (true)
            {
                Console.Write("cmd> ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    continue;

                var command = input.Split(' ')[0];
                var argument = input.Contains(' ') ? input.Substring(input.IndexOf(' ') + 1) : string.Empty;

                switch (command)
                {
                    case "mod":
                        if (argument == "new")
                        {
                            CreateNewDockerContainer();
                        }
                        else
                        {
                            Console.WriteLine("Unknown command.");
                        }
                        break;
                    case "run":
                        RunDockerContainer();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        static void CreateNewDockerContainer()
        {
            var processInfo = new ProcessStartInfo("docker", "run -d --name my_new_container alpine sleep 3600")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process())
            {
                process.StartInfo = processInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine("New Docker container created successfully.");
                }
                else
                {
                    Console.WriteLine($"Error: {error}");
                }
            }
        }

        static void RunDockerContainer()
        {
            var processInfo = new ProcessStartInfo("docker", "start my_new_container")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process())
            {
                process.StartInfo = processInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine("Docker container started successfully.");
                }
                else
                {
                    Console.WriteLine($"Error: {error}");
                }
            }
        }
    }
}

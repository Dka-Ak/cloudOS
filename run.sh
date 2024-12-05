#!/bin/bash

# Define the C# file name
CSHARP_FILE="Program.cs"

# Compile the C# file
mcs $CSHARP_FILE -out:docker_command_prompt.exe

# Check if the compilation was successful
if [ $? -eq 0 ]; then
    echo "Compilation successful. Running the program..."

    # Run the compiled C# program
    mono docker_command_prompt.exe
else
    echo "Failed. Please correct your code."
fi

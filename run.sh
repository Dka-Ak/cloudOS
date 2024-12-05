#!/bin/bash

# Check if a secret number is passed as an argument
if [ -z "$1" ]; then
    echo "Please provide a secret number."
    exit 1
fi

SECRET_NUMBER=$1
echo "Launching new session with secret number: $SECRET_NUMBER"

# Define the C# file name
CSHARP_FILE="Program.cs"

# Compile the C# file
mcs $CSHARP_FILE -out:docker_command_prompt_$SECRET_NUMBER.exe

# Check if the compilation was successful
if [ $? -eq 0 ]; then
    echo "Compilation successful. Running the program..."

    # Run the compiled C# program
    mono docker_command_prompt_$SECRET_NUMBER.exe
else
    echo "It has failed. Please correct your code."
fi


import random
import sys

def generate_secret_number():
    secret_number = random.randint(1000, 9999)  # Generates a 4-digit secret number
    return secret_number

if __name__ == "__main__":
    secret_number = generate_secret_number()
    print(f"Your secret number is: {secret_number}")
    
    # Pass the secret number to the command prompt program or any other script
    # For demonstration, let's print the command to run
    print(f"To start a new session, use the command: ./run_csharp.sh {secret_number}")

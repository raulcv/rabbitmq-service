#!/bin/bash

# List of projects to run
projects=(
  rabbitmq-receiver-one
  rabbitmq-receiver-two 
  rabbitmq-sender
  )

# Get the path to the current script directory
script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
echo "Script directory: $script_dir"

# Run each project in a separate terminal iTerm window
for project in "${projects[@]}"; do
    osascript -e "tell application \"iTerm\" to activate"
    osascript -e "tell application \"iTerm\"
        create window with default profile
        tell current session of current window
            write text \"cd $script_dir/$project\"
            write text \"dotnet run\"
        end tell
    end tell"

    sleep 1  # Optional: wait a bit before starting the next project
    echo "Running $project in a new iTerm window..."
done

# Wait for all processes to finish
wait
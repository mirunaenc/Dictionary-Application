# Dictionary Application

## Description
This project involves creating an explanatory dictionary application using C# and WPF (.NET Framework). The application is structured into three main modules: Administrative, Word Search, and Entertainment.

## Features

### Administrative Module
- **User Authentication**: Requires a username and password for access. User accounts are stored in a predefined text file (TXT).
- **Word Management**: Allows adding, modifying, and deleting words in the dictionary. Each word includes a description, category (mandatory), and an optional image (with a default image if none is provided).
- **Category Management**: Words are categorized, and new categories can be added dynamically. Categories are stored in a text file.
- **Validations**: Ensures proper input for all fields in the administrative form.

### Word Search Module
- **Search Functionality**: Users can search for words either within a specific category or across all categories.
- **Autocomplete**: Provides suggestions as the user types in the search box.
- **Display**: Shows the selected word's description, category, and image (or default image if none is provided).

### Entertainment Module
- **Word Guessing Game**: Users must guess 5 words based on their description or image.
- **Random Selection**: Words and clues (description or image) are selected randomly.
- **Navigation**: Users can navigate through words using "Next" and "Previous" buttons, with "Finish" ending the game.
- **Feedback**: Shows the number of correct answers at the end of the game, with options to show correct answers immediately or at the end.

## Technologies Used
- **Programming Language**: C#
- **Framework**: .NET Framework
- **User Interface**: WPF (Windows Presentation Foundation)
- **Data Storage**: Text files (TXT)

# dgw - Weather App

**dgw** is a weather app written in C#. Depending on your mood, "dgw" could mean many things:

- **Days Grow Warmer**
- **Does Get Weather**
- **Don't Get Wet**
- **Days Get Wilder**
- **Dawn Gives Wonder**
- **Deep Grasses Wave**

## Instructions

### 1. **Create a `Config.toml` file**
In your project directory, create a file named **`Config.toml`** and add your API configuration as follows:

```toml
[api]
api_key = "your_api_key"
```

Replace `"your_api_key"` with your actual API key.

### 2. **Add the Icons Folder**
Ensure that an **`icons`** folder is added to your working directory (where the `.exe` file is located). This folder will contain the necessary icon files for the app.

### 3. **Set Up the Easter Egg (Optional)**
To enable the Easter egg functionality, follow these steps:
1. Create a folder named **`easteregg`** in your working directory.
2. Inside the `easteregg` folder, add two files:
   - **`easteregg.png`** (an image for the Easter egg)
   - **`easteregg.wav`** (an audio file for the Easter egg)

### 4. **Compile the Program**
Compile the program using your preferred tool, such as **Visual Studio 2022** (or any version you have). Make sure all dependencies and configurations are set correctly.
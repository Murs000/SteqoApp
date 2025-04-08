# SteqoApp - Hide and Extract Text (WPF, MVVM)

SteqoApp is a simple WPF application that allows users to **hide** and **extract** text from BMP image files using steganography. 
The application follows the **MVVM (Model-View-ViewModel)** architecture.

## ✨ Features

- 🖼 Load BMP image from disk
- 🛡 Hide a message inside the image using LSB (Least Significant Bit) manipulation
- 🔍 Extract hidden messages from images
- 📁 Clean and simple UI using WPF and MVVM pattern

## 🏗 Architecture

- **View** (`MainPage.xaml`) - UI layer built using XAML
- **ViewModel** (`MainPageViewModel.cs`) - Binds UI and logic
- **Commands** - `SetPathCommand`, `HideCommand`, and `ExtractCommand` encapsulate the logic for actions

## 📂 Project Structure

```
SteqoApp/
│
├── Views/
│   └── MainPage.xaml           # The main window layout
│
├── ViewModel/
│   └── MainPageViewModel.cs   # ViewModel handling data binding and command initialization
│
├── Commands/
│   ├── HideCommand.cs         # Command to hide text in image
│   ├── ExtractCommand.cs      # Command to extract text from image
│   └── SetPathCommand.cs      # Command to select image path
```

## 🖼 Usage

1. **Choose Image** – Click "📁 Choose Image" to select a `.bmp` file.
2. **Enter Message** – Type the text message to be hidden.
3. **Hide** – Click "🛡 Hide" to embed the message in the image.
   - A new image will be saved with `"Hidden"` inserted before the file extension.
4. **Extract** – Click "🔍 Extract" to read hidden text from a BMP file.

## ⚠ Limitations

- Only supports `.bmp` images
- Message length is limited to the number of pixels in the image

## 📦 Technologies

- WPF (.NET)
- MVVM pattern
- System.Drawing
- ICommand interface

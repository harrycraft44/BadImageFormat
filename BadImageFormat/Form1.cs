using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BadImageFormat
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Custom Image Viewer";

            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pictureBox);
            // Check if application was launched with file argument
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1].ToLower().EndsWith(".badfileformat"))
            {
                LoadAndDisplayImage(args[1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "D:\\d\\theworldimage.jpg";
            string outputFilePath = "D:\\d\\theworldimage.BADFILEFORMAT";

            using (Bitmap bitmap = new Bitmap(filePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            Color pixelColor = bitmap.GetPixel(x, y);

                            // Convert the pixel color to a hex string (ARGB)
                            string hexColor = $"{pixelColor.A:X2}{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";

                            // Write the hex string to the file
                            writer.Write(hexColor);
                        }

                        // Write a new line after each row of pixels
                        writer.WriteLine();
                    }
                }
            }
        }

        private void LoadAndDisplayImage(string filePath)
        {
            try
            {
                // Read the file
                string[] lines = File.ReadAllLines(filePath);

                // Determine the image dimensions
                int width = lines[0].Length / 8; // Each pixel is 8 characters (ARGB)
                int height = lines.Length;

                Bitmap bitmap = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    string line = lines[y];
                    for (int x = 0; x < width; x++)
                    {
                        string hexColor = line.Substring(x * 8, 8); // ARGB is 8 characters
                        int a = Convert.ToInt32(hexColor.Substring(0, 2), 16);
                        int r = Convert.ToInt32(hexColor.Substring(2, 2), 16);
                        int g = Convert.ToInt32(hexColor.Substring(4, 2), 16);
                        int b = Convert.ToInt32(hexColor.Substring(6, 2), 16);
                        Color pixelColor = Color.FromArgb(a, r, g, b);
                        bitmap.SetPixel(x, y, pixelColor);
                    }
                }

                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "BADFILEFORMAT files (*.BADFILEFORMAT)|*.BADFILEFORMAT";

            openFileDialog1.ShowDialog();
            LoadAndDisplayImage(openFileDialog1.FileName);
        }

        private void tOBadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.Filter = "BAD File Format|*.BADFILEFORMAT";
                saveFileDialog1.DefaultExt = "BADFILEFORMAT";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Check if the file is an image
                    if (openFileDialog1.FileName.EndsWith(".jpg") || openFileDialog1.FileName.EndsWith(".jpeg") ||
                        openFileDialog1.FileName.EndsWith(".png"))
                    {
                        using (Bitmap bitmap = new Bitmap(openFileDialog1.FileName))
                        {
                            using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                            {
                                for (int y = 0; y < bitmap.Height; y++)
                                {
                                    for (int x = 0; x < bitmap.Width; x++)
                                    {
                                        Color pixelColor = bitmap.GetPixel(x, y);

                                        // Convert the pixel color to a hex string (ARGB)
                                        string hexColor = $"{pixelColor.A:X2}{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";

                                        // Write the hex string to the file
                                        writer.Write(hexColor);
                                    }

                                    // Write a new line after each row of pixels
                                    writer.WriteLine();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The file is not an image");
                    }
                }
            }
        }

        private void topngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "BADFILEFORMAT files (*.BADFILEFORMAT)|*.BADFILEFORMAT";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.Filter = "Png file|*.png;";
                saveFileDialog1.DefaultExt = "png";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ConvertBadFileToPng(openFileDialog1.FileName, saveFileDialog1.FileName);
                }
            }
        }

        public static void ConvertBadFileToPng(string badFilePath, string pngFilePath)
        {
            try
            {
                // Read the .BADFILEFORMAT file
                string[] lines = File.ReadAllLines(badFilePath);

                // Determine the image dimensions
                int width = lines[0].Length / 8; // Each pixel is 8 characters (ARGB)
                int height = lines.Length;

                Bitmap bitmap = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    string line = lines[y];
                    for (int x = 0; x < width; x++)
                    {
                        string hexColor = line.Substring(x * 8, 8); // ARGB is 8 characters
                        int a = Convert.ToInt32(hexColor.Substring(0, 2), 16);
                        int r = Convert.ToInt32(hexColor.Substring(2, 2), 16);
                        int g = Convert.ToInt32(hexColor.Substring(4, 2), 16);
                        int b = Convert.ToInt32(hexColor.Substring(6, 2), 16);
                        Color pixelColor = Color.FromArgb(a, r, g, b);
                        bitmap.SetPixel(x, y, pixelColor);
                    }
                }

                // Save the bitmap as a .png file
                bitmap.Save(pngFilePath, ImageFormat.Png);

                Console.WriteLine($"Successfully converted {badFilePath} to {pngFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting file: {ex.Message}");
            }
        }


        private void RegisterFileAssociation()
        {
            try
            {
                string appName = "BadImageFormat"; // Replace with your application name
                string appPath = Application.ExecutablePath;

                // Register file association in HKCU (Current User)
                RegisterFileAssociation(".badfileformat", appName, appPath);

                MessageBox.Show(".BADFILEFORMAT file association registered successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering file association: {ex.Message}");
            }
        }

        private void RegisterFileAssociation(string extension, string appName, string appPath)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Classes", true))
            {
                // Create extension key
                using (RegistryKey extKey = key.CreateSubKey(extension))
                {
                    extKey.SetValue("", $"{appName}File", RegistryValueKind.String); // Set default value to "AppNameFile"

                    // Create AppNameFile key
                    using (RegistryKey appKey = key.CreateSubKey($"{appName}File"))
                    {
                        appKey.SetValue("", $"{appName} File"); // Set default value to "AppName File"

                        // Create DefaultIcon subkey
                        using (RegistryKey iconKey = appKey.CreateSubKey("DefaultIcon"))
                        {
                            iconKey.SetValue("", $"\"{appPath}\",0"); // Set default value to "AppPath,0"
                        }

                        // Create shell\open\command subkey
                        using (RegistryKey commandKey = appKey.CreateSubKey(@"shell\open\command"))
                        {
                            commandKey.SetValue("", $"\"{appPath}\" \"%1\""); // Set default value to "AppPath \"%1\""
                        }
                    }
                }
            }
        }

        private void regToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterFileAssociation();
        }
    }
}

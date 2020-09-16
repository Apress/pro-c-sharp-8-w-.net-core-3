using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;
using System.Reflection;
using Path = System.IO.Path;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // New Window-level variable.
        private CancellationTokenSource _cancelToken = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // This will be used to tell all the worker threads to stop!
            _cancelToken.Cancel();
        }

        private void cmdProcess_Click(object sender, EventArgs e)
        {
            // Start a new "task" to process the files.
            Task.Factory.StartNew(() => ProcessFiles());
            //Can also be written this way
            //Task.Factory.StartNew(ProcessFiles);
            this.Title = "Processing complete";
        }

        private void ProcessFiles()
        {
            // Load up all *.jpg files, and make a new folder for the modified data.
            var basePath = Directory.GetCurrentDirectory();
            var pictureDirectory = Path.Combine(basePath, "TestPictures");
            var outputDirectory = Path.Combine(basePath, "ModifiedPictures");
            Directory.CreateDirectory(outputDirectory);
            string[] files = Directory.GetFiles(pictureDirectory, "*.jpg", SearchOption.AllDirectories);

            // Process the image data in a blocking manner.
            //foreach (string currentFile in files)
            //{
            //    string filename = System.IO.Path.GetFileName(currentFile);

            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(System.IO.Path.Combine(outputDirectory, filename));

            //        // Print out the ID of the thread processing the current image.
            //        this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
            //    }
            //}
            // Process the image data in a parallel manner!
            //Parallel.ForEach(files, currentFile =>
            //    {
            //        string filename = Path.GetFileName(currentFile);

            //        using (Bitmap bitmap = new Bitmap(currentFile))
            //        {
            //            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //            bitmap.Save(Path.Combine(outputDirectory, filename));
            //            Thread.Sleep(1000);
            //            // This code statement is now a problem! See next section.
            //            // this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}"
            //            // Thread.CurrentThread.ManagedThreadId);

            //            // Invoke on the Form object, to allow secondary threads to access controls
            //            // in a thread-safe manner.
            //            Dispatcher?.Invoke(()=> {
            //                    this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
            //                }
            //            );

            //        }
            //    }
            //);
            // Use ParallelOptions instance to store the CancellationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = _cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            try
            {
                // Process the image data in a parallel manner!
                Parallel.ForEach(files, parOpts, currentFile =>
                    {
                        parOpts
                            .CancellationToken.ThrowIfCancellationRequested();
                        Thread.Sleep(20000);
                        string filename = Path.GetFileName(currentFile);
                        using (Bitmap bitmap = new Bitmap(currentFile))
                        {
                            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            bitmap.Save(Path.Combine(outputDirectory, filename));
                            Dispatcher?.Invoke(() =>
                                {
                                    this.Title =
                                        $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                                }
                            );
                        }
                    }
                );
                Dispatcher?.Invoke(() =>this.Title = "Done!" );
            }
            catch (OperationCanceledException ex)
            {
                Dispatcher?.Invoke(()=>this.Title = ex.Message);
            }
        }
    }
}
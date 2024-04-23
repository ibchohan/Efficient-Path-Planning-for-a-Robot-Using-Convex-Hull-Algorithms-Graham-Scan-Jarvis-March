using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace algo_project_CSHARP
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();
        private List<Point> lines = new List<Point>();

        private List<Point> convexHull = new List<Point>();
        private int currentEdgeIndex = -1;
        private Timer animationTimer = new Timer();
        private bool drawEdges = false;

        public Form1()
        {
            InitializeComponent();

            // Configure the animation timer
            animationTimer.Interval = 500; // Adjust the interval (in milliseconds) to control animation speed
            animationTimer.Tick += AnimationTimer_Tick;
            // Set the initial size of the picture box to cover the whole screen           

            // Set the location of the buttons and the size of the PictureBox
            grahamscanbutton.Location = new Point(this.ClientSize.Width - grahamscanbutton.Width - 10, this.ClientSize.Height - grahamscanbutton.Height);
            CalculateConvexHullButton.Location = new Point(this.ClientSize.Width - CalculateConvexHullButton.Width - 10, this.ClientSize.Height - CalculateConvexHullButton.Height);
            Reset.Location = new Point(this.ClientSize.Width - Reset.Width - 160, this.ClientSize.Height - Reset.Height);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            grahamscanbutton.Hide();
            stackPictureBox.Hide();
            CalculateConvexHullButton.Hide();
            Reset.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Create a Graphics object for drawing
            Graphics g = e.Graphics;

            // Draw all the points in the list
            foreach (Point point in points)
            {
                int radius = 5;
                g.FillEllipse(Brushes.Red, point.X - radius, point.Y - radius, 2 * radius, 2 * radius);
                g.DrawString($"({point.X}, {pictureBox1.Height - point.Y})", new Font("Arial", 12), Brushes.White, point.X + radius, point.Y - radius);
            }

            // Draw the edges of the convex hull up to the currentEdgeIndex

            if (drawEdges)
            {
                Pen pen = new Pen(Brushes.Blue, 2);
                for (int i = 0; i <= currentEdgeIndex; i++)
                {
                    if (i + 1 < convexHull.Count)
                    {
                        g.DrawLine(pen, convexHull[i], convexHull[i + 1]);
                    }
                    if (currentEdgeIndex == convexHull.Count - 1)
                    {
                        g.DrawLine(pen, convexHull[currentEdgeIndex], convexHull[0]);
                    }
                }
            }

        }

        private void CalculateConvexHullButton_Click(object sender, EventArgs e)
        {
            if (points.Count < 3)
            {
                var result = MessageBox.Show("Less than 3 points are not acceptable!", "Error");
                convexHull.Clear();
                drawEdges = false;
            }
            else
            {
                // Call the Jarvis March algorithm to compute the convex hull
                drawEdges = true;

                // Measure execution time for Jarvis March
                Stopwatch stopwatchJarvis = new Stopwatch();
                stopwatchJarvis.Start();
                convexHull = JarvisMarch(points);
                stopwatchJarvis.Stop();
                TimeSpan elapsedJarvis = stopwatchJarvis.Elapsed;
                MessageBox.Show($"Jarvis March Execution Time: {elapsedJarvis.TotalMilliseconds} milliseconds");

                currentEdgeIndex = -1; // Initialize to -1

                // Start the animation timer
                animationTimer.Start();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            currentEdgeIndex++;

            if (currentEdgeIndex >= convexHull.Count)
            {
                // Animation complete, stop the timer after drawing the last edge
                animationTimer.Stop();
                currentEdgeIndex = convexHull.Count - 1; // Ensure it's not out of bounds
            }

            pictureBox1.Invalidate();
        }

        private List<Point> JarvisMarch(List<Point> inputPoints)
        {
            if (inputPoints.Count < 3)
            {

                // Convex hull not possible with less than 3 points
                return inputPoints;
            }

            List<Point> convexHull = new List<Point>();

            // Find the point with the smallest Y-coordinate (and leftmost if ties)
            Point startPoint = inputPoints[0];
            foreach (var point in inputPoints)
            {
                if (point.Y > startPoint.Y || (point.Y == startPoint.Y && point.X > startPoint.X))
                {
                    startPoint = point;
                }
            }

            Point currentPoint = startPoint;
            do
            {
                convexHull.Add(currentPoint);
                Point nextPoint = inputPoints[0];

                for (int i = 1; i < inputPoints.Count; i++)
                {
                    int orientation = Orientation(currentPoint, nextPoint, inputPoints[i]);
                    if (orientation == -1)
                    {
                        nextPoint = inputPoints[i];
                    }
                    else if (orientation == 0)
                    {
                        // Handle collinear points by choosing the farthest one
                        int distanceA = DistanceSquared(currentPoint, nextPoint);
                        int distanceB = DistanceSquared(currentPoint, inputPoints[i]);
                        if (distanceB > distanceA)
                        {
                            nextPoint = inputPoints[i];
                        }
                    }
                }

                currentPoint = nextPoint;
            } while (currentPoint != startPoint);

            return convexHull;
        }

        private int Orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            if (val == 0)
            {
                return 0; // Collinear
            }
            return (val > 0) ? 1 : -1; // 1 for clockwise, -1 for counterclockwise
        }

        private int DistanceSquared(Point p1, Point p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            return dx * dx + dy * dy;
        }

        private void grahamscanbutton_Click(object sender, EventArgs e)
        {
            if (points.Count < 3)
            {
                var result = MessageBox.Show("Less than 3 points are not acceptable!", "Error");
                convexHull.Clear();
                drawEdges = false;
            }
            else
            {
                // Call the Graham's Scan algorithm to compute the convex hull
                drawEdges = true;

                // Measure execution time for Graham's Scan
                Stopwatch stopwatchGraham = new Stopwatch();
                stopwatchGraham.Start();
                convexHull = GrahamScan(points);
                stopwatchGraham.Stop();
                TimeSpan elapsedGraham = stopwatchGraham.Elapsed;
                MessageBox.Show($"Graham's Scan Execution Time: {elapsedGraham.TotalMilliseconds} milliseconds");

                currentEdgeIndex = -1;
                animationTimer.Start();
            }
        }
        private List<Point> GrahamScan(List<Point> inputPoints)
        {
            int n = inputPoints.Count;

            if (n < 3)
            {
                // Convex hull not possible with less than 3 points
                return inputPoints;
            }

            // Find the bottom-most point by comparing y coordinate and x coordinate
            Point startPoint = inputPoints[0];
            for (int i = 1; i < n; i++)
            {
                if (inputPoints[i].Y > startPoint.Y || (inputPoints[i].Y == startPoint.Y && inputPoints[i].X > startPoint.X))
                {
                    startPoint = inputPoints[i];
                }
            }

            // Sort the remaining points by polar angle in counterclockwise order around startPoint
            List<Point> sortedPoints = inputPoints
                .Where(p => p != startPoint)
                .OrderBy(p => -Math.Atan2(p.Y - startPoint.Y, p.X - startPoint.X))
                .ToList();

            // Initialize the convex hull with the first two sorted points
            List<Point> convexHull = new List<Point>();
            convexHull.Add(startPoint);
            convexHull.Add(sortedPoints[0]);

            // Stack for visualization
            List<string> grahamScanStackOperations = new List<string>();
            grahamScanStackOperations.Add($"Push ({sortedPoints[0].X}, {sortedPoints[0].Y})");
            grahamScanStackOperations.Add($"Push ({startPoint.X}, {startPoint.Y})");

            // Visualize the initial stack
            DrawStackInPictureBox(stackPictureBox, grahamScanStackOperations, inputPoints);

            // Iterate through the sorted points to build the convex hull
            for (int i = 1; i < n - 1; i++)
            {
                while (convexHull.Count > 1 && Orientationg(convexHull[convexHull.Count - 2], convexHull.Last(), sortedPoints[i]) != 1)
                {
                    convexHull.RemoveAt(convexHull.Count - 1);
                    grahamScanStackOperations.Insert(0, "Pop");
                    // Update the stack visualization after popping
                    DrawStackInPictureBox(stackPictureBox, grahamScanStackOperations, inputPoints);
                    currentEdgeIndex++;

                    if (currentEdgeIndex >= convexHull.Count)
                    {
                        // Animation complete, stop the timer after drawing the last edge
                        animationTimer.Stop();
                        currentEdgeIndex = convexHull.Count - 1; // Ensure it's not out of bounds
                    }

                    pictureBox1.Invalidate();
                }

                convexHull.Add(sortedPoints[i]);
                grahamScanStackOperations.Insert(0, $"Push ({sortedPoints[i].X}, {sortedPoints[i].Y})");
                // Update the stack visualization after pushing
                DrawStackInPictureBox(stackPictureBox, grahamScanStackOperations, inputPoints);
               

            }
            return convexHull;
        }

        private void DrawStackInPictureBox(PictureBox pictureBox, List<string> stackOperations, List<Point> inputPoints)
        {
            // Create a Bitmap for drawing the stack visualization
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Clear the bitmap
                g.Clear(Color.White);
                 //int x = 10;
                // int y = pictureBox.Height - operationHeight * (stackOperations.Count + 1);
                // Calculate the height of each operation considering the number of operations and text size
                int textHeight = (int)g.MeasureString("Test", new Font("Arial", 10)).Height; // Measure a sample text height
                int operationHeight = textHeight + 5; // 5 is additional space to separate operations visually

                // Calculate the initial y-coordinate for the bottom of the PictureBox
                int y = pictureBox.Height - operationHeight * (stackOperations.Count + 1); // Add extra space for the top margin

                // Define starting position to draw the stack visualization
                int x = 10;

                // Draw each stack operation
                
                foreach (string operation in stackOperations)
                {
                    if (!operation.StartsWith("Push"))
                    {
                        //g.DrawString(operation, new Font("Arial", 10), Brushes.Blue, x, y);
                        //Rectangle rect = new Rectangle(x, y, 120, textHeight + 5); // Rectangle dimensions
                        //g.DrawRectangle(Pens.Black, rect); // Draw a rectangle around each operation
                        int crossX = x; // Adjust this value to place the cross mark properly
                       int crossY = y - operationHeight / 2; // Adjust this value to place the cross mark properly


                        using (Pen redPen = new Pen(Color.Red, 3)) // Set the width to 2
                        {
                            g.DrawLine(redPen, x, y, x + 120, y + (textHeight + 5));
                        }
                        // y += operationHeight; // Move up for the next operation
                    }
                    // Extracting values within parentheses
                    else
                    {
                        int startIndex = operation.IndexOf('(');
                        int endIndex = operation.IndexOf(')');
                        string pointCoords = operation.Substring(startIndex + 1, endIndex - startIndex - 1);

                        string[] coordinates = pointCoords.Split(',');
                        int X = int.Parse(coordinates[0].Trim());
                        int Y = int.Parse(coordinates[1].Trim());

                        // Adjust the Y-coordinate to display correctly
                        int displayedY = pictureBox1.Height - Y;


                        g.DrawString($"Push({X}, {displayedY})", new Font("Arial", 10), Brushes.Black, x, y);


                      

                        Rectangle rect = new Rectangle(x, y, 120, textHeight + 5); // Rectangle dimensions
                        g.DrawRectangle(Pens.Black, rect); // Draw a rectangle around each operation
                        y += operationHeight; // Move up for the next operation
                    }

                }


                // Display points corresponding to the stack operations
                foreach (string operation in stackOperations)
                {
                    if (operation.StartsWith("Push"))
                    {
                        int startIndex = operation.IndexOf('(');
                        int endIndex = operation.IndexOf(')');
                        string pointCoords = operation.Substring(startIndex + 1, endIndex - startIndex - 1);

                        string[] coordinates = pointCoords.Split(',');
                        int pointX = int.Parse(coordinates[0]);
                        int pointY = int.Parse(coordinates[1]);

                        // Adjust the Y-coordinate to display correctly
                        int displayedY = pictureBox.Height - pointY; // Flip Y-coordinate to display properly

                        // Draw the point or perform any other operation with the coordinates if needed
                        // Here, you can draw the point or perform other actions with adjusted coordinates
                    }
                }
            }

            // Display the bitmap in the PictureBox
            
            pictureBox.Image = bmp;
        }



        private int Orientationg(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            if (val == 0)
            {
                return 0; // Collinear
            }
            return (val > 0) ? 1 : -1; // 1 for clockwise, -1 for counterclockwise
        }



        private void jarvisMarchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            stackPictureBox.Hide();
            Reset.Show();
            grahamscanbutton.Hide();
            CalculateConvexHullButton.Show();
            pictureBox1.Show();
            convexHull.Clear();
            pictureBox1.Image = null;

        }

        private void grahamScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            Reset.Show();
            stackPictureBox.Show();
            stackPictureBox.Image = null;
            CalculateConvexHullButton.Hide();
            grahamscanbutton.Show();
            pictureBox1.Show();
            convexHull.Clear();
            pictureBox1.Image = null;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            int pictureBoxHeight = this.ClientSize.Height - grahamscanbutton.Height - 40; // You can adjust the 40 value as needed

            // Update the PictureBox size to the calculated height
            pictureBox1.Size = new Size(this.ClientSize.Width, pictureBoxHeight);
            pictureBox2.Size = new Size(this.ClientSize.Width, pictureBoxHeight);


            // Set the location of the buttons to the bottom left corner
            grahamscanbutton.Location = new Point(this.ClientSize.Width - grahamscanbutton.Width - 10, this.ClientSize.Height - grahamscanbutton.Height - 10);
            CalculateConvexHullButton.Location = new Point(this.ClientSize.Width - CalculateConvexHullButton.Width - 10, this.ClientSize.Height - CalculateConvexHullButton.Height - 10);
            Reset.Location = new Point(this.ClientSize.Width - Reset.Width - 160, this.ClientSize.Height - Reset.Height - 10);
            stackPictureBox.Location = new Point(this.ClientSize.Width - stackPictureBox.Width, 0);
            stackPictureBox.Size = new Size(400, this.ClientSize.Height - 70); // Adjust the width as needed
            stackPictureBox.Location = new Point(this.ClientSize.Width - stackPictureBox.Width, stackPictureBox.Location.Y  + 20);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            points.Clear();
            convexHull.Clear();
            pictureBox1.Image = null;
            stackPictureBox.Image = null;
            pictureBox2.Image = null;
            lines.Clear();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void typeOfConvexHullSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            lines.Add(e.Location);
            pictureBox2.Invalidate();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw all the points in the list
            foreach (Point point in lines)
            {
                int radius = 5;
                g.FillEllipse(Brushes.Red, point.X - radius, point.Y - radius, 2 * radius, 2 * radius);
                g.DrawString($"({point.X}, {pictureBox2.Height - point.Y})", new Font("Arial", 12), Brushes.White, point.X + radius, point.Y - radius);
            }

            // Draw lines between every two consecutive points in the list
            if (lines.Count > 1)
            {
                Pen pen = new Pen(Color.Blue, 2);
                for (int i = 0; i < lines.Count - 1; i += 2)
                {
                    g.DrawLine(pen, lines[i], lines[i + 1]);
                }
                pen.Dispose();
            }
        }


    }
}

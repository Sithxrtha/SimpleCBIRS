using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    internal class Features
    {


        public Features() { }

        public void IntensityMethod(List<int[]> pixels, int[] InBins)
        {
            //Formula: I = .299 * R + .587 * G + .114 * B
            for (int i = 0; i < pixels.Count; i++)
            {
                int[] rgb = pixels[i];

                // Calculate intensity
                double Intensity = .299 * rgb[0] + .587 * rgb[1] + .114 * rgb[2];

                // Increments bin for the corresponding intensity value
                if ((int)(Intensity / 10) >= 24)
                {
                    InBins[24] += 1;
                }
                else
                {
                    InBins[(int)(Intensity / 10)] = InBins[(int)(Intensity / 10)] + 1;
                }
            }
        }

        public void ColorCodeMethod(List<int[]> pixels, int[] CcBins)
        {
            for (int i = 0; i < pixels.Count; i++)
            {
                int[] rgb = pixels[i]; // Obtains pixels from specified index (lstView)

                // Convert RGB values to 8-bit binary
                string R_binary = Convert.ToString(rgb[0], 2).PadLeft(8, '0');
                string G_binary = Convert.ToString(rgb[1], 2).PadLeft(8, '0');
                string B_binary = Convert.ToString(rgb[2], 2).PadLeft(8, '0');

                // Obtain the first two bits from each color component to form the six-bit code
                string sixBitCode = R_binary.Substring(0, 2) + G_binary.Substring(0, 2) + B_binary.Substring(0, 2);

                // Convert the six-bit binary string to an integer
                int val = Convert.ToInt32(sixBitCode, 2);

                // Increment the corresponding bin in CcBins
                CcBins[val]++;
            }
        }

        public List<(double distance, int index)> sortList(List<double> listDistance)
        {
            // initialize a list containing tuple of distance and the index of pictures
            var DistanceIndexPairs = new List<(double distance, int index)>();

            for (int i = 0; i < listDistance.Count; i++)
            {
                DistanceIndexPairs.Add((listDistance[i], i)); // Appends to list
            }

            var DistanceIndexPairs2 = DistanceIndexPairs.OrderBy(pair => pair.distance).ToList(); // Sorts the list

            return DistanceIndexPairs2; // returns list
        }

        public void manhattanDistance(List<int[]> Intensity, List<int[]> ColorCode, List<double> distanceIntensity, List<double> distanceColorC, List<int> pixels, ListBox lstView)
        {
            int selectedIndex = lstView.SelectedIndex; // stores selected index

            for (int i = 0; i < lstView.Items.Count; i++)
            {
                if (distanceIntensity.Count == 100 && distanceColorC.Count == 100)
                    return;

                if (i == selectedIndex)
                {
                    distanceIntensity.Add(0); // appends distance 0
                    distanceColorC.Add(0);
                }
                else
                {
                    double distanceIn = 0;
                    double distanceCc = 0;

                    //calculates distances for both lists to store for query use
                    for (int j = 0; j < Intensity[i].Length; j++)
                    {
                        distanceIn += (double)Math.Abs(((double)Intensity[selectedIndex][j] / (double)pixels[selectedIndex]) - ((double)Intensity[i][j] / (double)pixels[i]));
                    }

                    for (int k = 0; k < ColorCode[i].Length; k++)
                    {
                        distanceCc += (double)Math.Abs(((double)ColorCode[selectedIndex][k] / (double)pixels[selectedIndex]) - ((double)ColorCode[i][k] / (double)pixels[i]));
                    }


                    distanceIntensity.Add(distanceIn);
                    distanceColorC.Add(distanceCc); // Appends to proper list their distance
                }
            }
            return;
        }
    }
}

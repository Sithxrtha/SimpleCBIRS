using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW4
{
    internal class FeaturesRF
    {
        public FeaturesRF() { }

        /*
         * Function obtains the average for the bin for all images
         */
        public List<double> average(List<double[]> combinedList) // Obtains average for bins 
        {
            List<double> averageForBins = new List<double>();

            for (int s = 0; s < combinedList[0].Length; s++) // gets the bin we are going through
            {
                double averageFormula = 0;

                for (int e = 0; e < combinedList.Count; e++) // goes through images
                {
                    averageFormula += combinedList[e][s];
                }

                averageForBins.Add(averageFormula / combinedList.Count); // obtains average and then appends to the list
            }

            return averageForBins;
        }

        /*
         * Function obtains the standard deviation for the bin for all images
         */
        public List<double> standardDeviation(List<double[]> combinedList, List<double> averageBins) // Obtains standard deviation for bins
        {
            List<double> stdForBins = new List<double>();

            for (int s = 0; s < combinedList[0].Length; s++) // gets the bin we are going through
            {
                double sum = 0;

                for (int e = 0; e < combinedList.Count; e++)
                {
                    sum += Math.Pow(combinedList[e][s] - averageBins[s], 2); // performs standard deviation formula. Helpful source: https://youtu.be/Uk98hiMQgN0?si=_AS9y5ZliwjCPD4y 
                }

                double stdDev = Math.Sqrt(sum / (combinedList.Count - 1));
                stdForBins.Add(stdDev); // appends to standard deviation list
            }

            return stdForBins;
        }

        /*
         * Function creates the normalized features for all images for storage by List
         */
        public List<(double[], int index)> createNormalizedFeatures(List<double[]> combinedList, List<double> averageForBins, List<double> stdForBins) // parameters needed to obtain normalized features
        {
            List<(double[], int index)> normFts = new List<(double[], int index)>();

            for (int i = 0; i < combinedList.Count; i++)
            {
                double[] imgNormFts = new double[combinedList[i].Length];

                for (int j = 0; j < combinedList[i].Length; j++)
                {
                    double divisor; // used for handling the special cases for stdev and 
                    double feature; // used to past the value to the array

                    //check for special cases
                    if (averageForBins[j] == 0 && stdForBins[j] == 0)
                    {
                        feature = 0;
                        imgNormFts[j] = 0;
                    }
                    else if (stdForBins[j] == 0 && averageForBins[j] != 0)
                    {
                        divisor = .5 * stdForBins.Where(x => x > 0).DefaultIfEmpty(0).Min(); // Filter out zero values and find the minimum
                        feature = (combinedList[i][j] - averageForBins[j]) / divisor;
                    }
                    else
                    {
                        feature = (combinedList[i][j] - averageForBins[j]) / stdForBins[j];
                        imgNormFts[j] = feature;
                    }
                }

                normFts.Add((imgNormFts, i)); // append to normalized features list
            }
            return normFts;
        }


        /*
         * Function obtains the updated weight per bin
         */
        public List<double> updateWeight(List<double> stdForBins, List<double> averageForBins)
        {
            List<double> updatedWeightBins = new List<double>();

            for (int i = 0; i < stdForBins.Count; i++)
            {
                double updatedWeight = 0; //stores values
                double divisor = 0; //stores the divisor

                //check for special cases and appends to the list accordingly by the parameters
                if (averageForBins[i] == 0 && stdForBins[i] == 0)
                {
                    updatedWeightBins.Add(0);
                }
                else if (stdForBins[i] == 0 && averageForBins[i] != 0)
                {
                    divisor = .5 * stdForBins.Where(x => x > 0).DefaultIfEmpty(0).Min(); // Filter out zero values and find the minimum
                    updatedWeight = 1.0 / divisor;
                    updatedWeightBins.Add(updatedWeight);
                }
                else
                {
                    updatedWeight = 1.0 / stdForBins[i];
                    updatedWeightBins.Add(updatedWeight);
                }
            }

            return updatedWeightBins;
        }

        /*
         * Function obtaining normalized weight following the updated weight
         */
        public List<double> normalizedWeight(List<double> updatedWeights)
        {
            List<double> nWeight = new List<double>();

            double sumWeight = updatedWeights.Sum(); // sum the total weight for use as a divisor

            for (int i = 0; i < updatedWeights.Count; i++) // iterate through the updated weight list for normal weight value
            {
                if (updatedWeights[i] == 0) // condition to prevent error and to append the correct values into the normalized weight list
                {
                    nWeight.Add(0);
                }
                else
                {
                    nWeight.Add(updatedWeights[i] / sumWeight);
                }
            }
            return nWeight; // return normalized weight list
        }

        /*
         * Calculating manhattan distance for relevance feedback
         */
        public void manhattanDistanceRF(List<(double[] normFts, int index)> normalizedFeatures, List<double> normWeight, List<double> distanceRF, ListBox lstView)
        {
            if (normWeight == null) // returns the manhattan distance when no images are deemed relevant
            {
                int selectedIndex = lstView.SelectedIndex; // stores selected index

                for (int i = 0; i < lstView.Items.Count; i++)
                {
                    if (distanceRF.Count == 100)
                        return;

                    if (i == selectedIndex)
                    {
                        distanceRF.Add(0);
                    }
                    else
                    {
                        double distance = 0;

                        //calculates distances for both lists to store for query use
                        for (int j = 0; j < normalizedFeatures[i].normFts.Length; j++)
                        {
                            distance += (1.0 / normalizedFeatures[i].normFts.Length) * (double)Math.Abs(normalizedFeatures[selectedIndex].normFts[j] - normalizedFeatures[i].normFts[j]); // performs the relevance feedback without images being relevant
                        }
                        distanceRF.Add(distance);
                    }
                }
            }
            else
            {
                if (normWeight != null) // returns the manhattan distance when images are deemed relevant
                {
                    int selectedIndex = lstView.SelectedIndex; // stores selected index

                    for (int i = 0; i < lstView.Items.Count; i++)
                    {
                        if (distanceRF.Count == 100) // prevent the bug of double executions
                            return;

                        if (i == selectedIndex)
                        {
                            distanceRF.Add(0);
                        }
                        else
                        {
                            double distance = 0;

                            //calculates distances for both lists to store for query use
                            for (int j = 0; j < normalizedFeatures[i].normFts.Length; j++)
                            {
                                distance += normWeight[j] * (double)Math.Abs(normalizedFeatures[selectedIndex].normFts[j] - normalizedFeatures[i].normFts[j]); // follows formula from excel practice
                            }
                            distanceRF.Add(distance);
                        }
                    }
                }
            }
            return;
        }
    }
}

# Simple Content-Based Image Retrieval System

Program is based off of the concepts of the image retrieval system, extracting the base features from an image using intensity, color-code, and relevance feedback. 
This program helped me build my practical implications toward image processing and querying through this experience. The program expanded my multimedia knowledge and more.

Below are descriptions of features used in the program:
### Intensity
![image](https://github.com/user-attachments/assets/1da30f70-150c-4c46-928b-681a0a09bb7b)

By this way, the 24-bit of RGB (8 bits for each color channel) color intensities
can be transformed into a single 8-bit value. The histogram bins selected for
this case are listed below:

![image](https://github.com/user-attachments/assets/e1dd16ac-a3ea-47f1-8326-b6432d1b393d)

### Color-Code
The 24-bit of RGB color intensities can be transformed into a 6-bit color code,
composed from the most significant 2 bits of each of the three color
components, as illustrated in the following figure

![image](https://github.com/user-attachments/assets/bfa3cd27-6e2f-4c6e-a781-6776400d3f5d)

The 6-bit color code will provide 64 histogram bins.

### Relevance Feedback
1. Combining intensity and color-code histograms together as the feature set for each image.
2. If histogram is in “# of counts”, divide each one by its corresponding image size
3. Use Gaussian normalization for feature normalization
4. Use simplified RF version

   a. Use the normalized feature matrix and initial weights (no-bias weights) to return initial query results

   b. On the GUI, only two levels of relevance are required: relevant and non-relevant

   c. Collect user’s feedback, update the feature weights

   d. Return updated query results and go through iterations (step c & d)

   e. Distance metric:
   
   ![image](https://github.com/user-attachments/assets/52c36e2b-855c-457a-aed1-a9f1f76945fe)

NOTE: In updating the weights, if standard deviation sti for a feature i of all the relevant images
is 0

   a. and its mean value mi is not 0, set sti to be 0.5*min(non-zero standard deviations of all the features). Then calculate the feature weight Wi
   
   b. and mi is 0, set Wi = 0


### Querying Images
![image](https://github.com/user-attachments/assets/8258d809-46ec-4024-b6af-85aa2491df7c)


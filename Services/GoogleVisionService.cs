using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetTextTool.Services
{
    internal class GoogleVisionService
    {
        // Detect text from image using google vision api
        public List<string> GetTextDetectionFromImage(string imageBase64, out string errorMessage)
        {
            // Initial
            errorMessage = String.Empty;
            var result = new List<string>();

            try
            {
                // Instantiates a client
                var client = ImageAnnotatorClient.Create();

                // Performs text detection on the image file
                var image = Image.FromBytes(Convert.FromBase64String(imageBase64));
                var response = client.DetectText(image);
                foreach (var annotation in response)
                {
                    var a = annotation.BoundingPoly.Vertices;
                    result.Add(annotation?.Description);
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }

        // Detect text from image using google vision api
        //public List<GoogleVisionDetectedWord> GetListDetectedWordFromImage(string imageBase64, out string errorMessage)
        //{
        //    // Initial
        //    errorMessage = String.Empty;
        //    var result = new List<GoogleVisionDetectedWord>();

        //    try
        //    {
        //        // Instantiates a client
        //        var client = ImageAnnotatorClient.Create();

        //        // Performs text detection on the image file
        //        var image = Image.FromBytes(Convert.FromBase64String(imageBase64));
        //        var response = client.DetectText(image);
        //        foreach (var annotation in response)
        //        {
        //            var wordDetected = new GoogleVisionDetectedWord();
        //            wordDetected.Description = annotation?.Description;
        //            wordDetected.Vertices.AddRange(annotation?.BoundingPoly.Vertices);

        //            result.Add(wordDetected);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        errorMessage = e.Message;
        //    }

        //    return result;
        //}

        // Merge first vertices with second vertices
        public List<Vertex> MergeVertices(List<Vertex> verticesSt, List<Vertex> verticesNd, out string errorMessage)
        {
            // Initial
            errorMessage = String.Empty;
            var result = new List<Vertex>();

            try
            {
                // Initial temp list vertex contain vertices both
                var tempVertices = new List<Vertex>();
                tempVertices.AddRange(verticesSt);
                tempVertices.AddRange(verticesNd);
                var xMin = tempVertices.Min(vertex => vertex.X);
                var xMax = tempVertices.Max(vertex => vertex.X);
                var yMin = tempVertices.Min(vertex => vertex.Y);
                var yMax = tempVertices.Max(vertex => vertex.Y);

                // Setup vertices
                var vertexTopLeft = new Vertex();
                vertexTopLeft.X = xMin;
                vertexTopLeft.Y = yMin;
                result.Add(vertexTopLeft);

                var vertexTopRight = new Vertex();
                vertexTopRight.X = xMax;
                vertexTopRight.Y = yMin;
                result.Add(vertexTopRight);

                var vertexBottomRight = new Vertex();
                vertexBottomRight.X = xMax;
                vertexBottomRight.Y = yMax;
                result.Add(vertexBottomRight);

                var vertexBottomLeft = new Vertex();
                vertexBottomLeft.X = xMin;
                vertexBottomLeft.Y = yMax;
                result.Add(vertexBottomLeft);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }
    }
}

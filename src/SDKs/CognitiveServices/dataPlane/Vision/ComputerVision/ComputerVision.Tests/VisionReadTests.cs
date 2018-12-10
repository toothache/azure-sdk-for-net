using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionReadTests : BaseTests
    {
        static private IList<RecognitionResult> GetRecognitionResultsWithPolling(IComputerVisionClient client, string operationLocation)
        {
            string operationId = operationLocation.Substring(operationLocation.LastIndexOf('/') + 1);

            for (int remainingTries = 10; remainingTries > 0; remainingTries--)
            {
                ReadResult result = client.GetReadResultAsync(operationId).Result;

                Assert.True(result.Status != TextOperationStatusCodes.Failed);

                if (result.Status == TextOperationStatusCodes.Succeeded)
                {
                    return result.RecognitionResults;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            return null;
        }

        [Fact]
        public void ReadTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "ReadTest");

                string imageUrl = GetTestImageUrl("signage.jpg");
                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    ReadResult readResult = client.ReadAsync(imageUrl, TextRecognitionMode.Printed).Result;

                    Assert.NotNull(readResult);
                    Assert.Equal(TextOperationStatusCodes.Succeeded, readResult.Status);

                    Assert.NotNull(readResult.RecognitionResults);
                    Assert.Equal(1, readResult.RecognitionResults.Count);

                    var recognitionResult = readResult.RecognitionResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(250, recognitionResult.Width);
                    Assert.Equal(258, recognitionResult.Height);

                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" }.OrderBy(t => t),
                        recognitionResult.Lines.Select(line => line.Text).OrderBy(t => t));
                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" }.OrderBy(t => t),
                        recognitionResult.Lines.SelectMany(line => line.Words).Select(word => word.Text).OrderBy(t => t));
                    Assert.Equal(3, recognitionResult.Lines.Count);
                }
            }
        }

        [Fact]
        public void ReadInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "ReadInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("whiteboard.jpg"), FileMode.Open))
                {
                    ReadResult readResult = client.ReadInStreamAsync(stream, TextRecognitionMode.Handwritten).Result;

                    Assert.NotNull(readResult);
                    Assert.Equal(TextOperationStatusCodes.Succeeded, readResult.Status);

                    Assert.NotNull(readResult.RecognitionResults);
                    Assert.Equal(1, readResult.RecognitionResults.Count);

                    var recognitionResult = readResult.RecognitionResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(1000, recognitionResult.Width);
                    Assert.Equal(664, recognitionResult.Height);

                    Assert.Equal(
                        new string[] { "You must be the change", "you want to see in the world!" }.OrderBy(t => t),
                        recognitionResult.Lines.Select(line => line.Text).OrderBy(t => t));
                    Assert.Equal(2, recognitionResult.Lines.Count);
                    Assert.Equal(5, recognitionResult.Lines[0].Words.Count);
                    Assert.Equal(7, recognitionResult.Lines[1].Words.Count);
                }
            }
        }

        [Fact]
        public void ReadDocumentTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "ReadDocumentTest");

                string imageUrl = GetTestImageUrl("signage.jpg");
                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    ReadDocumentHeaders headers = client.ReadDocumentAsync(imageUrl, TextRecognitionMode.Printed).Result;

                    Assert.NotNull(headers.OperationLocation);

                    var recognitionResults = GetRecognitionResultsWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(recognitionResults);
                    Assert.Equal(1, recognitionResults.Count);

                    var recognitionResult = recognitionResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(250, recognitionResult.Width);
                    Assert.Equal(258, recognitionResult.Height);

                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" }.OrderBy(t => t),
                        recognitionResult.Lines.Select(line => line.Text).OrderBy(t => t));
                    Assert.Equal(
                        new string[] { "520", "WEST", "Seattle" }.OrderBy(t => t),
                        recognitionResult.Lines.SelectMany(line => line.Words).Select(word => word.Text).OrderBy(t => t));
                    Assert.Equal(3, recognitionResult.Lines.Count);
                }
            }
        }

        [Fact]
        public void ReadDocumentInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "ReadDocumentInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("whiteboard.jpg"), FileMode.Open))
                {
                    ReadDocumentInStreamHeaders headers = client.ReadDocumentInStreamAsync(stream, TextRecognitionMode.Printed).Result;

                    Assert.NotNull(headers.OperationLocation);

                    var recognitionResults = GetRecognitionResultsWithPolling(client, headers.OperationLocation);

                    Assert.NotNull(recognitionResults);
                    Assert.Equal(1, recognitionResults.Count);

                    var recognitionResult = recognitionResults[0];

                    Assert.Equal(1, recognitionResult.Page);
                    Assert.Equal(1000, recognitionResult.Width);
                    Assert.Equal(664, recognitionResult.Height);

                    Assert.Equal(
                        new string[] { "You must be the change", "you want to see in the world!" }.OrderBy(t => t),
                        recognitionResult.Lines.Select(line => line.Text).OrderBy(t => t));
                    Assert.Equal(2, recognitionResult.Lines.Count);
                    Assert.Equal(5, recognitionResult.Lines[0].Words.Count);
                    Assert.Equal(7, recognitionResult.Lines[1].Words.Count);
                }
            }
        }
    }
}